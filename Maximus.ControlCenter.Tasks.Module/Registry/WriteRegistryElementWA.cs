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
              return CreateResponse(OldName, "REG_KEY_DELETED", "");
            // KeyPath, OldName, NewName
            case WriteRegistryElementAction.RenameKey:
              if (string.IsNullOrWhiteSpace(NewName) || string.IsNullOrWhiteSpace(OldName))
                return CreateErrorousOutput("Missing parameters. Rename Key operation requires KeyPath, OldName, and NewName.");
              int hResult = RegRenameKey(rootKey.Handle, OldName, NewName);
              if (hResult == 0)
                return CreateResponse(NewName, "REG_KEY", "");
              else
                return CreateErrorousOutput($"Win error code: {hResult}");
            // KeyPath, NewName, NewValue, ValueType
            case WriteRegistryElementAction.CreateValue:
              return CreateErrorousOutput("Not supported. Use 'SetValue' to create not existing value.");
            // KeyPath, OldName, NewValue, ValueType
            case WriteRegistryElementAction.SetValue:
              if (string.IsNullOrWhiteSpace(NewValue) || string.IsNullOrWhiteSpace(ValueType))
                return CreateErrorousOutput("Missing parameters. Set Value operation requires KeyPath, OldName, NewValue, and ValueType. Although, OldName can be empty to indicate the default value.");
              if (string.IsNullOrEmpty(OldName) && ValueType != "REG_SZ")
                return CreateErrorousOutput("Invalid parameters. (Default) value can only be of REG_SZ type.");
              RegistryValueKind dataType = GetRegistryValueKind(ValueType);
              object value = DeserializeRegValue(NewValue, dataType);
              rootKey.SetValue(OldName, value, dataType);
              return CreateResponse(OldName, ValueType, NewValue);
            // KeyPath, OldName
            case WriteRegistryElementAction.DeleteValue:
              if (string.IsNullOrWhiteSpace(OldName))
                return CreateErrorousOutput("Missing parameters. Delete Key operation requires KeyPath and OldName.");
              rootKey.DeleteValue(OldName);
              return CreateResponse(OldName, "REG_VALUE_DELETED", "");
            // KeyPath, OldName, NewName
            case WriteRegistryElementAction.RenameValue:
              if (string.IsNullOrWhiteSpace(NewName) || string.IsNullOrWhiteSpace(OldName))
                return CreateErrorousOutput("Missing parameters. Rename Value operation requires KeyPath, OldName, and NewName.");
              if (rootKey.GetValueNames().Any(s=>string.Compare(s, NewName, true) == 0))
                return CreateErrorousOutput("Invalid parameters. Value with the new name already exists. Renaming failed.");
              rootKey.SetValue(NewName, rootKey.GetValue(OldName), rootKey.GetValueKind(OldName));
              rootKey.DeleteValue(OldName);
              return new QuadrupleListDataItem[] { new QuadrupleListDataItem(new QuadrupleList { List = new List<Quadruple> { ReadRegistryKeyPA.SerializeRegValue(NewName, rootKey.GetValue(NewName), rootKey.GetValueKind(NewName), true) } }) };
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

    private static object DeserializeRegValue(string valueStr, RegistryValueKind dataType)
    {
      switch (dataType)
      {
        case RegistryValueKind.DWord: return uint.Parse(valueStr);
        case RegistryValueKind.QWord: return ulong.Parse(valueStr);
        case RegistryValueKind.String:
        case RegistryValueKind.ExpandString: return valueStr;
        case RegistryValueKind.Binary:
          // https://stackoverflow.com/questions/1230303/bitconverter-tostring-in-reverse
          byte[] data = new byte[(valueStr.Length + 1) / 3];
          for (int i = 0; i < data.Length; i++)
            data[i] = (byte)("0123456789ABCDEF".IndexOf(valueStr[i * 3]) * 16 + "0123456789ABCDEF".IndexOf(valueStr[i * 3 + 1]));
          return data;
        case RegistryValueKind.MultiString:
          return valueStr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      }
      throw new InvalidCastException("Failed to deserialize data or invalid data kind.");
    }

    private static RegistryValueKind GetRegistryValueKind(string regTypeStr)
    {
      switch (regTypeStr)
      {
        case "REG_SZ": return RegistryValueKind.String;
        case "REG_EXPAND_SZ": return RegistryValueKind.ExpandString;
        case "REG_BINARY": return RegistryValueKind.Binary;
        case "REG_DWORD": return RegistryValueKind.DWord;
        case "REG_MULTI_SZ": return RegistryValueKind.MultiString;
        case "REG_QWORD": return RegistryValueKind.QWord;
      }
      return RegistryValueKind.Unknown;
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
    public static extern int RegRenameKey(SafeRegistryHandle hKey, [MarshalAs(UnmanagedType.LPWStr)] string oldname, [MarshalAs(UnmanagedType.LPWStr)] string newname);

    [DllImport("advapi32")]
    public static extern int RegRenameValue(SafeRegistryHandle hKey, [MarshalAs(UnmanagedType.LPWStr)] string oldname, [MarshalAs(UnmanagedType.LPWStr)] string newname);
  }
}
