using Maximus.Library.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    static internal LoggingHelper Logger => _Logger ?? (_Logger = new LoggingHelper(LogSourceName, LogBaseEventId, EventLoggingLevel.Warning));

    internal const int evtId_QueryServiceListPA = 0;
  }
}
