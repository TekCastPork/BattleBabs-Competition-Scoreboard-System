using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace BattleBabs_Client
{
    public partial class WhatsNewScreen : Form
    {
        public static Boolean isShowing = false;
        public WhatsNewScreen()
        {
            InitializeComponent();
            getData();
        }

        public static void shouldPopOnStart()
        {
            if(GameUtility.showChanges == true)
            {
                isShowing = true;
                GameUtility.showChanges = false;
            }
        }

        private void getData()
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the 
            // requested URI contains a query.

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string receivedInfo = String.Empty;
            try
            {
                Stream data = client.OpenRead("http://api.github.com/repos/TekCastPork/BattleBabs-Competition-Scoreboard-System/releases/latest");
                StreamReader reader = new StreamReader(data);
                string receivedData = reader.ReadToEnd();
                Console.WriteLine(receivedData);
                data.Close();
                reader.Close();
                JObject versionData = JObject.Parse(receivedData);
                receivedInfo = versionData.GetValue("body").ToString().Replace('*', ' ').Replace('#', (char)31);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                receivedInfo = "Something happened and changelog data could \n" +
                    "not be aquired from the Github API.";

            } finally
            {
                textBox.Text = receivedInfo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            isShowing = false;
        }
    }
}
