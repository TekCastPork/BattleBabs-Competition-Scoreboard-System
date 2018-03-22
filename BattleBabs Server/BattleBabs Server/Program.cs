using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleBabs_Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Appdata location: {0}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Application.EnableVisualStyles();
            Updater.checkForUpdates();
            Updater.validateFiles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadExit += isExiting;
            Application.Run(new Display());
        }

        static void isExiting(object sender, System.EventArgs e)
        {
            Console.WriteLine("Main thread is exiting!");
            Logger.closeLog();
        }
    }
}
