using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maximus.ControlCenter.UI.Control
{
  public static class Dbg
  {
    public static void Log(string msg)
    {
#if TRACE_FILE_OUTPUT
      int maxAttempts = 10;
      while (true)
        try
        {
          maxAttempts--;
          if (maxAttempts < 0)
            break;
          File.AppendAllText(@"C:\Temp\Maximus.ControlCenter.txt", $"[{DateTime.Now.ToString("HH:mm:ss")}]: {msg}\r\n");
          break;
        }
        catch
        {
          Thread.Sleep(1);
          continue;
        }
#endif
    }
  }
}
