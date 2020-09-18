using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement.Mom.Internal.UI;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Common;
using System.Reflection;
using System.IO;
using System.Xml;
using Maximus.ControlCenter.Tasks.Module.Services;
using Maximus.Library.SCOMId;

namespace Maximus.ControlCenter.UI.Control
{
  public partial class TasksTabView : CachedDetailView<PartialMonitoringObject>, IDisposable
  {
    private ManagementPackClass healthServiceClass = null;
    private string currentSelectedObjectName = "";
    private EnterpriseManagementObject ManagementObject;


    public TasksTabView() : base()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      InitializeComponent();
      RefreshColors();

      dgvServices.AutoGenerateColumns = false;
    }

    protected override void OnLoad(EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");
      base.OnLoad(e);

      GetTaskObjects();
      EnableTaskControls();
    }

    private void RefreshColors()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (SystemInformation.HighContrast)
      {
        BackColor = SystemColors.Control;
      }
      else
      {
        BackColor = BrandedColors.OverviewBackgroundColor;
        dgvServices.BackgroundColor = BrandedColors.GridBackground;
      }
    }

    protected override void OnSystemColorsChanged(EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      RefreshColors();
    }

    protected override void OnForeColorChanged(EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      base.OnForeColorChanged(e);
      RefreshColors();
    }

    public override string ViewName
    {
      get
      {
        Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

        return $"Control Panel: {currentSelectedObjectName ?? "No selection"}";
      }
    }

    public override void OnCacheUpdated(PartialMonitoringObject monitoringObjectContext)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      currentSelectedObjectName = monitoringObjectContext?.DisplayName ?? "";
      if (monitoringObjectContext == null)
      {
        ShowStatusMessage("Select an Item to show Control Panel.", false);
        return;
      }
      healthServiceClass = healthServiceClass ?? ManagementGroup.EntityTypes.GetClass(SystemCenterId.HealthServiceClassId);
      IList<EnterpriseManagementObject> healthServiceInstance = ManagementGroup.EntityObjects.GetRelatedObjects<EnterpriseManagementObject>(monitoringObjectContext.Id, healthServiceClass, TraversalDepth.OneLevel, ObjectQueryOptions.Default);
      if (!healthServiceInstance.Any())
      {
        ShowStatusMessage("This is cluster object or agent-less monitored computer. Select agent-based monitoring computer to show Control Panel.", false);
        return;
      }
      ManagementObject = healthServiceInstance.First();
      HideStatusMessage();
      ClearTabs();
    }

    private void ClearTabs()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      dgvServices.DataSource = null;
    }

    private void btServicesRefresh_Click(object sender, EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      SubmitTask(QueryServiceListTaskId, ManagementObject,
        new Dictionary<string, string>
        {
          { "QueryParameters", false.ToString() }
        }, new OnTaskStatusChangeDelegate(OnQueryServiceListTaskChange));
    }

    private void OnQueryServiceListTaskChange(IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, bool lastUpdate)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      foreach (Microsoft.EnterpriseManagement.Runtime.TaskResult result in results)
        try
        {
          if (IsTaskStatusFinite(result.Status))
          {
            StringReader stringReader = new StringReader(result.Output);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            if (result.Status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.Succeeded || result.Status == Microsoft.EnterpriseManagement.Runtime.TaskStatus.CompletedWithInfo)
            {
              if (xmlReader.Read() && xmlReader.ReadToDescendant("ServiceList"))
              {
                ServiceListDataItem serviceListResult = new ServiceListDataItem(xmlReader.ReadSubtree());
                if (serviceListResult.Data.ErrorCode == 0)
                {
                  DataTable table = PrepareServiceTable(serviceListResult);
                  BindingSource bs = new BindingSource() { DataSource = table };
                  dgvServices.DataSource = bs;
                }
              }
            }
          }

          break;
        }
        catch (Exception e)
        {
          Dbg.Log($"Exception {e.Message} in {MethodBase.GetCurrentMethod().Name}");
        }
    }

    private DataTable PrepareServiceTable(ServiceListDataItem  serviceDataItem)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      DataTable result = new DataTable();
      result.Columns.Add("DisplayName", typeof(string)).AllowDBNull = true;
      result.Columns.Add("Description", typeof(string)).AllowDBNull = true;
      result.Columns.Add("Start", typeof(string)).AllowDBNull = true;
      result.Columns.Add("ObjectName", typeof(string)).AllowDBNull = true;
      result.Columns.Add("IsDelayed", typeof(bool)).AllowDBNull = true;
      result.Columns.Add("IsTriggered", typeof(bool)).AllowDBNull = true;
      result.Columns.Add("Status", typeof(string)).AllowDBNull = true;

      result.Columns.Add("SourceObject", typeof(ServiceInfo));

      foreach(ServiceInfo serviceInfo in serviceDataItem.Data.Services)
        result.LoadDataRow(new object[] 
        { 
          (object)serviceInfo.DisplayName ?? (object)serviceInfo.Name ?? DBNull.Value,
          (object)serviceInfo.Description ?? DBNull.Value, 
          ServiceStartTypeToString(serviceInfo.Start),
          (object)serviceInfo.ObjectName  ?? DBNull.Value,
          serviceInfo.IsDelayed, 
          serviceInfo.IsTriggered,
          (object)serviceInfo.Status ?? DBNull.Value, 
          serviceInfo 
        }, false);
      result.AcceptChanges();

      Dbg.Log($"returning {result.Rows.Count} rows.");
      return result;
    }

    private string ServiceStartTypeToString(int serviceStartType)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      switch (serviceStartType)
      {
        case 0: return "Boot";
        case 1: return "System";
        case 2: return "Automatic";
        case 3: return "Manual";
        case 4: return "Disabled";
      }
      return "#####";
    }
  }
}
