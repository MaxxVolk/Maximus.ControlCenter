using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.ControlCenter.Tasks.Module.Events
{
  public class EventInfo
  {
    public string LogName { get; set; }
    public string Source { get; set; }
    public int EventId { get; set; }
    public string Level { get; set; }
    public string User { get; set; }
    public DateTime Logged { get; set; }
    public string TaskCategory { get; set; }
    public string Keywords { get; set; }
    public string Computer { get; set; }

    public string FormattedDescription { get; set; }
    public string RawXML { get; set; }
  }
}
