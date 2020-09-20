using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

    private readonly Dictionary<Guid, ManagementPackTaskInfo> MPTasks = new Dictionary<Guid, ManagementPackTaskInfo>(20);

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

    public void SubmitTask(Guid taskId, EnterpriseManagementObject mo, Dictionary<string, string> taskParameters, OnTaskStatusChangeDelegate statusChangeCallback)
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
        Guid batchId = ManagementGroup.TaskRuntime.SubmitTask(mo, MPTasks[taskId].ManagementPackTask, taskParams, new Microsoft.EnterpriseManagement.Runtime.TaskStatusChangeCallback(OnTaskStatusChange));
        MPTasks[taskId].TaskCallbacks.Add(batchId, statusChangeCallback);
      }
    }

    private void OnTaskStatusChange(Guid batchId, IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, bool completed)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (results == null)
        return;
      if (!IsHandleCreated)
        return;

      Guid taskId = results?.FirstOrDefault()?.TaskId ?? Guid.Empty;
      OnTaskStatusChangeDelegate taskCallback = MPTasks[taskId].TaskCallbacks[batchId];
      if (taskId != Guid.Empty && taskCallback != null)
      {
        if (taskCallback.Target is System.Windows.Forms.Control c)
          try
          {
            object[] paramsArray = new object[2] { results, completed };
            c.Invoke(taskCallback, paramsArray);
          }
          catch { }
      }
      if (completed && taskId != Guid.Empty)
        MPTasks[taskId].TaskCallbacks.Remove(batchId);

      Dbg.Log($"Callback dictionary size: {MPTasks[taskId].TaskCallbacks.Count}");
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
  }

  public class ManagementPackTaskInfo
  {
    public ManagementPackTask ManagementPackTask;
    public Dictionary<string, ManagementPackOverrideableParameter> OverrideableParameters = new Dictionary<string, ManagementPackOverrideableParameter>();
    public Dictionary<Guid, OnTaskStatusChangeDelegate> TaskCallbacks = new Dictionary<Guid, OnTaskStatusChangeDelegate>();
  }
}
