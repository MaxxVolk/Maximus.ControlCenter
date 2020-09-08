using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.ConsoleFramework;
using Microsoft.EnterpriseManagement.Mom.Internal.UI;
using Microsoft.EnterpriseManagement.Mom.UI;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;

// This file contains code related to instance/entity properties context menu/tasks and dialog.

namespace Maximus.ControlCenter.UI.Control
{
  public partial class ControlCenter
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void AddContextMenu_InstanceProperties(ContextMenuHelper contextMenu)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      contextMenu.AddContextMenuItem(ViewCommands.Properties, new EventHandler<CommandEventArgs>(OnShowInstanceProperties), new EventHandler<CommandStatusEventArgs>(OnInstancePropertiesStatus));
    }

    private void OnInstancePropertiesStatus(object sender, CommandStatusEventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      if (SelectedItem is PartialMonitoringObject)
        e.CommandStatus.Enabled = true;
    }

    private void OnShowInstanceProperties(object sender, CommandEventArgs e)
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      InstancePropertiesDialog propertiesDialog = new InstancePropertiesDialog();
      Site.Container.Add(propertiesDialog);
      if (SelectedItem is PartialMonitoringObject pmo)
      {
        var mo = ManagementGroup.EntityObjects.GetObject<MonitoringObject>(pmo.Id, ObjectQueryOptions.Default);
        propertiesDialog.Entity = mo;
        propertiesDialog.Type = mo.GetMostDerivedClasses().FirstOrDefault() ?? ManagementGroup.EntityTypes.GetClass(new Guid("ea99500d-8d52-fc52-b5a5-10dcd1e9d2bd")); // Microsoft.Windows.Computer
        propertiesDialog.ShowDialog();
      }
    }
  }
}
