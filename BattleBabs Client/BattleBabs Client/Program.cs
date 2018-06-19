using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace BattleBabs_Client
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
            Updater.checkForUpdates();            
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += hasExited;
            Application.Run(new Display());
        }

        static void hasExited(object sender, System.EventArgs e)
        {
            Console.WriteLine("Application main thread is exiting, closing log");
        }
    }
}
