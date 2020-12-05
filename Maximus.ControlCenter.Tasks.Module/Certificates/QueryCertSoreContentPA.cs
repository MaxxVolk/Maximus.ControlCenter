using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.Library.Helpers;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;
using Microsoft.Win32;

namespace Maximus.ControlCenter.Tasks.Module.Certificates
{
  [MonitoringModule(ModuleType.ReadAction)]
  [ModuleOutput(true)]
  internal class QueryCertSoreContentPA : ModuleBaseSimpleAction<CertStoreDataItem>
  {
    private string StoreNameParam;

    public QueryCertSoreContentPA(ModuleHost<CertStoreDataItem> moduleHost, XmlReader configuration, byte[] previousState) : base(moduleHost, configuration, previousState)
    {
    }

    protected override void PreInitialize(ModuleHost<CertStoreDataItem> moduleHost, XmlReader configuration, byte[] previousState)
    {
      ModInit.Logger.AddLoggingSource(GetType(), ModInit.evtId_QueryCertSoreContentPA);
      base.PreInitialize(moduleHost, configuration, previousState);
    }

    protected override CertStoreDataItem[] GetOutputData(DataItemBase[] inputDataItems)
    {
      X509Store localMachineStore = null;
      try
      {
        localMachineStore = CertificateHelper.GetStore(StoreNameParam);

        if (localMachineStore == null)
          return null;

        localMachineStore.Open(OpenFlags.IncludeArchived | OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
        CertStoreContent result = new CertStoreContent { StoreName = localMachineStore.Name };
        List<CertificateDetails> subResult = new List<CertificateDetails>();
        foreach (X509Certificate2 cert in localMachineStore.Certificates)
        {
          subResult.Add(new CertificateDetails
          {
            Archived = cert.Archived,
            Bindings = GetCertificateBindings(cert),
            EnhancedKeyUsageList = GetCertificateUsages(cert),
            FriendlyName = cert.FriendlyName ?? "",
            HasPrivateKey = cert.HasPrivateKey,
            Issuer = cert.Issuer,
            NotAfter = cert.NotAfter,
            NotBefore = cert.NotBefore,
            SerialNumber = cert.SerialNumber,
            SignatureAlgorithm = cert.SignatureAlgorithm.FriendlyName,
            Subject = cert.Subject,
            Thumbprint = cert.Thumbprint,
            CertificateType = CertificateHelper.GetCertificateType(cert).ToString()
          });
        }

        result.Certificates = subResult.ToArray();
        return new CertStoreDataItem[] { new CertStoreDataItem(result) };
      }
      catch (Exception e)
      {
        ModuleErrorSignalReceiver(ModuleErrorSeverity.DataLoss, ModuleErrorCriticality.Continue, e, "Failed to query local certificate store.");
        return new CertStoreDataItem[]
        {
          new CertStoreDataItem(new CertStoreContent
          {
            Certificates = new CertificateDetails[0],
            ErrorCode = e.HResult != 0 ? e.HResult : -1,
            ErrorMessage= $"Failed to query certificate store: {e.Message}"
          })
        };
      }
      finally
      {
        try { localMachineStore?.Close(); } catch { }
      }
    }

    private static string GetCertificateUsages(X509Certificate2 cert)
    {
      string result = "";
      if (cert.Extensions != null)
        foreach (X509Extension extension in cert.Extensions)
        {
          if (extension is X509EnhancedKeyUsageExtension enhancedKeyUsageExtension)
            foreach (Oid usage in enhancedKeyUsageExtension.EnhancedKeyUsages)
              result += usage.FriendlyName + "; ";
          if (extension is X509KeyUsageExtension keyUsageExtension)
            foreach (X509KeyUsageFlags usage in Enum.GetValues(typeof(X509KeyUsageFlags)))
              if (keyUsageExtension.KeyUsages.HasFlag(usage))
                result += usage.ToString() + "; ";
        }

      return result;
    }

    private static string[] GetCertificateBindings(X509Certificate2 cert)
    {
      List<string> result = new List<string>();

      #region SCOM
      const string channelCertificateSerialNumber = @"HKLM\SOFTWARE\Microsoft\Microsoft Operations Manager\3.0\Machine Settings\ChannelCertificateSerialNumber";
      if (RegistryHelper.RegistryValueExists(".", channelCertificateSerialNumber))
      {
        byte[] certSN = (byte[])RegistryHelper.ReadRegistryValue(".", channelCertificateSerialNumber);
        Array.Reverse(certSN);
        string certSNStr = BitConverter.ToString(certSN).Replace("-", string.Empty);
        if (cert.SerialNumber.ToUpperInvariant() == certSNStr.ToUpperInvariant())
          result.Add("SCOM");
      }
      #endregion

      #region SCCM
      string currentCertThumbprint = null;
      DataTable clientIdentity;
      try
      {
        clientIdentity = ComputerHelper.GetQueryWMI(".", "SELECT * FROM CCM_ClientIdentificationInformation", "\\root\\ccm");
      }
      catch
      {
        clientIdentity = null;
      }

      if (clientIdentity != null && clientIdentity.Rows.Count > 0)
        currentCertThumbprint = clientIdentity.Rows[0]["ReservedString1"].ToString();
      if (currentCertThumbprint != null && currentCertThumbprint.ToUpperInvariant() == cert.Thumbprint.ToUpperInvariant())
        result.Add("SCCM");
      #endregion

      #region HTTP
      try
      {
        RegistryKey bindingsKey = RegistryHelper.GetRegistryKey(".", @"HKLM\SYSTEM\CurrentControlSet\Services\HTTP\Parameters\SslBindingInfo");
        foreach (string subKeyName in bindingsKey.GetSubKeyNames())
        {
          RegistryKey portBindingKey = bindingsKey.OpenSubKey(subKeyName, false);
          byte[] certHash = (byte[])portBindingKey.GetValue("SslCertHash");
          string certHashStr = BitConverter.ToString(certHash).Replace("-", string.Empty);
          if (cert.Thumbprint.ToUpperInvariant() == certHashStr.ToUpperInvariant())
          {
            result.Add("HTTP");
            break;
          }
        }
      }
      catch { }
      #endregion

      return result.ToArray();
    }

    protected override void LoadConfiguration(XmlDocument xmlDoc)
    {
      /*
       * <xsd:element minOccurs="1" name="StoreName" type="xsd:string" />
       */
      try
      {
        LoadConfigurationElement(xmlDoc, "StoreName", out StoreNameParam);
      }
      catch (Exception e)
      {
        ModuleErrorSignalReceiver(ModuleErrorSeverity.FatalError, ModuleErrorCriticality.Stop, e, "Failed to load module configuration.");
        throw new ModuleException("Failed to load module configuration.", e);
      }
    }

    protected override void ModuleErrorSignalReceiver(ModuleErrorSeverity severity, ModuleErrorCriticality criticality, Exception e, string message, params object[] extaInfo)
    {
      ModInit.ModuleErrorSignalReceiver(severity, criticality, e, message, this);
    }
  }
}
