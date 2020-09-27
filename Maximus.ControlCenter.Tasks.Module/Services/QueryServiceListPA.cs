using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.Library.Helpers;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;
using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Management;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Xml;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  [MonitoringModule(ModuleType.ReadAction)]
  [ModuleOutput(true)]
  public class QueryServiceListPA : ModuleBaseSimpleAction<ServiceListDataItem>
  {
    // Configuration
    private bool QueryParameters = false;
    private string QueryService = null;

    // Working data
    readonly bool supportDelayedStart = false;
    readonly bool supportClusteredService = false;

    public QueryServiceListPA(ModuleHost<ServiceListDataItem> moduleHost, XmlReader configuration, byte[] previousState) : base(moduleHost, configuration, previousState)
    {
      if (Environment.OSVersion.Version.Major >= 6) // >= Windows Vista / 2008
      {
        supportDelayedStart = true;
        supportClusteredService = true;
      }
    }

    protected override void PreInitialize(ModuleHost<ServiceListDataItem> moduleHost, XmlReader configuration, byte[] previousState)
    {
      ModInit.Logger.AddLoggingSource(GetType(), ModInit.evtId_QueryServiceListPA);
      base.PreInitialize(moduleHost, configuration, previousState);
    }

    protected override ServiceListDataItem[] GetOutputData(DataItemBase[] inputDataItems)
    {
      try
      {
        string opMessages = "";
        bool IsCluster = false;
        if (supportClusteredService)
          IsCluster = ServiceHelper.IsCluster(".");
        long computerUpTimeMin = 0;
        if (supportDelayedStart)
          computerUpTimeMin = ComputerHelper.GetUptime(".") / 60;

        // get all clustered services and their on-line statuses
        List<ClusteredServiceInfo> clusteredServices = new List<ClusteredServiceInfo>();
        if (IsCluster)
          try
          {
            using (WMIQuery query = new WMIQuery(new ManagementScope("\\\\.\\root\\MSCluster"), "SELECT * FROM MSCluster_Resource"))
            {
              foreach (ManagementBaseObject serviceData in query.Select())
              {
                if (serviceData["Type"].ToString() != "Generic Service")
                  continue;
                clusteredServices.Add(new ClusteredServiceInfo
                {
                  nodeName = serviceData["OwnerNode"].ToString(),
                  serviceDisplayName = serviceData["Name"].ToString(),
                  serviceName = ((ManagementBaseObject)serviceData["PrivateProperties"])["ServiceName"].ToString(),
                  Offline = (uint)serviceData["State"] == 3
                });
                serviceData.Dispose();
              }
            }
          }
          catch (Exception cluster_e)
          {
            string msg = "Failed to query clustered services information.";
            ModuleErrorSignalReceiver(ModuleErrorSeverity.DataLoss, ModuleErrorCriticality.Continue, cluster_e, msg);
            opMessages += msg + "; ";
          }

        // list all services
        List<ServiceInfo> allServices = new List<ServiceInfo>();
        StringComparer ignoreCaseComparer = StringComparer.OrdinalIgnoreCase;
        foreach (ServiceController service in string.IsNullOrWhiteSpace(QueryService) ? ServiceController.GetServices() : new ServiceController[] { new ServiceController(QueryService) })
        {
          try
          {
            ServiceInfo newInstance = new ServiceInfo()
            {
              IsClustered = clusteredServices.Exists(x => ignoreCaseComparer.Compare(x.serviceName, service.ServiceName) == 0),
              NodeName = ComputerHelper.GetMachineDNSName(), // default to local host
              DisplayName = service.DisplayName,
              Name = service.ServiceName,
              Status = service.Status.ToString(),
              Type = (int)service.ServiceType,
            };
            FillServiceValuesFromRegistry(newInstance, service, QueryParameters);
            if (newInstance.IsClustered)
            {
              newInstance.NodeName = clusteredServices.Find(x => ignoreCaseComparer.Compare(x.serviceName, service.ServiceName) == 0).nodeName;
              newInstance.IsClusterOffline = clusteredServices.Find(x => ignoreCaseComparer.Compare(x.serviceName, service.ServiceName) == 0).Offline;
            }
            allServices.Add(newInstance);
          }
          catch (Exception e)
          {
            ModuleErrorSignalReceiver(ModuleErrorSeverity.DataLoss, ModuleErrorCriticality.Continue, e, $"Failure while reading service {service.DisplayName}. Skipping.");
          }
          finally
          {
            service.Dispose();
          }
        }

        return new ServiceListDataItem[]
        {
          new ServiceListDataItem(new ServiceList
          {
            Services = allServices,
            ErrorCode = 0,
            ErrorMessage = opMessages
          })
        };
      }
      catch (Exception e)
      {
        ModuleErrorSignalReceiver(ModuleErrorSeverity.DataLoss, ModuleErrorCriticality.Continue, e, "Failed to query local services.");
        return new ServiceListDataItem[]
        {
          new ServiceListDataItem(new ServiceList
          {
            Services = new List<ServiceInfo>(),
            ErrorCode = e.HResult,
            ErrorMessage = $"Failed to query local services: {e.Message}"
          })
        };
      }
    }

    private void FillServiceValuesFromRegistry(ServiceInfo newInstance, ServiceController serviceObject, bool queryParameters)
    {
      using (RegistryKey registry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey serviceKey = registry.OpenSubKey($"SYSTEM\\CurrentControlSet\\Services\\{serviceObject.ServiceName}"))
        {
          object delayedAutostartValue = supportDelayedStart ? serviceKey.GetValue("DelayedAutostart") : null;
          newInstance.IsDelayed = supportDelayedStart && delayedAutostartValue != null && (int)delayedAutostartValue == 1;

          RegistryKey triggerKey = supportDelayedStart ? serviceKey.OpenSubKey("TriggerInfo") : null;
          newInstance.IsTriggered = supportDelayedStart && (triggerKey?.SubKeyCount ?? -1) > 0;
          triggerKey?.Dispose();

          object startValue = serviceKey.GetValue("Start");
          newInstance.Start = startValue == null ? 4 : (int)startValue; // 4 => Disabled

          object dependOnServiceValue = serviceKey.GetValue("DependOnService");
          newInstance.DependOnService = dependOnServiceValue == null ? null : (string[])dependOnServiceValue;

          try
          {
            const int bufSize = 4096;
            StringBuilder outBuf = new StringBuilder(bufSize);
            if (Win32Helper.RegLoadMUIStringW(serviceKey.Handle.DangerousGetHandle(), "Description", outBuf, bufSize, out uint outSize, 0, null) == 0)
              newInstance.Description = outBuf.ToString();
            else
              newInstance.Description = $"Failed to get description: {Marshal.GetLastWin32Error()}";
          }
          catch (Exception e)
          {
            newInstance.Description = $"Failed to get description: {e.Message}";
          }

          object imagePathValue = serviceKey.GetValue("ImagePath");
          newInstance.ImagePath = imagePathValue == null ? null : Environment.ExpandEnvironmentVariables((string)imagePathValue);

          object objectNameValue = serviceKey.GetValue("ObjectName");
          newInstance.ObjectName = objectNameValue == null ? null : (string)objectNameValue;

          if (queryParameters)
          {
            try
            {
              using (RegistryKey paramsSubKey = serviceKey.OpenSubKey("Parameters"))
                EnumerateParameters(paramsSubKey, "", newInstance.Parameters);
            }
            catch { }
          }
        }
      }
    }

    private void EnumerateParameters(RegistryKey rootKey, string path, List<ServiceParameter> destination)
    {
      foreach (string paramName in rootKey.GetValueNames())
        destination.Add(new ServiceParameter { Name = string.IsNullOrEmpty(path) ? paramName : $"{path}\\{paramName}", Data = rootKey.GetValue(paramName), RegType = rootKey.GetValueKind(paramName).ToString() });
      foreach (string subKeyName in rootKey.GetSubKeyNames())
        using (RegistryKey subKey = rootKey.OpenSubKey(subKeyName))
          EnumerateParameters(subKey, string.IsNullOrEmpty(path) ? subKeyName : $"{path}\\{subKeyName}", destination);
    }

    protected override void LoadConfiguration(XmlDocument cfgDoc)
    {
      try
      {
        LoadConfigurationElement(cfgDoc, "QueryParameters", out QueryParameters, false, false);
        LoadConfigurationElement(cfgDoc, "QueryService", out QueryService, null, false);
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
