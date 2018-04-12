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
            Updater.checkForUpdates();
            Logger.createLogFile();
            Console.WriteLine("Appdata location: {0}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            NetworkStruct.startNetworkComms();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadExit += isExiting;
            Application.Run(new DisplayStruct());
        }

        static void isExiting(object sender, System.EventArgs e)
        {
            Console.WriteLine("Main thread is exiting!");
            PersistenceStruct.saveTeamData();
            Logger.closeLog();
        }
    }
}
