using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Maximus.Library.DataItemCollection;
#if CONSOLE
#else
using Microsoft.EnterpriseManagement.HealthService;
#endif

namespace Maximus.ControlCenter.Tasks.Module.Events
{
#if CONSOLE
#else
  [MonitoringDataType]
#endif
  public class EventListDataItem : SerializationDataContainerDataItemBase<EventList>
  {
    public EventListDataItem(EventList data) : base(data)
    {
    }

    public EventListDataItem(XmlReader reader) : base(reader)
    {
    }
    protected override string GetDataItemTypeName() => "Maximus.ControlCenter.Services.EventListDataItem";
  }
}
