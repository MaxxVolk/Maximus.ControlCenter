using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Maximus.Library.DataItemCollection;

namespace Maximus.ControlCenter.Tasks.Module.Events
{
  [XmlRoot("EventList")]
  public class EventList : SerializationData
  {
    [XmlArray]
    public List<EventInfo> Events { get; set; }
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
  }
}
