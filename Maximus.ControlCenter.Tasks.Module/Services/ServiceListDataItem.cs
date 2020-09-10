using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Maximus.Library.DataItemCollection;
using Microsoft.EnterpriseManagement.HealthService;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  [MonitoringDataType]
  public class ServiceListDataItem : SerializationDataContainerDataItemBase<ServiceList>
  {
    public ServiceListDataItem(ServiceList data) : base(data)
    {
    }

    public ServiceListDataItem(XmlReader reader) : base(reader)
    {
    }

    protected override string GetDataItemTypeName() => "Maximus.ControlCenter.Services.ServiceListDataItem";
  }
}
