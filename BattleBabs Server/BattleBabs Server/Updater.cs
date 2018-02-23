using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Reflection;

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
            if(receivedVersionInfo.Equals(currentVersionInfo))
            {
                Console.WriteLine("This software is up to date.");
            }
            
        }
    }
}
