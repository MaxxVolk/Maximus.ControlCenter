using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Xml;

using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;

namespace Maximus.ControlCenter.Tasks.Module.Events
{
  [MonitoringModule(ModuleType.ReadAction)]
  [ModuleOutput(true)]
  class ListEventLogsPA : ModuleBaseSimpleAction<QuadrupleListDataItem>
  {
    public ListEventLogsPA(ModuleHost<QuadrupleListDataItem> moduleHost, XmlReader configuration, byte[] previousState) : base(moduleHost, configuration, previousState)
    {
    }

    protected override QuadrupleListDataItem[] GetOutputData(DataItemBase[] inputDataItems)
    {
      try
      {
        List<Quadruple> rawData = new List<Quadruple>();
        foreach (string logName in EventLogSession.GlobalSession.GetLogNames())
          rawData.Add(new Quadruple { I1 = logName });

        return new QuadrupleListDataItem[] { new QuadrupleListDataItem(new QuadrupleList { List = rawData }) };
      }
      catch (Exception e)
      {
        // if cannot get list -- return default logs
        ModuleErrorSignalReceiver(ModuleErrorSeverity.DataLoss, ModuleErrorCriticality.Continue, e, $"Failed to query local log list.");
        return new QuadrupleListDataItem[]
        {
          new QuadrupleListDataItem(new QuadrupleList { List = new List<Quadruple>
          {
            new Quadruple { I1 = "Application" },
            new Quadruple { I1 = "Security" },
            new Quadruple { I1 = "System" },
          } })
        };
      }
    }

    protected override void LoadConfiguration(XmlDocument cfgDoc)
    {
      // empty configuration
    }

    protected override void ModuleErrorSignalReceiver(ModuleErrorSeverity severity, ModuleErrorCriticality criticality, Exception e, string message, params object[] extaInfo)
    {
      ModInit.ModuleErrorSignalReceiver(severity, criticality, e, message, this);
    }
  }
}
