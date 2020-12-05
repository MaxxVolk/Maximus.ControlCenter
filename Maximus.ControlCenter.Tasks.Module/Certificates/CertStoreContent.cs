using System.Xml.Serialization;

using Maximus.Library.DataItemCollection;

namespace Maximus.ControlCenter.Tasks.Module.Certificates
{
  [XmlRoot("CertStoreContent")]
  public class CertStoreContent : SerializationData
  {
    public string StoreName { get; set; }
    [XmlArray]
    public CertificateDetails[] Certificates { get; set; }
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
  }
}
