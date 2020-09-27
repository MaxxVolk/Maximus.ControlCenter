using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;

namespace Maximus.ControlCenter.Tasks.Module.Registry
{
  public enum WriteRegistryElementAction { 
    // KeyPath, NewName
    CreateKey = 1, 
    // KeyPath, OldName
    DeleteKey = 2,
    // KeyPath, OldName, NewName
    RenameKey = 3, 
    // KeyPath, NewName, NewValue, ValueType
    CreateValue = 4,
    // KeyPath, OldName
    DeleteValue = 5,
    // KeyPath, OldName, NewName
    RenameValue = 6,
    // KeyPath, OldName, NewValue, ValueType
    SetValue = 7
  }

  [MonitoringModule(ModuleType.WriteAction)]
  [ModuleOutput(true)]
  class WriteRegistryElementWA : ModuleBaseSimpleAction<QuadrupleListDataItem>
  {
    // configuration
    private string KeyPath, OldName, NewName, NewValue, ValueType;
    private WriteRegistryElementAction Action;

    public WriteRegistryElementWA(ModuleHost<QuadrupleListDataItem> moduleHost, XmlReader configuration, byte[] previousState) : base(moduleHost, configuration, previousState)
    {
    }

    protected override void PreInitialize(ModuleHost<QuadrupleListDataItem> moduleHost, XmlReader configuration, byte[] previousState)
    {
      ModInit.Logger.AddLoggingSource(GetType(), ModInit.evtId_WriteRegistryElementWA);
      base.PreInitialize(moduleHost, configuration, previousState);
    }

    protected override QuadrupleListDataItem[] GetOutputData(DataItemBase[] inputDataItems)
    {
      try
      {
        return null;
      }
      catch (Exception e)
      {
        ModuleErrorSignalReceiver(ModuleErrorSeverity.DataLoss, ModuleErrorCriticality.Continue, e, $"Failed to query local log list.");
        return new QuadrupleListDataItem[]
        {
          new QuadrupleListDataItem(new QuadrupleList { List = new List<Quadruple>
          {
            new Quadruple { I1 = "@Error", I2 = "REG_SZ", I3 = e.Message }
          } })
        };
      }
    }

    protected override void LoadConfiguration(XmlDocument cfgDoc)
    {
      try
      {
        LoadConfigurationElement(cfgDoc, "KeyPath", out KeyPath);
        LoadConfigurationElement(cfgDoc, "Action", out int intAction);
        LoadConfigurationElement(cfgDoc, "OldName", out OldName, null, false);
        LoadConfigurationElement(cfgDoc, "NewName", out NewName, null, false);
        LoadConfigurationElement(cfgDoc, "NewValue", out NewValue, null, false);
        LoadConfigurationElement(cfgDoc, "ValueType", out ValueType, null, false);
        // parse
        if (intAction >= 1 && intAction <= 7)
          Action = (WriteRegistryElementAction)intAction;
        else
          throw new ArgumentOutOfRangeException("Action", "Invalid Action code.");
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
