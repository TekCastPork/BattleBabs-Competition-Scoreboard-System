using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Reflection;
using System.Threading;

namespace BattleBabs_Server
{
    /// <summary>
    /// This class will primary perform updating functions and appdata verification as an additional function
    /// </summary>
    class Updater
    {
        public static void checkForUpdates()
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the 
            // requested URI contains a query.

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                Stream data = client.OpenRead("http://api.github.com/repos/TekCastPork/BattleBabs-Competition-Scoreboard-System/releases/latest");
                StreamReader reader = new StreamReader(data);
                string receivedData = reader.ReadToEnd();
                Console.WriteLine(receivedData);
                data.Close();
                reader.Close();
                JObject versionData = JObject.Parse(receivedData);
                string receivedVersionInfo = versionData.GetValue("tag_name").ToString();
                string currentVersionInfo = Assembly.GetEntryAssembly().GetName().Version.ToString();
                //Now compare the values
                if (receivedVersionInfo.Equals(currentVersionInfo))
                {
                    Console.WriteLine("This software is up to date.");
                }
                else
                {
                    Console.WriteLine("The software is not up to date! Notifying user");
                    DialogResult update = MessageBox.Show(String.Format("A new update is available for download.\n\n" +
                        "You have version: {0}\n" +
                        "Latest version: {1}\n\n" +
                        "Changes:\n\n" +
                        "{2}\n\n" +
                        "Would you like to download the latest version?", currentVersionInfo, receivedVersionInfo, versionData.GetValue("body")), "UPDATE AVAILABLE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (update == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://github.com/TekCastPork/BattleBabs-Competition-Scoreboard-System/releases/latest");
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        /// <summary>
        /// This function will validate to make sure the Appdata files are located before the program starts
        /// If it cant find them it will throw an excetopn so that the program can be stopped
        /// </summary>
        public static void validateFiles()
        {
            Console.WriteLine("Now validating persistence files to ensure they exist");
            if(Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"BattleBabs Leaderboard")))
            {
                Console.WriteLine("Appdata folder exists, checking for persistence files");
                Boolean[] filesExist = { true, true, true, true, true, true };
                int missingFiles = 0;
                string[] files = { "rounds.persist", "rounds2.persist", "scores.persist", "names.persist", "flags.persist", "flags2.persist" };
                for (int i = 0; i < files.Length; i++)
                {
                    if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", files[i])))
                    {
                        Console.WriteLine("The file {0} exists.", files[i]);
                    } else
                    {
                        Console.WriteLine("The file {0} does not exist!", files[i]);
                        filesExist[i] = false;
                        missingFiles++;
                    }
                }
                Console.WriteLine("Replacing lost files.");
                for(int i = 0; i < files.Length; i++)
                {
                    if(filesExist[i])
                    {
                        // No need
                    } else
                    {
                        File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", files[i]));
                        Console.WriteLine("Created file {0}");
                    }
                }
                if(filesExist.Contains(false))
                {
                    Console.WriteLine("There were missing files, we should let the user know that they may have lost competition data.");
                    MessageBox.Show("{0} files were missinng and failed to be validated.\n" +
                        "These files were re-created. Competition data may have been lost.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else
            {
                Console.WriteLine("Directory didnt exist! None of the files will be validated as they do not exist!");
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard"));
                Console.WriteLine("Replacing lost files.");
                string[] files = { "rounds.persist", "rounds2.persist", "scores.persist", "names.persist", "flags.persist", "flags2.persist" };
                for (int i = 0; i < files.Length; i++)
                {
                        File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", files[i]));
                        Console.WriteLine("Created file {0}",files[i]);
                }        
                Console.WriteLine("There were missing files, we should let the user know that they may have lost competition data.");
                MessageBox.Show("6 files were missinng and failed to be validated.\n" +
                    "These files were re-created. Competition data may have been lost.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
