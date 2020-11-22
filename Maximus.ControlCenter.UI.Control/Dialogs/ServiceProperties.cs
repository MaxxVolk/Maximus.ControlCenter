using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using Maximus.ControlCenter.Tasks.Module.Services;
using Maximus.ControlCenter.Tasks.Module;
using Microsoft.EnterpriseManagement.Runtime;

namespace Maximus.ControlCenter.UI.Control.Dialogs
{
  public enum ActionCodeEnum { Start = 1, Stop = 2, Pause = 3, Resume = 4, Command = 5 }

  public partial class ServicePropertiesForm : Form
  {
    public DataRowView InputData { private get; set; }
    public TasksTabView ParentTabView { private get; set; }

    // configuration change
    private bool TraceChanges = false;
    private bool StartupTypeChanged = false, LogOnNameChanged = false, LogOnPasswordChanged = false;
    private ServiceStartMode NewServiceStartMode;
    private string NewLogOnName = "", NewLogOnPassword = "";

    public ServicePropertiesForm()
    {
      InitializeComponent();
      cbStartupType.Items.AddRange(EnumWithDescription<ServiceStartMode>.GetEnumValuesArray());
    }

    private void ServicePropertiesForm_Load(object sender, EventArgs e)
    {
      if (InputData == null && ParentTabView == null)
        Close();

      ServiceInfo serviceInfo = (ServiceInfo)InputData["SourceObject"];
      ShowServiceInfo(serviceInfo);
      TraceChanges = true;
    }

    private void ShowServiceInfo(ServiceInfo serviceInfo)
    {
      tbName.Text = serviceInfo.Name;
      tbDescription.Text = serviceInfo.Description ?? "";
      tbDisplayName.Text = serviceInfo.DisplayName;
      tbPathToExecute.Text = serviceInfo.ImagePath;
      cbDelayed.Checked = serviceInfo.IsDelayed;
      cbTriggerStart.Checked = serviceInfo.IsTriggered;
      lStatus.Text = serviceInfo.Status;
      tbObjectName.Text = serviceInfo.ObjectName;
      tbClusterNode.Text = serviceInfo.NodeName;
      tbClusterStatus.Text = serviceInfo.IsClustered ? (serviceInfo.IsClusterOffline ? "Offline" : "Online") : "N/A";
      tbIsClustered.Text = serviceInfo.IsClustered ? "Clustered" : "Non-Clustered";

      ServiceControllerStatus serviceStatus = (ServiceControllerStatus)Enum.Parse(typeof(ServiceControllerStatus), serviceInfo.Status);
      switch (serviceStatus)
      {
        case ServiceControllerStatus.Running:
          btStop.Enabled = true;
          btStart.Enabled = false;
          btPause.Enabled = true;
          btResume.Enabled = false;
          break;
        case ServiceControllerStatus.Stopped:
          btStop.Enabled = false;
          btStart.Enabled = true;
          btPause.Enabled = false;
          btResume.Enabled = false;
          break;
        case ServiceControllerStatus.Paused:
          btStop.Enabled = true;
          btStart.Enabled = false;
          btPause.Enabled = false;
          btResume.Enabled = true;
          break;
        case ServiceControllerStatus.ContinuePending:
        case ServiceControllerStatus.PausePending:
        case ServiceControllerStatus.StartPending:
        case ServiceControllerStatus.StopPending:
          btStop.Enabled = false;
          btStart.Enabled = false;
          btPause.Enabled = false;
          btResume.Enabled = false;
          break;
      }
      
      ServiceType serviceType = (ServiceType)serviceInfo.Type;
      tbServiceType.Text = serviceType.ToString();

      ServiceStartMode serviceStartMode = (ServiceStartMode)serviceInfo.Start;
      for (int newSE = 0; newSE < cbStartupType.Items.Count; newSE++)
        if ((ServiceStartMode)((EnumWithDescription<ServiceStartMode>)cbStartupType.Items[newSE]).NativeValue == serviceStartMode)
          cbStartupType.SelectedIndex = newSE;


      if (serviceInfo.Parameters != null)
      {
        lvParameters.Items.Clear();
        foreach (ServiceParameter param in serviceInfo.Parameters)
        {
          lvParameters.Items.Add(new ListViewItem(new string[] { param.Name, param.RegType, param.Data.ToString() }));
        }
      }

      if (serviceInfo.DependOnService?.Length == serviceInfo.DependOn?.Count)
      {
        tvDependsOn.Nodes.Clear();
        foreach (DependOnRecord dsr in serviceInfo.DependOn)
          AddDependservice(tvDependsOn.Nodes, dsr);
      }
      else if (serviceInfo.DependOnService != null)
      {
        tvDependsOn.Nodes.Clear();
        foreach (string dp in serviceInfo.DependOnService)
          tvDependsOn.Nodes.Add(dp);
        tvDependsOn.Nodes.Add("Click 'Refresh' for detailed recursive dependency information.");
      }
      if (serviceInfo.Dependant != null)
      {
        tbDepending.Nodes.Clear();
        foreach (DependOnRecord dsr in serviceInfo.Dependant)
          AddDependservice(tbDepending.Nodes, dsr);
      }
    }

