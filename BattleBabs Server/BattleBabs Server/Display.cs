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
            InitializeComponent();
            ipInfoLabelUpdate(false);
            Networking.create();
            guiUpdate = new Thread(new ThreadStart(updateComponentData));
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
                Logger.writeWarningLog("More than 1 IP was discovered! Will enable IP list label");
                ipInfoLabelUpdate(true);
            }
            guiUpdate.Start();
            try
            {
                // put load here
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception! {0}", e.Message);
                Logger.writeExceptionLog(e);
            }

            if (sessionId == 0)
            {
                bracketWindow = new Bracketeers(GameUtility.session1TeamNames);
            } else
            {
                bracketWindow = new Bracketeers(GameUtility.session2TeamNames);
            }
        }

        delegate void SetBoolCallback(Boolean logic);
        delegate void SetTextCallback(string text);
        delegate void SetUpCallback();

        /// <summary>
        /// Updates the score and name labels based on the structure array
        /// </summary>
        private void updateComponentData()
        {
            int entryIndex = 0;
            GameUtility.teamData teamInfo = new GameUtility.teamData();
            Label[] nameLabels = { team1, team2, team3, team4, team5, team6, team7, team8, team9 };
            Label[] scoreLabels = { score1, score2, score3, score4, score5, score6, score7, score8, score9 };
            foreach(Label c in nameLabels)
            {
                teamInfo = GameUtility.teamEntries.ElementAt<GameUtility.teamData>(entryIndex);
                if(c.InvokeRequired)
                {
                    SetUpCallback d = new SetUpCallback(updateComponentData);
                    this.Invoke(d, new object[] { });                    
                } else
                {
                    c.Text = teamInfo.name;
                    scoreLabels[entryIndex].Text = teamInfo.score.ToString();
                }
            }

        }

        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("FORM CLOSING, RUN SAVE PROCEDURE");
            //Place saving of data here
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
                GameUtility.teamEntries.RemoveRange(0, GameUtility.teamEntries.Count);
                for(int i = 0; i < loadedNames.Length; i++)
                {
                    GameUtility.teamData teamInfo = new GameUtility.teamData();
                    string[] splitTeamData = loadedNames[i].Split(':');
                    teamInfo.name = splitTeamData[0];
                    teamInfo.score = int.Parse(splitTeamData[1]);
                    teamInfo.rank = int.Parse(splitTeamData[2]);
                    teamInfo.sessionID = int.Parse(splitTeamData[3]);
                    GameUtility.teamEntries.Insert(i, teamInfo);
                    GameUtility.teamCount++;
                }
            } catch(Exception e1)
            {
                Console.WriteLine("Exception! {0}", e1.Message);
                Logger.writeExceptionLog(e1);
            }
        }

        //All of these functions relate to updating the GUI. NO TOUCHIE        
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

        private void ipInfoLabel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("IP info label was clicked. Gathering and Displaying All IPs.");
            Logger.writeGeneralLog("IP info label was clicked, now gathering all available IPs to display");
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
                  //      Console.WriteLine("Exception! {1} {2} User has more than 50 network adapters. I can't handle this! Godspeed user!", e1.ToString(), e1.Message);
                        Logger.writeExceptionLog(e1);
                        MessageBox.Show("ERROR! THE AMOUNT OF NETWORK ADAPTERS PLUGGED INTO THIS MACHINE EXCEEDS WHAT MY PROGRAMMER GIFTED ME!\n" +
                            "NORMALLY YOU SHOULDN'T SEE THIS ERROR!\n" +
                            "IF YOU'RE A USER AND YOU'RE SEEING THIS: GODSPEED!\n" +
                            "(TLDR: Theres more IPs than what I can list)", "DEAR GOD WHY!!!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                    }
                }
            }
            IPs = IPs.Where(x => !string.IsNullOrEmpty(x)).ToArray(); // Take out the old air, freshen it up a little, and put it back in!
            string allIps = String.Join(Environment.NewLine, IPs);
            MessageBox.Show("All Available IPs: (Each IP is on it's own network adapter." + Environment.NewLine + allIps, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutThisSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AboutBox.isShowing == false)
            {
                AboutBox.isShowing = true;
                about.Show();
                Logger.writeGeneralLog("About button was clicked, showing the about box");
            }
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/TekCastPork/BattleBabs-Competition-Scoreboard-System/issues/new");
        }

        private void switchSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Changing Session!");
            Logger.writeGeneralLog("Session button was clicked, changing session number");
            Logger.writeWarningLog("This will cause all combinations to be re-calculated");
            if (sessionId == 0)
            {
                sessionId = 1;
                Bracketeers.getCombinations(GameUtility.session2TeamNames);
            }
            else
            {
                sessionId = 0;
                Bracketeers.getCombinations(GameUtility.session1TeamNames);
            }
        }

        private void matchListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Matchup button was pressed!");
            if (Bracketeers.isShowing)
            {
                
            }
            else
            {
                bracketWindow.Show();
                Bracketeers.isShowing = true;
            }
        }

        private void loadTeamNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadfile.ShowDialog(); // show the load dialog window
            Logger.writeGeneralLog("Showing load dialog since load button was clicked");
        }


        private void resetScoresCANNOTBEUNDONEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Warning! You are about to reset ALL scores for BOTH session 1 AND session 2!\n" +
                "This action CANNOT be undone!\n" +
                "The current scores for BOTH sessions WILL be PERMAMENTLY forgotten!\n" +
                "Are you sure you want to continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, defaultButton: MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (sessionId == 0)
                {
                    GameUtility.teamData teamInfo = new GameUtility.teamData();
                    Logger.writeGeneralLog("Erasing scores for session 1 teams");
                    for(int i = 0; i < GameUtility.teamEntries.Count; i++)
                    {
                        teamInfo = GameUtility.teamEntries.ElementAt<GameUtility.teamData>(i);
                        if(teamInfo.sessionID == 0)
                        {
                            Logger.writeGeneralLog(String.Format("sessionID of strucutre at location {0} matches sessionID that is being erased.", i));
                            teamInfo.score = 0;
                            Logger.writeGeneralLog("structure score reset, replacing structure in list");
                            GameUtility.teamEntries.RemoveAt(i);
                            GameUtility.teamEntries.Insert(i, teamInfo);
                        }
                    }
                }
                else
                {
                    GameUtility.teamData teamInfo = new GameUtility.teamData();
                    Logger.writeGeneralLog("Erasing scores for session 2 teams");
                    for (int i = 0; i < GameUtility.teamEntries.Count; i++)
                    {
                        teamInfo = GameUtility.teamEntries.ElementAt<GameUtility.teamData>(i);
                        if (teamInfo.sessionID == 1)
                        {
                            Logger.writeGeneralLog(String.Format("sessionID of strucutre at location {0} matches sessionID that is being erased.", i));
                            teamInfo.score = 0;
                            Logger.writeGeneralLog("structure score reset, replacing structure in list");
                            GameUtility.teamEntries.RemoveAt(i);
                            GameUtility.teamEntries.Insert(i, teamInfo);
                        }
                    }
                }
            }
        }
    }
}
