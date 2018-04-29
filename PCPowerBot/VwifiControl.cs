using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPowerBot
{
    class VwifiControl
    {
        private static string startProcess(string filename, string arguments = "")
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = filename;
            pProcess.StartInfo.Arguments = arguments;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
            pProcess.Start();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            pProcess.WaitForExit();

            return strOutput;
        }

        public static void Start(string name, string password)
        {
            string wlanSet = String.Format("wlan set hostednetwork mode=allow \"ssid={0}\" \"key={1}\"",
                name,
                password);

            startProcess("netsh", wlanSet);
            startProcess("netsh", "wlan start hostednetwork");
        }

        public static void Stop()
        {
            startProcess("netsh", "wlan stop hostednetwork");
            startProcess("netsh", "wlan set hostednetwork mode=disallow");
        }
    }
}
