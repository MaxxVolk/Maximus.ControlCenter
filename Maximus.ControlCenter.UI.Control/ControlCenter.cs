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
using System.Collections;
using Microsoft.EnterpriseManagement.Mom.UI;
using System.Collections.ObjectModel;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Cache;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration;
using System.Resources;
using System.Threading;
using System.Globalization;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.ConsoleFramework;
using Microsoft.EnterpriseManagement.Common;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;

namespace Maximus.ControlCenter.UI.Control
{
  //public partial class ControlCenter : GridViewBase<ComputerInstance, ComputerInstanceQuery>, IParentView
  public partial class ControlCenter : GridViewBase<InstanceState, StateQuery>, IParentView
  {
    private readonly ResourceManager ConsoleResources;
    private readonly CultureInfo CurrentCulture = Thread.CurrentThread.CurrentUICulture;

    public ControlCenter() : base(new ManagedEntityTargetParser())
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      //if (DesignMode)
      //  return;
      UseRowContextMenu = false; // row context menu is recalculated for each selected item's context
      InitializeComponent();
      Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      ConsoleResources = new ResourceManager("Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources", typeof(UrlView).Assembly);
    }

    public override string ViewName => "Maximus Control Center";

    #region Display
    protected override void AddColumns()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      // Health
      Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      InstanceStateProperty propertyTranslator = PropertyTranslator as InstanceStateProperty;
      GridControlImageTextColumn stateColumn = new GridControlImageTextColumn();
      stateColumn.CellContentsRequested += new EventHandler<GridControlImageTextColumn.ImageTextEventArgs>(StateCellContentsRequested);
      string str = $"{propertyTranslator.TargetType.Name}-*-{propertyTranslator.TargetType.Id}-*-Health";
      AddColumn(stateColumn, ConsoleResources.GetString("State", CurrentCulture), new Field("Health", typeof(int), str, Field.SortInfos.Sortable | Field.SortInfos.Sort, 0), false);

      // Maintenance Mode
      DataGridViewColumn MaintenanceModeColumn = AddColumn(new GridControlImageTextColumn(
        new Dictionary<string, Image>
        {
          { true.ToString(), (Image)ConsoleResources.GetObject("MaintenanceModeImage", CurrentCulture) },
          { false.ToString(), new Bitmap(16, 16) }
        },
        new Dictionary<string, string>
        {
          { true.ToString(), ConsoleResources.GetString("InMaintenanceMode", CurrentCulture) },
          { false.ToString(), ConsoleResources.GetString("NotInMaintenanceMode", CurrentCulture) }
        })
      {
        DefaultKey = string.Empty,
        Width = 22,
        ShowText = false,
        DefaultHeaderCellType = typeof(GridControlImageColumnHeaderCell)
      }, typeof(bool), ConsoleResources.GetString("MaintenanceModeText", CurrentCulture), "InMaintenanceMode", false, false);

      GridControlImageColumnHeaderCell headerCell = (GridControlImageColumnHeaderCell)MaintenanceModeColumn.HeaderCell;
      headerCell.Image = (Image)ConsoleResources.GetObject("MaintenanceModeImage", CurrentCulture);
      headerCell.ImagePadding = new Padding(2);

      AddColumn(new GridControlTextColumn(), typeof(string), "Name", "DisplayName", false, true);

