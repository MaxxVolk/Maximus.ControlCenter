using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.ControlCenter.Tasks.Module.Services;
using Maximus.Library.Helpers;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;
using Microsoft.Win32;

namespace Maximus.ControlCenter.Tasks.Module.Registry
{
  [MonitoringModule(ModuleType.ReadAction)]
  [ModuleOutput(true)]
  class ReadRegistryKeyPA : ModuleBaseSimpleAction<QuadrupleListDataItem>
  {
    // configuration
    private string KeyPath;
    private bool ExpandStrings = true;

    public ReadRegistryKeyPA(ModuleHost<QuadrupleListDataItem> moduleHost, XmlReader configuration, byte[] previousState) : base(moduleHost, configuration, previousState)
    {
    }

    protected override void PreInitialize(ModuleHost<QuadrupleListDataItem> moduleHost, XmlReader configuration, byte[] previousState)
    {
      ModInit.Logger.AddLoggingSource(GetType(), ModInit.evtId_ReadRegistryKeyPA);
      base.PreInitialize(moduleHost, configuration, previousState);
    }

    protected override QuadrupleListDataItem[] GetOutputData(DataItemBase[] inputDataItems)
    {
      try
      {
        using (RegistryKey currentKey = RegistryHelper.GetRegistryKey(".", KeyPath))
          if (currentKey != null)
          {
            // Keys
            List<Quadruple> keys = new List<Quadruple>();
            foreach (string keyName in currentKey.GetSubKeyNames())
            {
              keys.Add(new Quadruple { I1 = keyName, I2 = "REG_KEY", I3 = "" });
            }
            keys.Sort((q1, q2) => q1.I1.CompareTo(q2.I1));
            // values
            List<Quadruple> values = new List<Quadruple>();
            foreach (string paramName in currentKey.GetValueNames())
              values.Add(SerializeRegValue(paramName, currentKey.GetValue(paramName), currentKey.GetValueKind(paramName)));
            values.Sort((q1, q2) => q1.I1.CompareTo(q2.I1));

            keys.AddRange(values);
            return new QuadrupleListDataItem[] { new QuadrupleListDataItem(new QuadrupleList { List = keys }) };
          }
          else
            return new QuadrupleListDataItem[]
            {
              new QuadrupleListDataItem(new QuadrupleList { List = new List<Quadruple>
              {
                new Quadruple { I1 = "@Error", I2 = "REG_SZ", I3 = "Key path not found." }
              } })
            };

      }
      catch (Exception e)
      {
        // if cannot get list -- return default logs
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

    private Quadruple SerializeRegValue(string paramName, object value, RegistryValueKind dataType)
    {
      try
      {
        string pn = string.IsNullOrWhiteSpace(paramName) ? "(Default)" : paramName;
        switch (dataType)
        {
          case RegistryValueKind.DWord: return new Quadruple { I1 = pn, I2 = "REG_DWORD", I3 = unchecked((uint)((int)value)).ToString() };
          case RegistryValueKind.QWord: return new Quadruple { I1 = pn, I2 = "REG_QWORD", I3 = unchecked((ulong)((long)value)).ToString() };
          case RegistryValueKind.String: return new Quadruple { I1 = pn, I2 = "REG_SZ", I3 = (string)value };
          case RegistryValueKind.ExpandString: return new Quadruple { I1 = pn, I2 = "REG_EXPAND_SZ", I3 = ExpandStrings ? Environment.ExpandEnvironmentVariables((string)value) : (string)value };
          case RegistryValueKind.Binary: return new Quadruple { I1 = pn, I2 = "REG_BINARY.", I3 = BitConverter.ToString((byte[])value).Replace('-', ' ') };
          case RegistryValueKind.MultiString:
            string mliners = "";
            string[] lines = (string[])value;
            if (lines != null && lines.Length > 0)
              for (int i = 0; i < lines.Length; i++)
                mliners += lines[i] + (i < lines.Length - 1 ? "\r\n" : "");
            return new Quadruple { I1 = pn, I2 = "REG_MULTI_SZ", I3 = mliners };
        }
        return new Quadruple { I1 = pn, I2 = "REG_UNKNOWN", I3 = value.ToString() };
      }
      catch (Exception e)
      {
        ModuleErrorSignalReceiver(ModuleErrorSeverity.DataLoss, ModuleErrorCriticality.Continue, e, $"Failed to serialize {paramName} of native type {value.GetType().Name} and registry type of {dataType}");
        return new Quadruple { I1 = paramName, I2 = "REG_SZ", I3 = e.Message };
      }
    }

    protected override void LoadConfiguration(XmlDocument cfgDoc)
    {
      try
      {
        LoadConfigurationElement(cfgDoc, "KeyPath", out KeyPath);
        LoadConfigurationElement(cfgDoc, "ExpandStrings", out ExpandStrings, true, false);
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
