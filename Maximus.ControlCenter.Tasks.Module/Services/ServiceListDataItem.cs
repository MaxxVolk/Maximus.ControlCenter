using System.Xml;

using Maximus.Library.DataItemCollection;
#if CONSOLE
#else
using Microsoft.EnterpriseManagement.HealthService;
#endif

namespace Maximus.ControlCenter.Tasks.Module.Services
{
#if CONSOLE
#else
  [MonitoringDataType]
#endif
  public class ServiceListDataItem : SerializationDataContainerDataItemBase<ServiceList>
  {
    public ServiceListDataItem(ServiceList data) : base(data)
    {
    }

    public ServiceListDataItem(XmlReader reader) : base(reader)
    {
    }

#if CONSOLE
#else
    protected override string GetDataItemTypeName() => "Maximus.ControlCenter.Services.ServiceListDataItem";
#endif
  }
}
