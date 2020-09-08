using Microsoft.EnterpriseManagement.Mom.Internal.UI.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.ControlCenter.UI.Control
{
  public class ComputerInstancePropertyTranslator : PropertyTranslator
  {
    public override object GetPropertyTag(string name)
    {
      throw new NotImplementedException();
    }

    public override object GetProperty(object tag, object dataItem)
    {
      object property = base.GetProperty(tag, dataItem);
      string strA = tag as string;
      if (strA != null && string.Compare(strA, "HealthState", StringComparison.OrdinalIgnoreCase) == 0 || (string.Compare(strA, "LastModified", StringComparison.OrdinalIgnoreCase) == 0 || ((string)property).Length != 0))
        return property;
      return "Unknown";
    }
  }
}
