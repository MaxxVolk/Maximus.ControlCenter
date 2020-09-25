using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

using Maximus.Library.DataItemCollection;

using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;

namespace Maximus.ControlCenter.UI.Control
{
  public delegate void OnTaskStatusChangeDelegate(IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, bool lastUpdate);

  public partial class TasksTabView
  {
    public readonly Guid QueryServiceListTaskId = Guid.Parse("947db33d-74a9-cc0a-d28c-9c8c65cd33c4");
    public readonly Guid ControlServiceTaskId = Guid.Parse("84c9e107-8d5b-6936-25a6-177fb2d563cd");
    public readonly Guid ConfigureServiceTaskId = Guid.Parse("86389e6b-2f7b-6604-1865-ca4a521b773a");
    public readonly Guid ReadEventLogTaskId = Guid.Parse("7634b1dc-5710-c2c1-9f0a-5c798a1ea84c");
    public readonly Guid ListEventLogsTaskId = Guid.Parse("ec971a1d-6176-8cca-51bd-d7c20af1a573");

    private readonly Dictionary<Guid, ManagementPackTaskInfo> MPTasks = new Dictionary<Guid, ManagementPackTaskInfo>(20);
    private object onTaskStatusChangeLock = new object();

    private void GetTaskObjects(Guid taskId)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      try
      {
        MPTasks[taskId] = new ManagementPackTaskInfo { ManagementPackTask = ManagementGroup.TaskConfiguration.GetTask(taskId) };
        foreach (ManagementPackOverrideableParameter param in MPTasks[taskId].ManagementPackTask.GetOverrideableParameters())
          MPTasks[taskId].OverrideableParameters.Add(key: param.Name, param);
      }
      catch
      {

      }
    }

    private void EnableTaskControls()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (!MPTasks.ContainsKey(QueryServiceListTaskId))
        btServicesRefresh.Enabled = false;
    }

    public void SubmitTaskAsync(Guid taskId, EnterpriseManagementObject mo, Dictionary<string, string> taskParameters, OnTaskStatusChangeDelegate statusChangeCallback)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (!MPTasks.ContainsKey(taskId))
        GetTaskObjects(taskId);
      if (MPTasks.ContainsKey(taskId))
      {
        Microsoft.EnterpriseManagement.Runtime.TaskConfiguration taskParams = new Microsoft.EnterpriseManagement.Runtime.TaskConfiguration();
        if (taskParameters != null)
          foreach (KeyValuePair<string, string> paramPair in taskParameters)
            taskParams.Overrides.Add(new Pair<ManagementPackOverrideableParameter, string>(MPTasks[taskId].OverrideableParameters[paramPair.Key], paramPair.Value));
        UpdateTaskStatus("Starting a new task...");
        Guid batchId = ManagementGroup.TaskRuntime.SubmitTask(mo, MPTasks[taskId].ManagementPackTask, taskParams, new Microsoft.EnterpriseManagement.Runtime.TaskStatusChangeCallback(OnTaskStatusChange));
        MPTasks[taskId].TaskCallbacks.Add(batchId, statusChangeCallback);
        UpdateTaskStatus("Waiting on task completion...");
      }
    }

    private void OnTaskStatusChange(Guid batchId, IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, bool completed)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (results == null)
        return;
      if (!IsHandleCreated)
        return;
      lock (onTaskStatusChangeLock)
      {
        Guid taskId = Guid.Empty;
        try
        {
          taskId = results?.FirstOrDefault()?.TaskId ?? Guid.Empty;
          OnTaskStatusChangeDelegate taskCallback = MPTasks[taskId].TaskCallbacks[batchId];
          if (taskId != Guid.Empty && taskCallback != null)
          {
            if (taskCallback.Target is System.Windows.Forms.Control callbackControl)
              try
              {
                callbackControl.Invoke(taskCallback, new object[] { results, completed });
              }
              catch { }
          }
          if (completed && taskId != Guid.Empty)
            MPTasks[taskId].TaskCallbacks.Remove(batchId);
        }
        catch { }

        if (taskId != Guid.Empty)
          try
          {
            int tasksInProgress = MPTasks[taskId].TaskCallbacks.Count;
            if (tasksInProgress == 0)
              Invoke(new Action<string>(UpdateTaskStatus), new object[] { "" });
            else
              Invoke(new Action<string>(UpdateTaskStatus), new object[] { $"{tasksInProgress} are waiting to complete..." });

            Dbg.Log($"Callback dictionary size: {tasksInProgress}");
          }
          catch
          {
            Invoke(new Action<string>(UpdateTaskStatus), new object[] { "" });
          }
      }
    }

    private bool IsTaskStatusFinite(Microsoft.EnterpriseManagement.Runtime.TaskStatus status)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.Succeeded)
        return true;
      if (status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.Canceled)
        return true;
      if (status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.Failed)
        return true;
      if (status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.CompletedWithInfo)
        return true;
      return false;
    }

    private DataItemType DeserializeDataItemFromTaskResults<DataItemType, ContainmentType>(IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, Func<XmlReader, DataItemType> creator) where DataItemType : SerializationDataContainerDataItemBase<ContainmentType> where ContainmentType : SerializationData
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      foreach (Microsoft.EnterpriseManagement.Runtime.TaskResult result in results)
        if (IsTaskStatusFinite(result.Status))
        {
          using (StringReader stringReader = new StringReader(result.Output))
          {
            using (XmlReader xmlReader = XmlReader.Create(stringReader))
            {
              if (result.Status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.Succeeded || result.Status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.CompletedWithInfo)
              {
                object containmentNodeAttr = typeof(ContainmentType).GetCustomAttributes(typeof(XmlRootAttribute), inherit: true).FirstOrDefault();
                Dbg.Log($"containmentNodeAttr == null: {containmentNodeAttr == null} {MethodBase.GetCurrentMethod().Name}");
                if (containmentNodeAttr == null)
                  return null;
                if (containmentNodeAttr is XmlRootAttribute xmlRootAttr)
                  if (xmlReader.Read() && xmlReader.ReadToDescendant(xmlRootAttr.ElementName))
                    return creator(xmlReader.ReadSubtree());
              }
            }
          }
          break;
        }
      return null;
    }

    private void UpdateTaskStatus(string msg)
    {
      lCurrentTasks.Text = msg;
    }
  }

  public class ManagementPackTaskInfo
  {
    public ManagementPackTask ManagementPackTask;
    public Dictionary<string, ManagementPackOverrideableParameter> OverrideableParameters = new Dictionary<string, ManagementPackOverrideableParameter>();
    public Dictionary<Guid, OnTaskStatusChangeDelegate> TaskCallbacks = new Dictionary<Guid, OnTaskStatusChangeDelegate>();
  }
}
