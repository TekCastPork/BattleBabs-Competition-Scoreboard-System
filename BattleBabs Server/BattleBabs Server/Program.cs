using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleBabs_Server
{
    static class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Appdata location: {0}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            try
            {
                FileSystem.loadData();
            } catch (Exception e)
            {
                Console.WriteLine("Error! {0} | {1}", e.ToString(), e.Message);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadExit += isExiting;
            Application.Run(new Display());
        }

        static void isExiting(object sender, System.EventArgs e)
        {
            FileSystem.saveData();
            Console.WriteLine("Main thread is exiting!");
        }
    }
}
