using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  [MonitoringModule(ModuleType.ReadAction)]
  [ModuleOutput(true)]
  public class QueryServiceListPA : ModuleBaseSimpleAction<ServiceListDataItem>
  {
    private bool QueryParameters = false;

    public QueryServiceListPA(ModuleHost<ServiceListDataItem> moduleHost, XmlReader configuration, byte[] previousState) : base(moduleHost, configuration, previousState)
    {
    }

    protected override void PreInitialize(ModuleHost<ServiceListDataItem> moduleHost, XmlReader configuration, byte[] previousState)
    {
      ModInit.Logger.AddLoggingSource(GetType(), ModInit.evtId_QueryServiceListPA);
      base.PreInitialize(moduleHost, configuration, previousState);
    }

    protected override ServiceListDataItem[] GetOutputData(DataItemBase[] inputDataItems)
    {
      throw new NotImplementedException();
    }

    protected override void LoadConfiguration(XmlReader configuration)
    {
      
    }

    protected override void ModuleErrorSignalReceiver(ModuleErrorSeverity severity, ModuleErrorCriticality criticality, Exception e, string message, params object[] extaInfo)
    {
      throw new NotImplementedException();
    }
  }
}
