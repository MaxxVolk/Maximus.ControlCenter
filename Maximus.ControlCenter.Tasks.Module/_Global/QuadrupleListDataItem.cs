using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

using Maximus.Library.DataItemCollection;
#if CONSOLE
#else
using Microsoft.EnterpriseManagement.HealthService;
#endif

namespace Maximus.ControlCenter.Tasks.Module
{
#if CONSOLE
#else
  [MonitoringDataType]
#endif
  public class QuadrupleListDataItem : SerializationDataContainerDataItemBase<QuadrupleList>
  {
    public QuadrupleListDataItem(QuadrupleList data) : base(data)
    {
    }

    public QuadrupleListDataItem(XmlReader reader) : base(reader)
    {
    }

#if CONSOLE
#else
    protected override string GetDataItemTypeName() => "Maximus.ControlCenter.QuadrupleListDataItem";
#endif
  }

  [XmlRoot("QuadrupleList")]
  public class QuadrupleList : SerializationData
  {
    [XmlArray]
    public List<Quadruple> List { get; set; }
  }

  public class Quadruple
  {
    public string I1 { get; set; }
    public string I2 { get; set; }
    public string I3 { get; set; }
    public string I4 { get; set; }
  }
}