    private void AddDependservice(TreeNodeCollection nodes, DependOnRecord dsr)
    {
      TreeNode newNode = nodes.Add($"{dsr.DependencyDisplayName} [{dsr.DependencyName}]");
      if (dsr.DependOn != null)
        foreach (DependOnRecord ddsr in dsr.DependOn)
          AddDependservice(newNode.Nodes, ddsr);
    }

    private void btApply_Click(object sender, EventArgs e)
    {
      ApplyChanges(new OnTaskStatusChangeDelegate(OnServiceControl));
      StartupTypeChanged = false; LogOnNameChanged = false; LogOnPasswordChanged = false;
      SetApplyButton();
    }

    private void ServicePropertiesForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      // MessageBox.Show($"closing: {e.CloseReason}; {DialogResult}", "Operation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
      if (e.CloseReason == CloseReason.None && DialogResult == DialogResult.OK) // none => from dialog result button, user => by close cross
      {
        ApplyChanges(null);
        StartupTypeChanged = false; LogOnNameChanged = false; LogOnPasswordChanged = false;
      }
    }

    private void ApplyChanges(OnTaskStatusChangeDelegate changeDelegate)
    {
      Dictionary<string, string> taskParams = new Dictionary<string, string>()
      {
        { "QueryService", ((ServiceInfo)InputData["SourceObject"]).Name },
      };

      if (StartupTypeChanged)
        taskParams.Add("StartType", ((int)NewServiceStartMode).ToString());
      if (LogOnPasswordChanged)
        taskParams.Add("Password", NewLogOnPassword);
      if (LogOnNameChanged)
        taskParams.Add("ServiceStartName", NewLogOnName);

      ParentTabView.SubmitTaskAsync(ParentTabView.ConfigureServiceTaskId, ParentTabView.ManagementObject, taskParams, changeDelegate);
    }

    private void btStart_Click(object sender, EventArgs e)
    {
      ExecuteControl(ActionCodeEnum.Start);
    }

    private void ExecuteControl(ActionCodeEnum action)
    {
      lStatus.Text = "Unknown. Click 'Refresh' to update.";
      btStop.Enabled = false;
      btStart.Enabled = false;
      btPause.Enabled = false;
      btResume.Enabled = false;
      ParentTabView.SubmitTaskAsync(ParentTabView.ControlServiceTaskId, ParentTabView.ManagementObject, new Dictionary<string, string>
      {
        { "QueryService", ((ServiceInfo)InputData["SourceObject"]).Name },
        { "ActionCode", ((int)action).ToString() }
      }, new OnTaskStatusChangeDelegate(OnServiceControl));
    }

