using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  public class ServiceInfo
  {
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public int Start { get; set; }
    public int Type { get; set; }
    public string DependOnService { get; set; }
    public string ObjectName { get; set; }
    public string ImagePath { get; set; }
    public bool IsDelayed { get; set; }
    public bool IsTriggered { get; set; }
    public bool IsClustered { get; set; }
    public bool IsClusterOffline { get; set; }
    public string NodeName { get; set; }
    public string Status { get; set; }

    public Dictionary<string, string> Parameters { get; set; } = null;
  }
}
