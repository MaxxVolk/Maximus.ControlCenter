using Maximus.Library.DataItemCollection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  [XmlRoot("ServiceList")]
  public class ServiceList : SerializationData
  {
    [XmlArray]
    public List<ServiceInfo> Services { get; set; }
  }
}