    private void OnServiceControl(IList<TaskResult> results, bool lastUpdate)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      foreach (TaskResult result in results)
        try
        {
          if (result.Status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.Succeeded || result.Status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.CompletedWithInfo)
            using (StringReader stringReader = new StringReader(result.Output))
            {
              using (XmlReader xmlReader = XmlReader.Create(stringReader))
              {
                if (xmlReader.Read() && xmlReader.ReadToDescendant("QuadrupleList"))
                {
                  QuadrupleListDataItem qlist = new QuadrupleListDataItem(xmlReader.ReadSubtree());
                  if (qlist.Data.List.Any())
                  {
                    Quadruple response = qlist.Data.List[0];
                    if (response.I1 == "ERROR")
                      MessageBox.Show(response.I2, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //if (response.I1 == "OK")
                    //  MessageBox.Show("Service Configuration task completed successfully.", "Operation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                }
              }
            }
        }
        catch (Exception e)
        {
          Dbg.Log($"Exception {e.Message} in {MethodBase.GetCurrentMethod().Name}");
        }
    }

    private void btStop_Click(object sender, EventArgs e)
    {
      ExecuteControl(ActionCodeEnum.Stop);
    }

    private void btPause_Click(object sender, EventArgs e)
    {
      ExecuteControl(ActionCodeEnum.Pause);
    }

    private void btResume_Click(object sender, EventArgs e)
    {
      ExecuteControl(ActionCodeEnum.Resume);
    }

    private void btRefresh_Click(object sender, EventArgs e)
    {
      ParentTabView.SubmitTaskAsync(ParentTabView.QueryServiceListTaskId, ParentTabView.ManagementObject, new Dictionary<string, string>
      {
        { "QueryParameters", true.ToString() },
        { "QueryService", ((ServiceInfo)InputData["SourceObject"]).Name }
      }, new OnTaskStatusChangeDelegate(OnServiceRefresh));
    }

    private void tbObjectName_TextChanged(object sender, EventArgs e)
    {
      if (!TraceChanges) return;
      LogOnNameChanged = true;
      NewLogOnName = tbObjectName.Text;
      SetApplyButton();
    }


    private void tbPassword_TextChanged(object sender, EventArgs e)
    {
      if (!TraceChanges) return;
      LogOnPasswordChanged = true;
      NewLogOnPassword = tbPassword1.Text == tbPassword2.Text ? tbPassword1.Text : null;
    }

    private void OnServiceRefresh(IList<TaskResult> results, bool lastUpdate)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      foreach (Microsoft.EnterpriseManagement.Runtime.TaskResult result in results)
        try
        {
          if (result.Status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.Succeeded || result.Status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.CompletedWithInfo)
            using (StringReader stringReader = new StringReader(result.Output))
            {
              using (XmlReader xmlReader = XmlReader.Create(stringReader))
              {
                if (xmlReader.Read() && xmlReader.ReadToDescendant("ServiceList"))
                {
                  ServiceListDataItem serviceListResult = new ServiceListDataItem(xmlReader.ReadSubtree());
                  if (serviceListResult.Data.ErrorCode == 0)
                  {
                    ShowServiceInfo(serviceListResult.Data.Services[0]);
                  }
                }
              }
            }
        }
        catch (Exception e)
        {
          Dbg.Log($"Exception {e.Message} in {MethodBase.GetCurrentMethod().Name}");
        }
    }

    private void cbStartupType_SelectionChangeCommitted(object sender, EventArgs e)
    {
      if (!TraceChanges) return;
      if (cbStartupType.SelectedIndex >= 0)
      {
        StartupTypeChanged = true;
        NewServiceStartMode = (ServiceStartMode)((EnumWithDescription<ServiceStartMode>)cbStartupType.Items[cbStartupType.SelectedIndex]).NativeValue;
        SetApplyButton();
      }
    }

    private void SetApplyButton()
    {
      if (StartupTypeChanged || LogOnNameChanged || (LogOnPasswordChanged & !string.IsNullOrEmpty(NewLogOnPassword)))
        btApply.Enabled = true;
      else
        btApply.Enabled = false;
    }
  }
}
