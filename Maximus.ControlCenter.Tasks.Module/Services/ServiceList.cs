using Maximus.Library.DataItemCollection;

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  [XmlRoot("ServiceList")]
  public class ServiceList : SerializationData
  {
    [XmlArray]
    public List<ServiceInfo> Services { get; set; }
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
  }
}
