using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.ControlCenter.Tasks.Module.Services
{
  public static class Win32Helper
  {
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern Boolean ChangeServiceConfig(
        IntPtr hService,
        UInt32 nServiceType,
        UInt32 nStartType,
        UInt32 nErrorControl,
        String lpBinaryPathName,
        String lpLoadOrderGroup,
        IntPtr lpdwTagId,
        [In] char[] lpDependencies,
        String lpServiceStartName,
        String lpPassword,
        String lpDisplayName);

    [DllImport("advapi32.dll", EntryPoint = "RegLoadMUIStringW", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegLoadMUIStringW(IntPtr hKey, string pszValue, StringBuilder pszOutBuf, uint cbOutBuf, out uint pcbData, uint Flags, string pszDirectory);

    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);

    [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);

    [DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
    public static extern int CloseServiceHandle(IntPtr hSCObject);

    public const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;
    public const uint SERVICE_QUERY_CONFIG = 0x00000001;
    public const uint SERVICE_CHANGE_CONFIG = 0x00000002;
    public const uint SC_MANAGER_ALL_ACCESS = 0x000F003F;
    public const uint SC_MANAGER_CONNECT = 0x0001;
    public const uint SC_MANAGER_ENUMERATE_SERVICE = 0x0004;

    public static void SetStartMode(this ServiceController service, ServiceStartMode mode)
    {
      using (SafeHandle serviceHandle = service.ServiceHandle)
      {
        if (!
        ChangeServiceConfig(
        serviceHandle.DangerousGetHandle(),
        SERVICE_NO_CHANGE,
        (uint)mode,
        SERVICE_NO_CHANGE,
        null,
        null,
        IntPtr.Zero,
        null,
        null,
        null,
        null)
        )
        {
          throw new ExternalException("Could not change service start type", new Win32Exception(Marshal.GetLastWin32Error()));
        }
      }
    }
  }
}
