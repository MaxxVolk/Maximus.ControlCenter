using Maximus.Library.Helpers;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;

using System;

namespace Maximus.ControlCenter.Tasks.Module.Global
{
  internal static class ModInit
  {
    static ModInit()
    {

    }

    const string LogSourceName = "Maximus Control Panel Tasks Module";
    const int LogBaseEventId = 7320;

    static private LoggingHelper _Logger;
    static internal LoggingHelper Logger => _Logger ?? (_Logger = new LoggingHelper(LogSourceName, LogBaseEventId, EventLoggingLevel.Verbose));

    internal const int evtId_QueryServiceListPA = 0;
    internal const int evtId_ControlServiceWA = 1;
    internal const int evtId_ConfigureServiceWA = 2;
    internal const int evtId_ReadEventLogPA = 3;
    internal const int evtId_ReadRegistryKeyPA = 4;
    internal const int evtId_WriteRegistryElementWA = 5;

    internal static void ModuleErrorSignalReceiver(ModuleErrorSeverity severity, ModuleErrorCriticality criticality, Exception e, string message, object callerInstance)
    {
      Logger.WriteException($"Internal module exception or error.\r\nMessage: {message}\r\nError Severity: {severity}\r\nError Criticality: {criticality}", e ?? new Exception("Unknown exception"), callerInstance);
    }
  }
}
