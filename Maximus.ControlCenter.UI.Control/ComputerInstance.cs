using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Cache;
using Microsoft.EnterpriseManagement.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.ControlCenter.UI.Control
{
  [Serializable]
  public class ComputerInstance : IPropertySet
  {
    [NonSerialized]
    private static object MonitoringLockObject = new object();
    public MonitoringObject WindowsComputerObject { get; protected set; }

    public ComputerInstance(MonitoringObject mo)
    {
      WindowsComputerObject = mo;
    }

    public object GetProperty(string propertyName)
    {
      throw new NotImplementedException();
    }

    public string DisplayName => WindowsComputerObject.DisplayName;
    public HealthAndAvailability Health => CombineHealthAndAvailability(WindowsComputerObject.HealthState, WindowsComputerObject.IsAvailable);
    public bool InMaintenanceMode => WindowsComputerObject.InMaintenanceMode;
    public string Path => WindowsComputerObject.Path;
    public Guid Id => WindowsComputerObject.Id;

    private static HealthAndAvailability CombineHealthAndAvailability(HealthState healthState, bool isAvailable)
    {
      HealthAndAvailability healthAndAvailability = HealthAndAvailability.SuccessAvailable;
      switch (healthState)
      {
        case HealthState.Uninitialized:
          healthAndAvailability = isAvailable ? HealthAndAvailability.UninitializedAvailable : HealthAndAvailability.UninitializedUnavailable;
          break;
        case HealthState.Success:
          healthAndAvailability = isAvailable ? HealthAndAvailability.SuccessAvailable : HealthAndAvailability.SuccessUnavailable;
          break;
        case HealthState.Warning:
          healthAndAvailability = isAvailable ? HealthAndAvailability.WarningAvailable : HealthAndAvailability.WarningUnavailable;
          break;
        case HealthState.Error:
          healthAndAvailability = isAvailable ? HealthAndAvailability.ErrorAvailable : HealthAndAvailability.ErrorUnavailable;
          break;
      }
      return healthAndAvailability;
    }
  }
}
