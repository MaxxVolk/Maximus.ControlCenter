using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.Library.Helpers;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

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
    private WriteRegistryElementAction WAAction;

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
        if (string.IsNullOrWhiteSpace(KeyPath))
          return CreateErrorousOutput("Missing parameters. KeyPath is compulsory for all operations.");

        using (RegistryKey rootKey = RegistryHelper.GetRegistryKey(".", KeyPath, true))
        {
          if (rootKey == null)
            return CreateErrorousOutput("KeyPath is invalid or not found.");

          switch (WAAction)
          {
            // KeyPath, NewName
            case WriteRegistryElementAction.CreateKey:
              if (string.IsNullOrWhiteSpace(NewName))
                return CreateErrorousOutput("Missing parameters. Create Key operation requires KeyPath and NewName.");
              else
                using (RegistryKey newKey = rootKey.CreateSubKey(NewName))
                {
                  return CreateResponse(newKey.Name, "REG_KEY", "");
                }
            // KeyPath, OldName
            case WriteRegistryElementAction.DeleteKey:
              if (string.IsNullOrWhiteSpace(OldName))
                return CreateErrorousOutput("Missing parameters. Delete Key operation requires KeyPath and OldName.");
              rootKey.DeleteSubKeyTree(OldName);
              return CreateResponse(OldName, "REG_DELETED", "");
            // KeyPath, OldName, NewName
            case WriteRegistryElementAction.RenameKey:
              if (string.IsNullOrWhiteSpace(NewName) || string.IsNullOrWhiteSpace(OldName))
                return CreateErrorousOutput("Missing parameters. Rename Key operation requires KeyPath, OldName, and NewName.");
              using (RegistryKey key = rootKey.OpenSubKey(OldName))
              {
                int pathBeginsAt = KeyPath.IndexOf('\\');
                string fullPathOld = "";
                if (pathBeginsAt >= 0 && KeyPath.Length >= pathBeginsAt + 1)
                  fullPathOld = KeyPath.Substring(pathBeginsAt + 1);
                // int hResult = RegRenameKey(key.Handle, $"{fullPathOld}\\{OldName}", NewName);
                int hResult = RegRenameKey(key.Handle, OldName, NewName);
                if (hResult == 0)
                  return CreateResponse(NewName, "REG_KEY", "");
                else
                  return CreateErrorousOutput($"Win error code: {hResult}");
              }
            // KeyPath, NewName, NewValue, ValueType
            case WriteRegistryElementAction.CreateValue:
              break;
            // KeyPath, OldName
            case WriteRegistryElementAction.DeleteValue:
              break;
            // KeyPath, OldName, NewName
            case WriteRegistryElementAction.RenameValue:
              break;
            // KeyPath, OldName, NewValue, ValueType
            case WriteRegistryElementAction.SetValue:
              break;
          }
        }
        return CreateErrorousOutput("Unknown action.");
      }
      catch (Exception e)
      {
        ModuleErrorSignalReceiver(ModuleErrorSeverity.DataLoss, ModuleErrorCriticality.Continue, e, $"Failed to query local log list.");
        return CreateErrorousOutput(e.Message);
      }
    }

    private QuadrupleListDataItem[] CreateErrorousOutput(string message)
    {
      return CreateResponse("@Error", "REG_SZ", message);
    }

    private QuadrupleListDataItem[] CreateResponse(string Name, string dataType, string value)
    {
      return new QuadrupleListDataItem[]
        {
          new QuadrupleListDataItem(new QuadrupleList { List = new List<Quadruple>
          {
            new Quadruple { I1 = Name, I2 = dataType, I3 = value }
          } })
        };
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
          WAAction = (WriteRegistryElementAction)intAction;
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

    [DllImport("advapi32")]
    public static extern int RegRenameKey(
     SafeRegistryHandle hKey,
     [MarshalAs(UnmanagedType.LPWStr)] string oldname,
     [MarshalAs(UnmanagedType.LPWStr)] string newname);
  }
}
