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

namespace Maximus.ControlCenter.UI.Control
{
  public partial class TasksTabView : CachedDetailView<PartialMonitoringObject>, IDisposable
  {
    private ManagementPackClass healthServiceClass = null;
    private string currentSelectedObjectName = "";

    public TasksTabView()
    {
      Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

      InitializeComponent();
    }

    public override string ViewName
    {
      get
      {
        Dbg.Log($"Entering {MethodBase.GetCurrentMethod().Name}");

        return $"Control Panel: {currentSelectedObjectName}";
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
      // Microsoft.SystemCenter.HealthService = ab4c891f-3359-3fb6-0704-075fbfe36710
      healthServiceClass = healthServiceClass ?? ManagementGroup.EntityTypes.GetClass(Guid.Parse("ab4c891f-3359-3fb6-0704-075fbfe36710"));
      IList<PartialMonitoringObject> healthServiceInstance = ManagementGroup.EntityObjects.GetRelatedObjects<PartialMonitoringObject>(monitoringObjectContext.Id, healthServiceClass, TraversalDepth.OneLevel, ObjectQueryOptions.Default);
      if (!healthServiceInstance.Any())
      {
        ShowStatusMessage("This is cluster object or agent-less monitored computer. Select agent-based monitoring computer to show Control Panel.", false);
        return;
      }

      HideStatusMessage();


    }
  }
}
