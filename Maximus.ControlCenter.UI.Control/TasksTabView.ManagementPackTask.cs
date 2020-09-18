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
    private readonly Guid QueryServiceListTaskId = Guid.Parse("947db33d-74a9-cc0a-d28c-9c8c65cd33c4");

    private readonly Dictionary<Guid, ManagementPackTaskInfo> MPTasks = new Dictionary<Guid, ManagementPackTaskInfo>(20);

    private void GetTaskObjects()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      // Maximus.ControlCenter.QueryServiceList.Task
      try 
      {
        MPTasks[QueryServiceListTaskId] = new ManagementPackTaskInfo { ManagementPackTask = ManagementGroup.TaskConfiguration.GetTask(QueryServiceListTaskId) };
        foreach (ManagementPackOverrideableParameter param in MPTasks[QueryServiceListTaskId].ManagementPackTask.GetOverrideableParameters())
          MPTasks[QueryServiceListTaskId].OverrideableParameters.Add(key: param.Name, param);
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

    private void SubmitTask(Guid taskId, EnterpriseManagementObject mo, Dictionary<string, string> taskParameters, OnTaskStatusChangeDelegate statusChangeCallback)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      MPTasks[taskId].TaskCallback = statusChangeCallback;
      Microsoft.EnterpriseManagement.Runtime.TaskConfiguration taskParams = new Microsoft.EnterpriseManagement.Runtime.TaskConfiguration();
      if (taskParameters != null)
        foreach (KeyValuePair<string, string> paramPair in taskParameters)
          taskParams.Overrides.Add(new Pair<ManagementPackOverrideableParameter, string>(MPTasks[taskId].OverrideableParameters[paramPair.Key], paramPair.Value));
      ManagementGroup.TaskRuntime.SubmitTask(mo, MPTasks[taskId].ManagementPackTask, taskParams, new Microsoft.EnterpriseManagement.Runtime.TaskStatusChangeCallback(OnTaskStatusChange));
    }

    private void OnTaskStatusChange(Guid batchId, IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, bool completed)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (results == null)
        return;
      if (!IsHandleCreated)
        return;
      Guid taskId = results?.FirstOrDefault()?.TaskId ?? Guid.Empty;
      if (taskId != Guid.Empty && MPTasks[taskId].TaskCallback != null)
      {
        object[] paramsArray = new object[2] { results, completed };
        Invoke(MPTasks[taskId].TaskCallback, paramsArray);
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
  }

  public class ManagementPackTaskInfo
  {
    public ManagementPackTask ManagementPackTask;
    public Dictionary<string, ManagementPackOverrideableParameter> OverrideableParameters = new Dictionary<string, ManagementPackOverrideableParameter>();
    public OnTaskStatusChangeDelegate TaskCallback;
  }
}
