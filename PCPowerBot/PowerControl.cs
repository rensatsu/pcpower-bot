using System.Management;
using System.Runtime.InteropServices;

namespace PCPowerBot
{
    class PowerControl
    {
        private static void WMIPower(string flags)
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = flags;
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }
        }

        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        [DllImport("user32")]
        private static extern void LockWorkStation();

        public static void Shutdown()
        {
            WMIPower("1");
        }

        public static void Reboot()
        {
            WMIPower("2");
        }

        public static void Hibernate() {
            SetSuspendState(true, true, true);
        }

        public static void Sleep()
        {
            SetSuspendState(false, true, true);
        }

        public static void Lock()
        {
            LockWorkStation();
        }
    }
}
