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

using Microsoft.EnterpriseManagement.Runtime;

namespace Maximus.ControlCenter.UI.Control.Dialogs
{
  public partial class ServicePropertiesForm : Form
  {
    public DataRowView InputData { private get; set; }
    public TasksTabView ParentTabView { private get; set; }

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
        if ((ServiceStartMode)(((EnumWithDescription<ServiceStartMode>)cbStartupType.Items[newSE]).NativeValue) == serviceStartMode)
          cbStartupType.SelectedIndex = newSE;

      lvParameters.Items.Clear();
      if (serviceInfo.Parameters != null)
        foreach (ServiceParameter param in serviceInfo.Parameters)
        {
          lvParameters.Items.Add(new ListViewItem(new string[] { param.Name, param.RegType, param.Data.ToString() }));
        }
    }

    private void btRefresh_Click(object sender, EventArgs e)
    {
      ParentTabView.SubmitTask(ParentTabView.QueryServiceListTaskId, ParentTabView.ManagementObject, new Dictionary<string, string>
      {
        { "QueryParameters", true.ToString() },
        { "QueryService", ((ServiceInfo)InputData["SourceObject"]).Name }
      }, new OnTaskStatusChangeDelegate(OnServiceRefresh));
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
  }
}
