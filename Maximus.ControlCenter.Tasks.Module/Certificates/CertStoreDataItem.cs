using System.Xml;

using Maximus.Library.DataItemCollection;
#if CONSOLE
#else
using Microsoft.EnterpriseManagement.HealthService;
#endif

namespace Maximus.ControlCenter.Tasks.Module.Certificates
{
#if CONSOLE
#else
  [MonitoringDataType]
#endif
  class CertStoreDataItem : SerializationDataContainerDataItemBase<CertStoreContent>
  {
    public CertStoreDataItem(CertStoreContent data) : base(data)
    {
    }

    public CertStoreDataItem(XmlReader reader) : base(reader)
    {
    }

    protected override string GetDataItemTypeName() => "Maximus.ControlCenter.Certificates.CertStoreDataItem";
  }
}
