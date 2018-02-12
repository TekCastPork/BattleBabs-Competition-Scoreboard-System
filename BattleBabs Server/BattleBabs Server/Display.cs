using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.IO;
using System.Drawing.Text;
using System.Drawing;

namespace BattleBabs_Server
{
    public partial class Display : Form
    {
        AboutBox about = new AboutBox();
        Bracketeers bracketWindow;
        Thread guiUpdate;
        public static int sessionId = 0;
        public Display()
        {
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            privateFonts.AddFontFile(Path.Combine(Application.StartupPath, "GODOFWAR.TTF"));
            Font titleFont = new Font(privateFonts.Families[0], 22);
            Font leaderBoardFont = new Font(privateFonts.Families[0], 20);
            InitializeComponent();
            titleLabel.Font = leaderBoardFont;
            object[] labelsToUpdate = { team1, team2, team3, team4, team5, team6, team7, team8, team9, score1, score2, score3, score4, score5, score6, score7, score8, score9 };
            foreach(Label c in labelsToUpdate)
            {
                c.Font = titleFont;
            }
            ipInfoLabelUpdate(false);
            Networking.create();
            guiUpdate = new Thread(new ThreadStart(updateComponents));
            guiUpdate.IsBackground = true;            
            var host = Dns.GetHostEntry(Dns.GetHostName());
            int IPCount = 0; // used for determininbg some label stuff
            
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("An available IP: {0}.", ip.ToString());
                    ipLabel.Text = "IP: " + ip.ToString();
                    IPCount++; // yo we found a new IP that can communicate
                }
            }
            if(IPCount > 1)
            {
                Console.WriteLine("More than 1 IP was found, enabling the label.");
                ipInfoLabelUpdate(true);
            }
            guiUpdate.Start();
            try
            {
                Peristence.load();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception! {0}", e.Message);
            }

