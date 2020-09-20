using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.Library.Helpers;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;
using Microsoft.EnterpriseManagement.Mom.Modules.DataItems;
using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  public enum ActionCodeEnum { Start = 1, Stop = 2, Pause = 3, Resume = 4, Command = 5 }

  [MonitoringModule(ModuleType.WriteAction)]
  [ModuleOutput(true)]
  class ControlServicePA : ModuleBaseSimpleAction<PropertyBagDataItem>
  {
    // configuration
    private string QueryService;
    private int CommandId, ActionCode;

    public ControlServicePA(ModuleHost<PropertyBagDataItem> moduleHost, XmlReader configuration, byte[] previousState) : base(moduleHost, configuration, previousState)
    {

    }

    protected override void PreInitialize(ModuleHost<PropertyBagDataItem> moduleHost, XmlReader configuration, byte[] previousState)
    {
      ModInit.Logger.AddLoggingSource(GetType(), ModInit.evtId_ControlServicePA);
      base.PreInitialize(moduleHost, configuration, previousState);
    }

    protected override PropertyBagDataItem[] GetOutputData(DataItemBase[] inputDataItems)
    {
      try
      {
        using (ServiceController sc = new ServiceController(QueryService))
          switch ((ActionCodeEnum)ActionCode)
          {
            case ActionCodeEnum.Start:
              sc.Start();
              return new PropertyBagDataItem[]
              {
                CreatePropertyBag("Status", "OK", "Message", "")
              };
            case ActionCodeEnum.Stop:
              sc.Stop();
              return new PropertyBagDataItem[]
              {
                CreatePropertyBag("Status", "OK", "Message", "")
              };
            case ActionCodeEnum.Pause:
              sc.Pause();
              return new PropertyBagDataItem[]
              {
                CreatePropertyBag("Status", "OK", "Message", "")
              };
            case ActionCodeEnum.Resume:
              sc.Continue();
              return new PropertyBagDataItem[]
              {
                CreatePropertyBag("Status", "OK", "Message", "")
              };
            case ActionCodeEnum.Command:
              if (CommandId > 0)
              {
                sc.ExecuteCommand(CommandId);
                return new PropertyBagDataItem[]
                {
                  CreatePropertyBag("Status", "OK", "Message", "")
                };
              }
              else
                return new PropertyBagDataItem[]
                {
                  CreatePropertyBag("Status", "ERROR", "Message", "Invalid/not specified Command Id.")
                };
          }
        return new PropertyBagDataItem[]
        {
          CreatePropertyBag("Status", "ERROR", "Message", "Unknown action.")
        };
      }
      catch (Exception e)
      {
        return new PropertyBagDataItem[]
        {
          CreatePropertyBag("Status", "ERROR", "Message", e.Message)
        };
      }
    }

    protected override void LoadConfiguration(XmlDocument cfgDoc)
    {
      try
      {
        LoadConfigurationElement(cfgDoc, "QueryService", out QueryService);
        LoadConfigurationElement(cfgDoc, "ActionCode", out ActionCode);
        LoadConfigurationElement(cfgDoc, "CommandId", out CommandId, -1, false);
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
