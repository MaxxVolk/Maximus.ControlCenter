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
      lvRegItems.Items.Clear();
      tbRegPath.Text = "";
      cbRegRootKey.SelectedIndex = 1;
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

    private DataTable PrepareServiceTable(ServiceListDataItem serviceDataItem)
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

      foreach (ServiceInfo serviceInfo in serviceDataItem.Data.Services)
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
        EventListDataItem eventListResult = DeserializeDataItemFromTaskResults<EventListDataItem, EventList>(results, (xmlReader) => new EventListDataItem(xmlReader));
        if (eventListResult != null && eventListResult.Data.ErrorCode == 0)
        {
          ClearEventDisplayElements();
          DataTable table = PrepareEventTable(eventListResult);
          BindingSource bs = new BindingSource() { DataSource = table };
          dgvEventsMain.DataSource = bs;
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
        else
        {
          dgvEventsMain.DataSource = null;
          if (eventListResult != null && eventListResult.Data.ErrorCode != 0)
            MessageBox.Show($"Failed to query event log.\r\nError message: {eventListResult.Data.ErrorMessage ?? "Not provided."}", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        queryDialog.EventLogList.Clear();
        foreach (object item in cbEventSelectLog.Items)
          queryDialog.EventLogList.Add(item);
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
        case "Error": dgvEventsMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink; break;
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
          if (regReadResult.Data.List.Any() && regReadResult.Data.List[0].I1 == "@Error")
          {
            MessageBox.Show($"Registry navigation task failed.\r\nError message: {regReadResult.Data.List[0].I3}", "Task failure.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }
          lvRegItems.Items.Add(new ListViewItem(new string[] { "..", "REG_KEY", "" }, GetRegImageIndex("REG_KEY")));
          foreach (Quadruple item in regReadResult.Data.List)
            lvRegItems.Items.Add(new ListViewItem(new string[] { item.I1, item.I2, item.I3 }, GetRegImageIndex(item.I2))).Name = item.I1 + item.I2;
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

      if (lvRegItems.SelectedItems != null && lvRegItems.SelectedItems.Count == 1)
      {
        ListViewItem selectedItem = lvRegItems.SelectedItems[0];
        Dbg.Log($"Subitem count: {selectedItem.SubItems.Count}; [0]: {selectedItem.SubItems[0].Text}");
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

    private void keyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (RegistryEditForm dialog = new RegistryEditForm())
      {
        dialog.FormMode = RegistryEditFormMode.NewName;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          SubmitTaskAsync(WriteRegistryElementTaskId, ManagementObject,
            new Dictionary<string, string>
            {
              { "KeyPath", $"{cbRegRootKey.SelectedItem}\\{tbRegPath.Text}" },
              { "Action", ((int)WriteRegistryElementAction.CreateKey).ToString() },
              { "NewName", dialog.NewName }
            }, new OnTaskStatusChangeDelegate(OnWriteRegistryElementTaskChange));
        }
      }

    }

    private void OnWriteRegistryElementTaskChange(IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results, bool lastUpdate)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      try
      {
        QuadrupleListDataItem regReadResult = DeserializeDataItemFromTaskResults<QuadrupleListDataItem, QuadrupleList>(results, (xmlReader) => new QuadrupleListDataItem(xmlReader));
        if (regReadResult?.Data?.List != null && regReadResult.Data.List.Count >= 1)
        {
          if (regReadResult.Data.List[0].I1 == "@Error")
            MessageBox.Show(regReadResult.Data.List[0].I3, "Task Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
          else
          {
            btRegGo_Click(this, null);
            //string key = regReadResult.Data.List[0].I1 + regReadResult.Data.List[0].I2;
            //if (lvRegItems.Items.ContainsKey(key))
            //  lvRegItems.Items.RemoveByKey(key);
            //lvRegItems.Items.Add(new ListViewItem(new string[] { regReadResult.Data.List[0].I1, regReadResult.Data.List[0].I2, regReadResult.Data.List[0].I3 }, GetRegImageIndex(regReadResult.Data.List[0].I2)));
          }
        }
      }
      catch (Exception e)
      {
        Dbg.Log($"Exception {e.Message} in {MethodBase.GetCurrentMethod().Name}");
      }
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}; Selected items count: {lvRegItems.SelectedItems?.Count ?? -1}");

      if (lvRegItems.SelectedItems != null && lvRegItems.SelectedItems.Count == 1)
      {
        ListViewItem selectedItem = lvRegItems.SelectedItems[0];
        if (selectedItem.SubItems[1].Text == "REG_KEY")
        {
          string addPath = selectedItem.SubItems[0].Text;
          if (addPath == "..")
            return;
          SubmitTaskAsync(WriteRegistryElementTaskId, ManagementObject,
            new Dictionary<string, string>
            {
              { "KeyPath", $"{cbRegRootKey.SelectedItem}\\{tbRegPath.Text}" },
              { "Action", ((int)WriteRegistryElementAction.DeleteKey).ToString() },
              { "OldName", addPath }
            }, new OnTaskStatusChangeDelegate(OnWriteRegistryElementTaskChange));
        }
        else
        {
          string addPath = selectedItem.SubItems[0].Text;
          SubmitTaskAsync(WriteRegistryElementTaskId, ManagementObject,
            new Dictionary<string, string>
            {
              { "KeyPath", $"{cbRegRootKey.SelectedItem}\\{tbRegPath.Text}" },
              { "Action", ((int)WriteRegistryElementAction.DeleteValue).ToString() },
              { "OldName", addPath }
            }, new OnTaskStatusChangeDelegate(OnWriteRegistryElementTaskChange));
        }
      }
    }

    private void renameToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}; Selected items count: {lvRegItems.SelectedItems?.Count ?? -1}");

      if (lvRegItems.SelectedItems != null && lvRegItems.SelectedItems.Count == 1)
      {
        ListViewItem selectedItem = lvRegItems.SelectedItems[0];
        if (selectedItem.SubItems[1].Text == "REG_KEY")
        {
          string keyName = selectedItem.SubItems[0].Text;
          if (keyName == "..")
            return;
          using (RegistryEditForm dialog = new RegistryEditForm())
          {
            dialog.FormMode = RegistryEditFormMode.NewName;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
              SubmitTaskAsync(WriteRegistryElementTaskId, ManagementObject,
                new Dictionary<string, string>
                {
                  { "KeyPath", $"{cbRegRootKey.SelectedItem}\\{tbRegPath.Text}" },
                  { "Action", ((int)WriteRegistryElementAction.RenameKey).ToString() },
                  { "OldName", keyName },
                  { "NewName", dialog.NewName }
                }, new OnTaskStatusChangeDelegate(OnWriteRegistryElementTaskChange));
            }
          }
        }
        else
        {
          using (RegistryEditForm dialog = new RegistryEditForm())
          {
            dialog.FormMode = RegistryEditFormMode.NewName;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
              string valueName = selectedItem.SubItems[0].Text;
              SubmitTaskAsync(WriteRegistryElementTaskId, ManagementObject,
                new Dictionary<string, string>
                {
                  { "KeyPath", $"{cbRegRootKey.SelectedItem}\\{tbRegPath.Text}" },
                  { "Action", ((int)WriteRegistryElementAction.RenameValue).ToString() },
                  { "OldName", valueName },
                  { "NewName", dialog.NewName }
                }, new OnTaskStatusChangeDelegate(OnWriteRegistryElementTaskChange));
            }
          }
        }
      }

    }

    private void StartNewRegValueTask(Microsoft.Win32.RegistryValueKind valueKind, string valueName, string valueSerialized)
    {
      SubmitTaskAsync(WriteRegistryElementTaskId, ManagementObject,
        new Dictionary<string, string>
        {
          { "KeyPath", $"{cbRegRootKey.SelectedItem}\\{tbRegPath.Text}" },
          { "Action", ((int)WriteRegistryElementAction.SetValue).ToString() },
          { "OldName", valueName },
          { "NewValue", valueSerialized },
          { "ValueType", RegistryValueKindToREG(valueKind) }
        }, new OnTaskStatusChangeDelegate(OnWriteRegistryElementTaskChange));
    }

    private string RegistryValueKindToREG(Microsoft.Win32.RegistryValueKind valueKind)
    {
      switch (valueKind)
      {
        case Microsoft.Win32.RegistryValueKind.DWord: return "REG_DWORD";
        case Microsoft.Win32.RegistryValueKind.QWord:return "REG_QWORD";
        case Microsoft.Win32.RegistryValueKind.String: return "REG_SZ";
        case Microsoft.Win32.RegistryValueKind.ExpandString: return "REG_EXPAND_SZ";
        case Microsoft.Win32.RegistryValueKind.Binary: return "REG_BINARY";
        case Microsoft.Win32.RegistryValueKind.MultiString: return "REG_MULTI_SZ";
      }
      return "REG_UNKNOWN";
    }

    private static Microsoft.Win32.RegistryValueKind GetRegistryValueKind(string regTypeStr)
    {
      switch (regTypeStr)
      {
        case "REG_SZ": return Microsoft.Win32.RegistryValueKind.String;
        case "REG_EXPAND_SZ": return Microsoft.Win32.RegistryValueKind.ExpandString;
        case "REG_BINARY": return Microsoft.Win32.RegistryValueKind.Binary;
        case "REG_DWORD": return Microsoft.Win32.RegistryValueKind.DWord;
        case "REG_MULTI_SZ": return Microsoft.Win32.RegistryValueKind.MultiString;
        case "REG_QWORD": return Microsoft.Win32.RegistryValueKind.QWord;
      }
      return Microsoft.Win32.RegistryValueKind.Unknown;
    }

    private string searchExpression = "";
    private DateTime searchExpressionUpdate = DateTime.Now;

    private void dgvServices_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        ShowServiceDetails((DataRowView)dgvServices.CurrentRow.DataBoundItem);
        e.Handled = true;
        e.SuppressKeyPress = true;
      }
      if (char.IsLetterOrDigit((char)e.KeyData))
      {
        if (DateTime.Now.Subtract(searchExpressionUpdate).TotalMilliseconds > 500)
          searchExpression = $"{(char)e.KeyData}";
        else
          searchExpression += (char)e.KeyData;
        searchExpression = searchExpression.ToLowerInvariant();
        searchExpressionUpdate = DateTime.Now;
        foreach (DataGridViewRow row in dgvServices.Rows)
          if (((DataRowView)row.DataBoundItem)["DisplayName"]?.ToString().ToLowerInvariant().StartsWith(searchExpression) == true)
          {
            dgvServices.Rows[row.Index].Selected = true;
            dgvServices.CurrentCell = dgvServices.Rows[row.Index].Cells[0];
            break;
          }
      }
    }

    private void dgvServices_KeyPress(object sender, KeyPressEventArgs e)
    {

    }

    private void dgvServices_SelectionChanged(object sender, EventArgs e)
    {

    }

    private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (lvRegItems.SelectedItems == null || lvRegItems.SelectedItems.Count == 0)
        return;
      ListViewItem currentRegItem = lvRegItems.SelectedItems[0];
      using (RegistryEditForm dialog = new RegistryEditForm())
      {
        dialog.FormMode = RegistryEditFormMode.EditValue;
        dialog.NewName = currentRegItem.SubItems[0].Text;
        dialog.ValueKind = GetRegistryValueKind(currentRegItem.SubItems[1].Text);
        dialog.Value = currentRegItem.SubItems[2].Text;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          SubmitTaskAsync(WriteRegistryElementTaskId, ManagementObject,
            new Dictionary<string, string>
            {
              { "KeyPath", $"{cbRegRootKey.SelectedItem}\\{tbRegPath.Text}" },
              { "Action", ((int)WriteRegistryElementAction.SetValue).ToString() },
              { "OldName", currentRegItem.SubItems[0].Text }, // use original
              { "NewValue", dialog.Value },
              { "ValueType", currentRegItem.SubItems[1].Text } // use original
        }, new OnTaskStatusChangeDelegate(OnWriteRegistryElementTaskChange));
        }  
      }
    }

    #region New Reg Values
    private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (RegistryEditForm dialog = new RegistryEditForm())
      {
        dialog.FormMode = RegistryEditFormMode.NewValue;
        dialog.ValueKind = Microsoft.Win32.RegistryValueKind.Binary;
        if (dialog.ShowDialog() == DialogResult.OK)
          StartNewRegValueTask(Microsoft.Win32.RegistryValueKind.String, dialog.NewName, dialog.Value);
      }
    }

    private void stringToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (RegistryEditForm dialog = new RegistryEditForm())
      {
        dialog.FormMode = RegistryEditFormMode.NewValue;
        dialog.ValueKind = Microsoft.Win32.RegistryValueKind.String;
        if (dialog.ShowDialog() == DialogResult.OK)
          StartNewRegValueTask(Microsoft.Win32.RegistryValueKind.String, dialog.NewName, dialog.Value);
      }
    }

    private void dWORDToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (RegistryEditForm dialog = new RegistryEditForm())
      {
        dialog.FormMode = RegistryEditFormMode.NewValue;
        dialog.ValueKind = Microsoft.Win32.RegistryValueKind.DWord;
        if (dialog.ShowDialog() == DialogResult.OK)
          StartNewRegValueTask(Microsoft.Win32.RegistryValueKind.DWord, dialog.NewName, dialog.Value);
      }
    }

    private void qWORDToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (RegistryEditForm dialog = new RegistryEditForm())
      {
        dialog.FormMode = RegistryEditFormMode.NewValue;
        dialog.ValueKind = Microsoft.Win32.RegistryValueKind.QWord;
        if (dialog.ShowDialog() == DialogResult.OK)
          StartNewRegValueTask(Microsoft.Win32.RegistryValueKind.QWord, dialog.NewName, dialog.Value);
      }
    }

    private void multiStringValueToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (RegistryEditForm dialog = new RegistryEditForm())
      {
        dialog.FormMode = RegistryEditFormMode.NewValue;
        dialog.ValueKind = Microsoft.Win32.RegistryValueKind.MultiString;
        if (dialog.ShowDialog() == DialogResult.OK)
          StartNewRegValueTask(Microsoft.Win32.RegistryValueKind.MultiString, dialog.NewName, dialog.Value);
      }
    }

    private void expandableStringValueToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (RegistryEditForm dialog = new RegistryEditForm())
      {
        dialog.FormMode = RegistryEditFormMode.NewValue;
        dialog.ValueKind = Microsoft.Win32.RegistryValueKind.ExpandString;
        if (dialog.ShowDialog() == DialogResult.OK)
          StartNewRegValueTask(Microsoft.Win32.RegistryValueKind.ExpandString, dialog.NewName, dialog.Value);
      }
    }
    #endregion

  }
}
