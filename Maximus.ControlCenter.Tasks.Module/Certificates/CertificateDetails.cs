using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.ControlCenter.Tasks.Module.Certificates
{
  public class CertificateDetails
  {
    public string Thumbprint { get; set; }
    public string Subject { get; set; }
    public bool Archived { get; set; }
    public string FriendlyName { get; set; }
    public DateTime NotAfter { get; set; }
    public DateTime NotBefore { get; set; }
    public bool HasPrivateKey { get; set; }
    public string SerialNumber { get; set; }
    public string Issuer { get; set; }
    public string EnhancedKeyUsageList { get; set; }
    public string SignatureAlgorithm { get; set; }
    public string[] Bindings { get; set; }
    public string BindingsList
    {
      get
      {
        string r = "";
        if (Bindings == null || Bindings.Length == 0)
          return r;
        foreach (string b in Bindings)
          r += b + "; ";
        return r;
      }
    }
    public string CertificateType { get; set; }
  }
}
