using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCPowerBot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Application is already running!", "PCPowerBot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                Application.Run(new MainForm());
            }
        }

        private static string appGuid = "60FE9A50-7106-4EE2-9455-905241A2E7DC";
    }
}
