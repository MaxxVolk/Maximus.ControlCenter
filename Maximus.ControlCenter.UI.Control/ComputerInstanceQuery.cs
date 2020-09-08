using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Cache;
using Microsoft.EnterpriseManagement.Monitoring;

namespace Maximus.ControlCenter.UI.Control
{
  public class ComputerInstanceQuery : Query<ComputerInstance>
  {
    public ComputerInstanceQuery()
    {
      Grouped = false;
      //PropertyTranslator = new ComputerInstancePropertyTranslator();
      FullUpdate = true;
    }

    protected override ICollection<ComputerInstance> DoQuery(string criteria)
    {
      if (ManagementGroup == null || !ManagementGroup.IsConnected)
      {
        Dbg.Log("ComputerInstanceQuery - DoQuery - Management Group is not connected.");
        return null;
      }

      ManagementPackClass windowsComputerCalss = ManagementGroup.EntityTypes.GetClass(new Guid("ea99500d-8d52-fc52-b5a5-10dcd1e9d2bd")); // Microsoft.Windows.Computer
      if (string.IsNullOrEmpty(criteria))
      {
        Collection<ComputerInstance> result = new Collection<ComputerInstance>();
        foreach (MonitoringObject wc in ManagementGroup.EntityObjects.GetObjectReader<MonitoringObject>(windowsComputerCalss, ObjectQueryOptions.Default))
        {
          result.Add(new ComputerInstance(wc));
        }
        Dbg.Log($"ComputerInstanceQuery - DoQuery - Returning {result.Count} instances from no criteria search.");
        return result;
      }
      else
      {
        Collection<ComputerInstance> result = new Collection<ComputerInstance>();
        foreach (MonitoringObject wc in ManagementGroup.EntityObjects.GetObjectReader<MonitoringObject>(new EnterpriseManagementObjectCriteria(criteria, windowsComputerCalss), ObjectQueryOptions.Default))
        {
          result.Add(new ComputerInstance(wc));
        }
        Dbg.Log($"ComputerInstanceQuery - DoQuery - Returning {result.Count} instances from criteria search.");
        return result;
      }
    }

    // protected override void OnPostDeserialization(ComputerInstance data) => data.Reconnect(ManagementGroup);

    protected override Guid GetId(ComputerInstance data) => data.Id;
  }
}
