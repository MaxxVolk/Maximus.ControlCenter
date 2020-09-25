using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Win32;

using TestApplication.Properties;

namespace TestApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      TestXMLAttribute<QuadrupleList>();
    }

    private static void TestEventRead()
    {
      string LogName = "Application", SearchString = null, XPathQuery = null;
      int MaxEvents = 100;
      bool SearchUseRegExp = false;
      
      using (EventLogSession eventLogSession = new EventLogSession())
      {
        EventLogQuery eventLogQuery = string.IsNullOrWhiteSpace(XPathQuery) ?
          new EventLogQuery(LogName, PathType.LogName)
          {
            Session = eventLogSession,
            TolerateQueryErrors = true,
            ReverseDirection = true
          } :
        new EventLogQuery(LogName, PathType.LogName, XPathQuery)
        {
          Session = eventLogSession,
          TolerateQueryErrors = true,
          ReverseDirection = true
        };
        int eventReadCounter = MaxEvents;
        using (EventLogReader eventLogReader = new EventLogReader(eventLogQuery))
        {
          eventLogReader.Seek(System.IO.SeekOrigin.Begin, 0);
          do
          {
            if (eventReadCounter <= 0)
              break;

            EventRecord eventData = eventLogReader.ReadEvent();
            if (eventData == null)
              break;

            if (string.IsNullOrWhiteSpace(SearchString))
            {
              Console.WriteLine($"{eventData.TimeCreated}: {eventData.FormatDescription()}, {eventData.KeywordsDisplayNames}");
              eventReadCounter--;
            }
            else
            {
              if (Regex.IsMatch(eventData.FormatDescription(), SearchUseRegExp ? SearchString : Regex.Escape(SearchString), RegexOptions.IgnoreCase))
              {
                Console.WriteLine($"{eventData.TimeCreated}: {eventData.FormatDescription()}");
                eventReadCounter--;
              }
            }
            eventData.Dispose();
          } while (true);
        }

        return;
      }
    }

    private static void TestLoadMUIString()
    {
      RegistryKey registry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
      ServiceController sc = new ServiceController("HealthService");
      RegistryKey serviceKey = registry.OpenSubKey($"SYSTEM\\CurrentControlSet\\Services\\{sc.ServiceName}");
      try
      {
        StringBuilder outBuf = new StringBuilder(4096);
        if (RegLoadMUIStringW(serviceKey.Handle.DangerousGetHandle(), "Description", outBuf, 4096, out uint outSize, 0, null) == 0)
          Console.WriteLine(outBuf.ToString());
        else
          Console.WriteLine(Marshal.GetLastWin32Error());
      }
      catch (Exception e)
      {
      }
    }

    [DllImport("advapi32.dll", EntryPoint = "RegLoadMUIStringW", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegLoadMUIStringW(IntPtr hKey, string pszValue, StringBuilder pszOutBuf, uint cbOutBuf, out uint pcbData, uint Flags, string pszDirectory);

    private static void TestResource()
    {
      var y = Resources.res1;
      var z = Resources.ResourceManager.GetString("res1", Resources.Culture);
      var x = Resources.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
    }

    private static void TestXMLAttribute<ContainmentType>()
    {
      object containmentNodeAttr = typeof(ContainmentType).GetCustomAttributes(typeof(XmlRootAttribute), inherit: true).FirstOrDefault();
      if (containmentNodeAttr == null)
        return;
      if (containmentNodeAttr is XmlRootAttribute xmlRootAttr)
        Console.WriteLine(xmlRootAttr.ElementName);
    }
  }

  [XmlRoot("QuadrupleList")]
  public class QuadrupleList 
  {
    [XmlArray]
    public List<int> List { get; set; }
  }
}
