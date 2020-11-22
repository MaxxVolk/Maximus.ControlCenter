using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;
using Microsoft.EnterpriseManagement.Mom.Modules.DataItems;

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Xml;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  [MonitoringModule(ModuleType.WriteAction)]
  [ModuleOutput(true)]
  class ConfigureServiceWA : ModuleBaseSimpleAction<QuadrupleListDataItem>
  {
    // configuration
    private string QueryService;
    private int ServiceType = -1, StartType = -1, ErrorControl = -1; // SERVICE_NO_CHANGE = 0xFFFFFFFF
    private string BinaryPathName, LoadOrderGroup, Dependencies, ServiceStartName, Password, DisplayName;

    public ConfigureServiceWA(ModuleHost<QuadrupleListDataItem> moduleHost, XmlReader configuration, byte[] previousState) : base(moduleHost, configuration, previousState)
    {

    }

    protected override void PreInitialize(ModuleHost<QuadrupleListDataItem> moduleHost, XmlReader configuration, byte[] previousState)
    {
      ModInit.Logger.AddLoggingSource(GetType(), ModInit.evtId_ConfigureServiceWA);
      base.PreInitialize(moduleHost, configuration, previousState);
    }

    protected override QuadrupleListDataItem[] GetOutputData(DataItemBase[] inputDataItems)
    {
      try
      {
        if (!string.IsNullOrWhiteSpace(Dependencies))
          return CreateResponse("ERROR", "Configuring 'Dependencies' is not supported.", null, null);

        using (ServiceController sc = new ServiceController(QueryService))
        using (SafeHandle serviceHandle = sc.ServiceHandle)
        {
          ModInit.Logger.WriteInformation($"Calling ChangeServiceConfig({QueryService}, {ServiceType}, {StartType}, {ErrorControl}, {BinaryPathName ?? "NULL"})", this);
          if (!Win32Helper.ChangeServiceConfig(
          serviceHandle.DangerousGetHandle(),

          (uint)ServiceType,
          (uint)StartType,
          (uint)ErrorControl,

          string.IsNullOrWhiteSpace(BinaryPathName) ? null: BinaryPathName,
          string.IsNullOrWhiteSpace(LoadOrderGroup) ? null : LoadOrderGroup,
          IntPtr.Zero,
          null, // Dependencies not supported
          string.IsNullOrWhiteSpace(ServiceStartName) ? null : ServiceStartName,
          string.IsNullOrWhiteSpace(Password) ? null : Password,
          string.IsNullOrWhiteSpace(DisplayName) ? null : DisplayName)
          )
          {
            throw new Win32Exception(Marshal.GetLastWin32Error());
          }
        }

        return CreateResponse("OK", "", null, null);
      }
      catch (Exception e)
      {
        return CreateResponse("ERROR", e.Message, null, null);
      }
    }

    private QuadrupleListDataItem[] CreateResponse(string i1, string i2, string i3, string i4)
    {
      return new QuadrupleListDataItem[] { new QuadrupleListDataItem(new QuadrupleList { List = new System.Collections.Generic.List<Quadruple> { new Quadruple { I1 = i1, I2 = i2, I3 = i3, I4 = i4 } } }) };
    }

    protected override void LoadConfiguration(XmlDocument cfgDoc)
    {
      try
      {
        LoadConfigurationElement(cfgDoc, "QueryService", out QueryService);

        LoadConfigurationElement(cfgDoc, "ServiceType", out ServiceType, -1, false);
        LoadConfigurationElement(cfgDoc, "StartType", out StartType, -1, false);
        LoadConfigurationElement(cfgDoc, "ErrorControl", out ErrorControl, -1, false);

        LoadConfigurationElement(cfgDoc, "BinaryPathName", out BinaryPathName, null, false);
        LoadConfigurationElement(cfgDoc, "LoadOrderGroup", out LoadOrderGroup, null, false);
        LoadConfigurationElement(cfgDoc, "Dependencies", out Dependencies, null, false);
        LoadConfigurationElement(cfgDoc, "ServiceStartName", out ServiceStartName, null, false);
        LoadConfigurationElement(cfgDoc, "Password", out Password, null, false);
        LoadConfigurationElement(cfgDoc, "DisplayName", out DisplayName, null, false);
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
