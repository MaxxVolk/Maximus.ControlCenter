using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement.Mom.Internal.UI;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Common;
using System.Reflection;
using Maximus.ControlCenter.Tasks.Module.Services;
using Maximus.Library.SCOMId;
using Maximus.ControlCenter.UI.Control.Dialogs;
using Maximus.ControlCenter.Tasks.Module.Events;
using Maximus.ControlCenter.Tasks.Module;

namespace Maximus.ControlCenter.UI.Control
{
  public enum WriteRegistryElementAction
  {
    // KeyPath, NewName
    CreateKey = 1,
    // KeyPath, OldName
    DeleteKey = 2,
    // KeyPath, OldName, NewName
    RenameKey = 3,
    // KeyPath, NewName, NewValue, ValueType
    CreateValue = 4,
    // KeyPath, OldName
    DeleteValue = 5,
    // KeyPath, OldName, NewName
    RenameValue = 6,
    // KeyPath, OldName, NewValue, ValueType
    SetValue = 7
  }

  public partial class TasksTabView : CachedDetailView<PartialMonitoringObject>, IDisposable
  {
    private ManagementPackClass healthServiceClass = null;
    private string currentSelectedObjectName = "";

    public EnterpriseManagementObject ManagementObject;

    public TasksTabView() : base()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      InitializeComponent();
      RefreshColors();

      dgvServices.AutoGenerateColumns = false;
      dgvEventsMain.AutoGenerateColumns = false;
    }

    protected override void OnLoad(EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");
      base.OnLoad(e);

      GetTaskObjects(QueryServiceListTaskId);
      EnableTaskControls();
      cbRegRootKey.SelectedIndex = 1;
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
      cbEventSelectLog.Items.Clear();
      cbEventSelectLog.Items.AddRange(new string[] { "Application", "Security", "System" });
      cbEventSelectLog.SelectedIndex = 0;
      ClearEventDisplayElements();
    }

    private void ClearEventDisplayElements()
    {
      dgvEventsMain.DataSource = null;
      tbEventText.DataBindings.Clear();
      tbEventLogName.DataBindings.Clear();
      tbEventSource.DataBindings.Clear();
      tbEventEventId.DataBindings.Clear();
      tbEventLevel.DataBindings.Clear();
      tbEventUser.DataBindings.Clear();
      tbEventLogged.DataBindings.Clear();
      tbEventEventCatrgory.DataBindings.Clear();
      tbEventKeywords.DataBindings.Clear();
      tbEventComputer.DataBindings.Clear();
      wbEventXML.DataBindings.Clear();
    }

