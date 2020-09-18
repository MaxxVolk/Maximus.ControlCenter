using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  public class ServiceInfo
  {
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public int Start { get; set; }
    public int Type { get; set; }
    [XmlArray]
    public string[] DependOnService { get; set; }
    public string ObjectName { get; set; }
    public string ImagePath { get; set; }
    public bool IsDelayed { get; set; }
    public bool IsTriggered { get; set; }
    public bool IsClustered { get; set; }
    public bool IsClusterOffline { get; set; }
    public string NodeName { get; set; }
    public string Status { get; set; }
    // DO NOT use Dictionary, or any other classes implementing IDictionary in DataItems. 
    // This is because IDictionary cannot be serialized in XML and will throw an exception.
    [XmlArray]
    public List<ServiceParameter> Parameters { get; set; } = new List<ServiceParameter>();
  }

  public class ServiceParameter
  {
    public string Name { get; set; }
    public object Data { get; set; }
    public string RegType { get; set; }
  }
}