            if (sessionId == 0)
            {
                bracketWindow = new Bracketeers(GameUtility.names);
            } else
            {
                bracketWindow = new Bracketeers(GameUtility.session2Names);
            }
        }

        delegate void SetBoolCallback(Boolean logic);

        private void updateComponents()
        {
            object[] labelsToUpdate = { team1, team2, team3, team4, team5, team6, team7, team8, team9 };
            object[] scoresToUpdate = { score1, score2, score3, score4, score5, score6, score7, score8, score9 };
            while (true)
            {
                int index = 0;
                Thread.Sleep(500);
                if (sessionId == 0)
                {
                    try
                    {
                        sessionLabelUpdate("1");
                        foreach (Label c in labelsToUpdate)
                        {
                            updateTextLabel(c, String.Format("{0,8}", "Team: " + GameUtility.names[index]));
                            index++;
                        }
                        index = 0;
                        foreach(Label c in scoresToUpdate)
                        {
                            updateTextLabel(c, String.Format("{0}", "Points: " + GameUtility.points[index].ToString("000,000")));
                            index++;
                        }
                        index = 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception! {0}", e.Message);
                    }
                }
                else
                {
                    try
                    {
                        sessionLabelUpdate("2");
                        foreach (Label c in labelsToUpdate)
                        {
                            updateTextLabel(c, String.Format("{0,8}", "Team: " + GameUtility.session2Names[index]));
                            index++;
                        }
                        index = 0;
                        foreach (Label c in scoresToUpdate)
                        {
                            updateTextLabel(c, String.Format("{0}", "Points: " + GameUtility.session2Points[index].ToString("000,000")));
                            index++;
                        }
                        index = 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception! {0}", e.Message);
                    }
                }
            }


        }

        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("FORM CLOSING, RUN SAVE PROCEDURE");
            Peristence.saveAll();
        }        

        private void aboutButton_Click(object sender, EventArgs e)
        {
            if (AboutBox.isShowing == false)
            {
                AboutBox.isShowing = true;
                about.Show();
            }
        }

        private void loadfile_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine("File Selected.");
            Console.WriteLine("File is: " + loadfile.FileName);
            Console.WriteLine("placing team names into name array");
            string[] loadedNames = null;
            try
            {
                loadedNames = File.ReadAllLines(loadfile.FileName);
                for(int i = 0; i < loadedNames.Length; i++)
                {
                    try
                    {
                        GameUtility.names[i] = loadedNames[i];
                        GameUtility.session2Names[i] = loadedNames[i + 9];
                    } catch(Exception e2)
                    {
                        Console.WriteLine("Exception! {0}", e2.Message);
                    }
                }
            } catch(Exception e1)
            {
                Console.WriteLine("Exception! {0}", e1.Message);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            loadfile.ShowDialog(); // show the load dialog window
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Warning! You are about to reset ALL scores!\n" +
                "This action CANNOT be undone!\n" +
                "Are you sure you want to continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,defaultButton:MessageBoxDefaultButton.Button2);

            if(result == DialogResult.Yes)
            {
                if (sessionId == 0)
                {
                    for (int i = 0; i < GameUtility.points.Length; i++)
                    {
                        GameUtility.points[i] = 0;
                    }
                } else
                {
                    for (int i = 0; i < GameUtility.session2Points.Length; i++)
                    {
                        GameUtility.session2Points[i] = 0;
                    }
                }
            }
        }

        //All of these functions relate to updating the GUI. NO TOUCHIE
        delegate void SetTextCallback(string text);
        private void sessionLabelUpdate(string text)
        {
            if (this.sessionLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(sessionLabelUpdate);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.sessionLabel.Text = text;
            }
        }

        private void ipInfoLabelUpdate(Boolean logic)
        {
            if (this.sessionLabel.InvokeRequired)
            {
                SetBoolCallback d = new SetBoolCallback(ipInfoLabelUpdate);
                this.Invoke(d, new object[] { logic });
            }
            else
            {
                this.ipInfoLabel.Visible = logic;
                this.ipInfoLabel.Enabled = logic;
            }
        }

        delegate void SetUpdateCallback(Label c, string text);

        private void updateTextLabel(Label c, string text)
        {
            if (c.InvokeRequired)
            {
                SetUpdateCallback d = new SetUpdateCallback(updateTextLabel);
                c.Invoke(d, new object[] { c, text });
            }
            else
            {
                c.Text = text;
            }
        }

        private void sessionButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Changing Session!");
            if(sessionId == 0)
            {
                sessionId = 1;
                Bracketeers.getCombinations(GameUtility.session2Names);
            } else
            {
                sessionId = 0;
                Bracketeers.getCombinations(GameUtility.names);
            }
        }

        private void ipInfoLabel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("IP info label was clicked. Gathering and Displaying All IPs.");
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            var host = Dns.GetHostEntry(Dns.GetHostName());
            int index = 0;
            string[] IPs = new string[50]; // if a user has more than 50 network adapters god help them
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("An available IP: {0}.", ip.ToString());
                    try
                    {
                        IPs[index] = ip.ToString();
                        index++;
                    } catch(Exception e1)
                    {
                        Console.WriteLine("Exception! {1} {2} User has more than 50 network adapters. I can't handle this! Godspeed user!", e1.ToString(), e1.Message);
                    }
                }
            }
            IPs = IPs.Where(x => !string.IsNullOrEmpty(x)).ToArray(); // Take out the old air, freshen it up a little, and put it back in!
            string allIps = String.Join(Environment.NewLine, IPs);
            MessageBox.Show("All Available IPs: (Each IP is on it's own network adapter." + Environment.NewLine + allIps, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void matchupButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Matchup button was pressed!");
            if(Bracketeers.isShowing)
            {

            } else
            {
                bracketWindow.Show();
                Bracketeers.isShowing = true;
            }
           
        }

        /// <summary>
        /// Let us hope this event handling function is never called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bugButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Report bug button clicked.");
            MessageBox.Show("Now opening bug report page. Please include the following: \n" +
                "Which program experienced the bug (Scoreboard, Leaderboard, or both). \n" +
                "What you were trying to do when the bug occurred.\n" +
                "Any additional comments that could help reproduce the issue so it may be solved.", "Bug Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("https://github.com/TekCastPork/BattleBabs-Competition-Scoreboard-System/issues/new");
        }
    }
}