    private void btServicesRefresh_Click(object sender, EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      SubmitTaskAsync(QueryServiceListTaskId, ManagementObject,
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
          ServiceListDataItem serviceListResult = DeserializeDataItemFromTaskResults<ServiceListDataItem, ServiceList>(results, (xmlReader) => new ServiceListDataItem(xmlReader));
          if (serviceListResult != null && serviceListResult.Data.ErrorCode == 0)
          {
            DataTable table = PrepareServiceTable(serviceListResult);
            BindingSource bs = new BindingSource() { DataSource = table };
            dgvServices.DataSource = bs;
            dgvServices.Sort(cServiceDisplayName, ListSortDirection.Ascending);
          }
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

    private void dgvServices_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)13)
      {
        e.Handled = true;
        ShowServiceDetails((DataRowView)dgvServices.CurrentRow.DataBoundItem);
      }

    }

    private void dgvServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
      {
        ShowServiceDetails((DataRowView)dgvServices.Rows[e.RowIndex].DataBoundItem);
      }
    }

    private void ShowServiceDetails(DataRowView dataItem)
    {
      using (ServicePropertiesForm servicePropertiesForm = new ServicePropertiesForm())
      {
        servicePropertiesForm.InputData = dataItem;
        servicePropertiesForm.ParentTabView = this;
        servicePropertiesForm.ShowDialog();
      }
    }

    private void btEventsRefresh_Click(object sender, EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (!int.TryParse(tbMaxEvents.Text, out int maxEvents))
        maxEvents = 100;
      if (!int.TryParse(tbMaxSearchEvents.Text, out int maxSearchEvents))
        maxSearchEvents = 100;
      string logName = "Application";
      if (!string.IsNullOrWhiteSpace((string)cbEventSelectLog.SelectedItem))
        logName = (string)cbEventSelectLog.SelectedItem;
      else if (!string.IsNullOrWhiteSpace(cbEventSelectLog.Text))
        logName = cbEventSelectLog.Text;

      if (rbLastEvents.Checked)
      {
        SubmitTaskAsync(ReadEventLogTaskId, ManagementObject,
        new Dictionary<string, string>
        {
          { "LogName", logName },
          { "MaxEvents", maxEvents.ToString() }
        }, new OnTaskStatusChangeDelegate(OnReadEventLogTaskChange));
      }
      else if (rbSearch.Checked)
      {
        SubmitTaskAsync(ReadEventLogTaskId, ManagementObject,
        new Dictionary<string, string>
        {
          { "LogName", logName },
          { "MaxEvents", maxEvents.ToString() },
          { "MaxSearchEvents", maxSearchEvents.ToString() },
          { "SearchString", tbEventSearchExpression.Text },
          { "SearchUseRegExp", cbEventSearchRegExp.Checked.ToString() }
        }, new OnTaskStatusChangeDelegate(OnReadEventLogTaskChange));
      }
      else if (rbEventFilter.Checked)
      {
        SubmitTaskAsync(ReadEventLogTaskId, ManagementObject,
        new Dictionary<string, string>
        {
          { "LogName", logName },
          { "MaxEvents", maxEvents.ToString() },
          { "MaxSearchEvents", maxSearchEvents.ToString() },
          { "SearchString", "" },
          { "SearchUseRegExp", false.ToString() },
          { "XPathQuery", tbEventXPathQuery.Text }
        }, new OnTaskStatusChangeDelegate(OnReadEventLogTaskChange));
      }
    }

    private void OnReadEventLogTaskChange(IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, bool lastUpdate)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      try
      {
        EventListDataItem serviceListResult = DeserializeDataItemFromTaskResults<EventListDataItem, EventList>(results, (xmlReader) => new EventListDataItem(xmlReader));
        if (serviceListResult != null && serviceListResult.Data.ErrorCode == 0)
        {
          ClearEventDisplayElements();
          DataTable table = PrepareEventTable(serviceListResult);
          BindingSource bs = new BindingSource() { DataSource = table };
          dgvEventsMain.DataSource = bs;
          //dgvEventsMain.Sort(cServiceDisplayName, ListSortDirection.Ascending);
          tbEventText.DataBindings.Add("Text", bs, "FormattedDescription");
          tbEventLogName.DataBindings.Add("Text", bs, "LogName");
          tbEventSource.DataBindings.Add("Text", bs, "Source");
          tbEventEventId.DataBindings.Add("Text", bs, "EventId");
          tbEventLevel.DataBindings.Add("Text", bs, "Level");
          tbEventUser.DataBindings.Add("Text", bs, "User");
          tbEventLogged.DataBindings.Add("Text", bs, "Logged");
          tbEventEventCatrgory.DataBindings.Add("Text", bs, "TaskCategory");
          tbEventKeywords.DataBindings.Add("Text", bs, "Keywords");
          tbEventComputer.DataBindings.Add("Text", bs, "Computer");
          wbEventXML.DataBindings.Add("DocumentText", bs, "RawXML");
        }

      }
      catch (Exception e)
      {
        Dbg.Log($"Exception {e.Message} in {MethodBase.GetCurrentMethod().Name}");
      }
    }

    private DataTable PrepareEventTable(EventListDataItem serviceListResult)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      DataTable result = new DataTable();
      result.Columns.Add("LogName", typeof(string)).AllowDBNull = true;
      result.Columns.Add("Source", typeof(string)).AllowDBNull = true;
      result.Columns.Add("EventId", typeof(int)).AllowDBNull = true;
      result.Columns.Add("Level", typeof(string)).AllowDBNull = true;
      result.Columns.Add("User", typeof(string)).AllowDBNull = true;
      result.Columns.Add("Logged", typeof(DateTime)).AllowDBNull = true;
      result.Columns.Add("TaskCategory", typeof(string)).AllowDBNull = true;
      result.Columns.Add("Keywords", typeof(string)).AllowDBNull = true;
      result.Columns.Add("Computer", typeof(string)).AllowDBNull = true;
      result.Columns.Add("FormattedDescription", typeof(string)).AllowDBNull = true;
      result.Columns.Add("RawXML", typeof(string)).AllowDBNull = true;

      foreach (Tasks.Module.Events.EventInfo eventInfo in serviceListResult.Data.Events)
      {
        result.LoadDataRow(new object[]
        {
          (object)eventInfo.LogName ?? DBNull.Value,
          (object)eventInfo.Source ?? DBNull.Value,
          eventInfo.EventId,
          (object)eventInfo.Level ?? DBNull.Value,
          (object)eventInfo.User ?? DBNull.Value,
          (object)eventInfo.Logged,
          (object)eventInfo.TaskCategory ?? DBNull.Value,
          (object)eventInfo.Keywords ?? DBNull.Value,
          (object)eventInfo.Computer ?? DBNull.Value,
          (object)eventInfo.FormattedDescription ?? DBNull.Value,
          $"<?xml version=\"1.0\"?>{eventInfo.RawXML}"
        }, false);
      }
      result.AcceptChanges();

      Dbg.Log($"returning {result.Rows.Count} rows.");
      return result;
    }

    private void btEventMakeXPathQuery_Click(object sender, EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      using (EventXPathQueryForm queryDialog = new EventXPathQueryForm())
      {
        queryDialog.Query = tbEventXPathQuery.Text;
        if (queryDialog.ShowDialog() == DialogResult.OK)
        {
          tbEventXPathQuery.Text = queryDialog.Query;
          rbEventFilter.Checked = true;
        }
      }
    }

    private void dgvEventsMain_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
      switch ((string)((DataRowView)dgvEventsMain.Rows[e.RowIndex].DataBoundItem)["Level"])
      {
        case "Error": dgvEventsMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;break;
        case "Warning": dgvEventsMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow; break;
      }
    }

    private void btBrowseLogs_Click(object sender, EventArgs e)
    {
      SubmitTaskAsync(ListEventLogsTaskId, ManagementObject, null, new OnTaskStatusChangeDelegate(OnListEventLogsTaskChange));
    }

    private void OnListEventLogsTaskChange(IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, bool lastUpdate)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      try
      {
        QuadrupleListDataItem logListResult = DeserializeDataItemFromTaskResults<QuadrupleListDataItem, QuadrupleList>(results, (xmlReader) => new QuadrupleListDataItem(xmlReader));
        if (logListResult?.Data?.List != null)
        {
          cbEventSelectLog.Items.Clear();
          foreach (Quadruple logRecord in logListResult?.Data?.List)
            cbEventSelectLog.Items.Add(logRecord.I1);
        }
      }
      catch (Exception e)
      {
        Dbg.Log($"Exception {e.Message} in {MethodBase.GetCurrentMethod().Name}");
      }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void tbMaxEvents_TextChanged(object sender, EventArgs e)
    {

    }

    private void tbMaxSearchEvents_TextChanged(object sender, EventArgs e)
    {

    }

    private void tbEventSearchExpression_TextChanged(object sender, EventArgs e)
    {
      rbSearch.Checked = true;
    }

    private void tbEventXPathQuery_TextChanged(object sender, EventArgs e)
    {
      rbEventFilter.Checked = true;
    }

    private void label18_Click(object sender, EventArgs e)
    {

    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void btRegGo_Click(object sender, EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      SubmitTaskAsync(ReadRegistryKeyTaskId, ManagementObject,
        new Dictionary<string, string>
        {
          { "KeyPath", $"{cbRegRootKey.SelectedItem}\\{tbRegPath.Text}" }
        }, new OnTaskStatusChangeDelegate(OnReadRegistryKeyTaskChange));
    }

    private void OnReadRegistryKeyTaskChange(IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, bool lastUpdate)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      try
      {
        QuadrupleListDataItem regReadResult = DeserializeDataItemFromTaskResults<QuadrupleListDataItem, QuadrupleList>(results, (xmlReader) => new QuadrupleListDataItem(xmlReader));
        if (regReadResult?.Data?.List != null)
        {
          lvRegItems.Items.Clear();
          lvRegItems.Items.Add(new ListViewItem(new string[] { "..", "REG_KEY", "" }, GetRegImageIndex("REG_KEY")));
          foreach (Quadruple item in regReadResult.Data.List)
            lvRegItems.Items.Add(new ListViewItem(new string[] { item.I1, item.I2, item.I3 }, GetRegImageIndex(item.I2)));
        }
      }
      catch (Exception e)
      {
        Dbg.Log($"Exception {e.Message} in {MethodBase.GetCurrentMethod().Name}");
      }
    }

    private int GetRegImageIndex(string regType)
    {
      switch (regType)
      {
        case "REG_SZ":
        case "REG_EXPAND_SZ":
        case "REG_MULTI_SZ":
          return 1;
        case "REG_KEY":
          return 0;
      }
      return 2;
    }

    private void lvRegItems_DoubleClick(object sender, EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}; Selected items count: {lvRegItems.SelectedItems?.Count ?? -1}");

      if (lvRegItems.SelectedItems !=null && lvRegItems.SelectedItems.Count == 1)
      {
        ListViewItem selectedItem = lvRegItems.SelectedItems[0];
        Dbg.Log($"Subitems count: {selectedItem.SubItems.Count}; [0]: {selectedItem.SubItems[0].Text}");
        if (selectedItem.SubItems[1].Text == "REG_KEY")
        {
          string addPath = selectedItem.SubItems[0].Text;
          if (addPath == "..")
          {
            int deleteTo = tbRegPath.Text.LastIndexOf('\\');
            if (deleteTo >= 0)
              tbRegPath.Text = tbRegPath.Text.Substring(0, deleteTo);
          }
          else
            tbRegPath.Text += $"{(string.IsNullOrWhiteSpace(tbRegPath.Text) ? "" : "\\")}{addPath}";
          btRegGo_Click(sender, e);
        }
        else
        {
          // call editor
        }
      }
    }

    private void cmRegEditMenu_Opening(object sender, CancelEventArgs e)
    {
      ListViewItem selectedItem = null;
      if (lvRegItems.SelectedItems != null && lvRegItems.SelectedItems.Count == 1)
        selectedItem = lvRegItems.SelectedItems[0];
      if (selectedItem == null || selectedItem.SubItems[0].Text == "..")
      {
        renameToolStripMenuItem.Enabled = false;
        deleteToolStripMenuItem.Enabled = false;
      }
      else
      {
        renameToolStripMenuItem.Enabled = true;
        deleteToolStripMenuItem.Enabled = true;
      }
      if (selectedItem == null || selectedItem.SubItems[1].Text == "REG_KEY")
        modifyToolStripMenuItem.Enabled = false;
      else
        modifyToolStripMenuItem.Enabled = true;
    }

    private void cbRegRootKey_SelectionChangeCommitted(object sender, EventArgs e)
    {
      tbRegPath.Text = "";
    }
  }
}
