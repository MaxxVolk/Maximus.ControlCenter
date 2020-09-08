using Microsoft.EnterpriseManagement.ConsoleFramework;
using Microsoft.EnterpriseManagement.Mom.Internal.UI;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Cache;
using Microsoft.EnterpriseManagement.Mom.UI;

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

// This file contains code related to personalization and view's own properties (don't be confused with item properties) function.

namespace Maximus.ControlCenter.UI.Control
{
  public partial class ControlCenter
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void AddContextMenu_Personalization(ContextMenuHelper contextMenu)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      contextMenu.AddContextMenuItem(ViewCommands.Personalize, new EventHandler<CommandEventArgs>(OnShowPersonalization), new EventHandler<CommandStatusEventArgs>(OnPersonalizationStatus));

      // Ensure that the component is registered to receive commands and command statuses updates.
      RegisteredCommand registeredCommand = ((ICommandService)Site.GetService(typeof(ICommandService))).Find(ViewCommands.ViewProperties);
      if (!registeredCommand.ComponentIsRegistered(this))
      {
        // Methods OnViewPropertiesCommand and UpdateViewPropertiesCommandStatus are defined in the MomViewBase class
        registeredCommand.Register(new EventHandler<CommandEventArgs>(OnShowViewProperties));
        registeredCommand.RegisterStatusNotification(new EventHandler<CommandStatusEventArgs>(OnViewPropertiesStatus));
      }
    }

    private void OnViewPropertiesStatus(object sender, CommandStatusEventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      UpdateViewPropertiesCommandStatus(sender, e);
    }

    private void OnShowViewProperties(object sender, CommandEventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      OnViewPropertiesCommand(sender, e);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void AddActions_Personalization()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      AddTaskItem(TaskCommands.ActionsTaskGroup, ViewCommands.Personalize);
    }

    private void OnPersonalizationStatus(object sender, CommandStatusEventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      e.CommandStatus.Enabled = true;
    }

    private void OnShowPersonalization(object sender, CommandEventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      ShowPersonalization(sender, e);
    }

    protected override void ApplyPersonalization()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (ColumnCollection != null)
      {
        ColumnCollection.Apply(Grid);
      }
      else
      {
        if (Configuration == null)
          return;
        ColumnCollection = ViewSupport.XmlToColumnInfoCollection(Configuration.Presentation);
        ColumnCollection.Apply(Grid);
      }
    }

    private void UpdatePersonalizeCommandStatus(object sender, CommandStatusEventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      e.CommandStatus.Enabled = true;
    }

    protected override void ShowPersonalization(object sender, CommandEventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      string defaultPersonalization = null;
      if (Configuration != null && Configuration.Presentation != null)
        defaultPersonalization = Configuration.Presentation;

      using (ColumnPickerDialog columnPickerDialog = new ColumnPickerDialog(defaultPersonalization))
      {
        columnPickerDialog.Grid = Grid;
        columnPickerDialog.Groupable = false;
        if (columnPickerDialog.ShowDialog(ParentWindow) != DialogResult.OK)
          return;
        ColumnCollection = new ColumnInfoCollection(columnPickerDialog.GetColumns());
        UpdateFields(true);
        SavePersonalization(this);
      }
    }

    protected override void UpdateViewPropertiesCommandStatus(object sender, CommandStatusEventArgs args)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      args.CommandStatus.Enabled = true;
      args.CommandStatus.Visible = true;
    }

    // Properties of the view itself. I.e. when right-clicked at the view node in the navigation tree.
    protected override void OnViewPropertiesCommand(object sender, CommandEventArgs args)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      ViewConfiguration viewConfiguration = ViewSupport.ViewEditDialog(Site, View, SystemView.State);
      Tag = viewConfiguration;
      if (viewConfiguration == null)
        return;
      Configuration.Configuration = viewConfiguration.Configuration;
      Personalization = ViewSupport.XmlToColumnInfoCollection(Configuration.Presentation);
      SavePersonalization(this);
      if (QueryCache == null)
        return;
      QueryCache.SetCriteria(GetQueryCriteria());
      UpdateCache(UpdateReason.Refresh);
    }
  }
}