      foreach (ManagementPackProperty property in ManagementGroup.EntityTypes.GetClass(new Guid("ea99500d-8d52-fc52-b5a5-10dcd1e9d2bd")).GetProperties()) // Microsoft.Windows.Computer)
      {
        Dbg.Log($"adding {property.DisplayName}");
        Type type = property.SystemType;
        Type contentType = null;
        if (type == typeof(string) || type == typeof(int))
          contentType = type;
        string headerText = property.DisplayName ?? property.Name;
        if (contentType == null)
        {
          if (type == typeof(Enum))
            type = typeof(string);
          Field sortField = new Field(null, type, property, 0);
          DataGridViewColumn dataGridViewColumn = AddColumn(new GridControlTextColumn(), headerText, sortField, true);
          dataGridViewColumn.Visible = true;
          dataGridViewColumn.FillWeight = 1f;
        }
        else
        {
          DataGridViewColumn dataGridViewColumn = AddColumn(contentType, headerText, property, true);
          dataGridViewColumn.Visible = true;
          dataGridViewColumn.FillWeight = 1f;
        }
      }
    }

    // When right-click at an item in the grid.
    protected override void AddContextMenu(ContextMenuHelper contextMenu)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      //base.AddContextMenu(contextMenu);
      if (contextMenu != null)
      {
        // these methods, OnCopyCommand and UpdateCopyCommandStatus, are defined in GridViewBase
        contextMenu.AddContextMenuItem(StandardCommands.Copy, OnCopyCommand, UpdateCopyCommandStatus); 
        contextMenu.AddContextMenuSeparator();
        AddContextMenu_Personalization(contextMenu);
        contextMenu.AddContextMenuItem(ViewCommands.Refresh, null); // use default handler
        contextMenu.AddContextMenuSeparator();
        AddContextMenu_InstanceProperties(contextMenu);
      }
    }



    protected override void AddActions()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      AddActions_Personalization();
      base.AddActions();
    }

    readonly Dictionary<HealthState, Image> HealthStateImages = new Dictionary<HealthState, Image>()
      {
        { HealthState.Success,       AdminHelpers.StateGreen1Image },
        { HealthState.Warning,       AdminHelpers.StateYellow1Image },
        { HealthState.Error,         AdminHelpers.StateRed1Image },
        { HealthState.Uninitialized, AdminHelpers.StateGray1Image }
      };
    readonly Dictionary<HealthState, string> HealthStrings = new Dictionary<HealthState, string>()
      {
        { HealthState.Success,       AdminHelpers.StateGreen1Text },
        { HealthState.Warning,       AdminHelpers.StateYellow1Text },
        { HealthState.Error,         AdminHelpers.StateRed1Text },
        { HealthState.Uninitialized, AdminHelpers.StateGray1Text },
    };
    #endregion

    #region Command and Context Menu Handlers
    


    #endregion

    private void StateCellContentsRequested(object sender,  GridControlImageTextColumn.ImageTextEventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (e == null || e.DataItem == null || (e.DataItem.DataItem == null || !(e.DataItem.DataItem is InstanceState dataItem)))
        return;
      bool availability = InstanceState.GetAvailability(dataItem.Health);
      HealthState health = InstanceState.GetHealth(dataItem.Health);
      e.Icon = !availability ? HealthStateImages[HealthState.Uninitialized] : HealthStateImages[health];
      e.Text = HealthStrings[health];
    }

    protected override void OnQueryCreated()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      // set Class Type for the query
      QueryCache.Query.ViewTargetType = ManagementGroup.EntityTypes.GetClass(new Guid("ea99500d-8d52-fc52-b5a5-10dcd1e9d2bd")); // Microsoft.Windows.Computer
    }

    #region IParentView Implementation
    public Type ChildViewType => typeof(TasksTabView);

    /// <summary>
    /// This method is called from <code>CachedDetailView<T></code> ParentSelectionChanged method, where the returned object is casted as T.
    /// </summary>
    public object SelectedItem
    {
      get
      {
        Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

        if (Grid == null || Grid.SelectedRows == null || Grid.SelectedRows[0] == null)
          return null;

        if (Grid.SelectedRows[0].Cells[0].Tag is GridDataItem tag)
        {
          InstanceState selectedCellContents = (InstanceState)tag.DataItem;
          //InstanceStateProperty propertyTranslator = (InstanceStateProperty)PropertyTranslator;
          //PartialMonitoringObject partialMonitoringObject = null;
          //ManagementPackClass targetType = propertyTranslator.TargetType;
          //if (targetType != null && targetType.ManagementGroup != null && targetType.ManagementGroup is ManagementGroup managementGroup)
          //  partialMonitoringObject = selectedCellContents.GetCachedPartialMonitoringObject(managementGroup);
          //return partialMonitoringObject;

          return selectedCellContents.GetCachedPartialMonitoringObject(ManagementGroup);
        }
        return null;
      }
    }

    public ICollection GetSelection()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (Grid.SelectedCells.Count == 0)
        return null;
      List<object> result = new List<object>();
      foreach (DataGridViewRow selectedRow in Grid.SelectedRows)
      {
        if (selectedRow.Cells[0].Tag != null)
        {
          InstanceState dataItem = (InstanceState)(selectedRow.Cells[0].Tag as GridDataItem).DataItem;
          if (QueryCache.Query is StateQuery query && query.ManagementGroup != null)
          {
            PartialMonitoringObject monitoringObject = dataItem.GetCachedPartialMonitoringObject(query.ManagementGroup);
            if (monitoringObject != null)
              result.Add(monitoringObject);
          }
        }
      }
      return new ReadOnlyCollection<object>(result);
    }
    #endregion
  }
}
