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
            team1.Font = titleFont;
            team2.Font = titleFont;
            team3.Font = titleFont;
            team4.Font = titleFont;
            team5.Font = titleFont;
            team6.Font = titleFont;
            team7.Font = titleFont;
            team8.Font = titleFont;
            team9.Font = titleFont;
            score1.Font = titleFont;
            score2.Font = titleFont;
            score3.Font = titleFont;
            score4.Font = titleFont;
            score5.Font = titleFont;
            score6.Font = titleFont;
            score7.Font = titleFont;
            score8.Font = titleFont;
            score9.Font = titleFont;
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
        }
        delegate void SetTextCallback(string text);
        delegate void SetBoolCallback(Boolean logic);

        private void updateComponents()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (sessionId == 0)
                {
                    try
                    {
                        sessionLabelUpdate("1");
                        place1Update(String.Format("{0,8}", "Team: " + GameUtility.names[0]));
                        score1Update(String.Format("{0}", "Points: " + GameUtility.points[0].ToString("000,000")));

                        place2Update(String.Format("{0,8}", "Team: " + GameUtility.names[1]));
                        score2Update(String.Format("{0}", "Points: " + GameUtility.points[1].ToString("000,000")));

                        place3Update(String.Format("{0,8}", "Team: " + GameUtility.names[2]));
                        score3Update(String.Format("{0}", "Points: " + GameUtility.points[2].ToString("000,000")));

                        place4Update(String.Format("{0,8}", "Team: " + GameUtility.names[3]));
                        score4Update(String.Format("{0}", "Points: " + GameUtility.points[3].ToString("000,000")));

                        place5Update(String.Format("{0,8}", "Team: " + GameUtility.names[4]));
                        score5Update(String.Format("{0}", "Points: " + GameUtility.points[4].ToString("000,000")));

                        place6Update(String.Format("{0,8}", "Team: " + GameUtility.names[5]));
                        score6Update(String.Format("{0}", "Points: " + GameUtility.points[5].ToString("000,000")));

                        place7Update(String.Format("{0,8}", "Team: " + GameUtility.names[6]));
                        score7Update(String.Format("{0}", "Points: " + GameUtility.points[6].ToString("000,000")));

                        place8Update(String.Format("{0,8}", "Team: " + GameUtility.names[7]));
                        score8Update(String.Format("{0}", "Points: " + GameUtility.points[7].ToString("000,000")));

                        place9Update(String.Format("{0,8}", "Team: " + GameUtility.names[8]));
                        score9Update(String.Format("{0}", "Points: " + GameUtility.points[8].ToString("000,000")));

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception! {0}", e.Message);
                    }
                } else
                {
                    try
                    {
                        sessionLabelUpdate("2");
                        place1Update(String.Format("{0,8}", "Team: " + GameUtility.session2Names[0]));
                        score1Update(String.Format("{0}", "Points: " + GameUtility.session2Points[0].ToString("000,000")));

                        place2Update(String.Format("{0,8}", "Team: " + GameUtility.session2Names[1]));
                        score2Update(String.Format("{0}", "Points: " + GameUtility.session2Points[1].ToString("000,000")));

                        place3Update(String.Format("{0,8}", "Team: " + GameUtility.session2Names[2]));
                        score3Update(String.Format("{0}", "Points: " + GameUtility.session2Points[2].ToString("000,000")));

                        place4Update(String.Format("{0,8}", "Team: " + GameUtility.session2Names[3]));
                        score4Update(String.Format("{0}", "Points: " + GameUtility.session2Points[3].ToString("000,000")));

                        place5Update(String.Format("{0,8}", "Team: " + GameUtility.session2Names[4]));
                        score5Update(String.Format("{0}", "Points: " + GameUtility.session2Points[4].ToString("000,000")));

                        place6Update(String.Format("{0,8}", "Team: " + GameUtility.session2Names[5]));
                        score6Update(String.Format("{0}", "Points: " + GameUtility.session2Points[5].ToString("000,000")));

                        place7Update(String.Format("{0,8}", "Team: " + GameUtility.session2Names[6]));
                        score7Update(String.Format("{0}", "Points: " + GameUtility.session2Points[6].ToString("000,000")));

                        place8Update(String.Format("{0,8}", "Team: " + GameUtility.session2Names[7]));
                        score8Update(String.Format("{0}", "Points: " + GameUtility.session2Points[7].ToString("000,000")));

                        place9Update(String.Format("{0,8}", "Team: " + GameUtility.session2Names[8]));
                        score9Update(String.Format("{0}", "Points: " + GameUtility.session2Points[8].ToString("000,000")));

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

        private void place1Update(string text)
        {
            if (this.team1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place1Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team1.Text = text;
            }
        }
        private void place2Update(string text)
        {
            if (this.team2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place2Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team2.Text = text;
            }
        }
        private void place3Update(string text)
        {
            if (this.team3.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place3Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team3.Text = text;
            }
        }
        private void place4Update(string text)
        {
            if (this.team4.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place4Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team4.Text = text;
            }
        }
        private void place5Update(string text)
        {
            if (this.team5.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place5Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team5.Text = text;
            }
        }
        private void place6Update(string text)
        {
            if (this.team6.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place6Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team6.Text = text;
            }
        }
        private void place7Update(string text)
        {
            if (this.team7.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place7Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team7.Text = text;
            }
        }
        private void place8Update(string text)
        {
            if (this.team8.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place8Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team8.Text = text;
            }
        }
        private void place9Update(string text)
        {
            if (this.team9.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place9Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team9.Text = text;
            }
        }

        private void score1Update(string text)
        {
            if (this.score1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(score1Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score1.Text = text;
            }
        }
        private void score2Update(string text)
        {
            if (this.score2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(score2Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score2.Text = text;
            }
        }
        private void score3Update(string text)
        {
            if (this.score3.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(score3Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score3.Text = text;
            }
        }
        private void score4Update(string text)
        {
            if (this.score4.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(score4Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score4.Text = text;
            }
        }
        private void score5Update(string text)
        {
            if (this.score5.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(score5Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score5.Text = text;
            }
        }
        private void score6Update(string text)
        {
            if (this.score6.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(score6Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score6.Text = text;
            }
        }
        private void score7Update(string text)
        {
            if (this.score7.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(score7Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score7.Text = text;
            }
        }
        private void score8Update(string text)
        {
            if (this.score8.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(score8Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score8.Text = text;
            }
        }
        private void score9Update(string text)
        {
            if (this.score9.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(score9Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score9.Text = text;
            }
        }

        private void sessionButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Changing Session!");
            if(sessionId == 0)
            {
                sessionId = 1;
            } else
            {
                sessionId = 0;
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

        int arenaNumber = 0;
        private void matchupButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Matchup button was pressed!");
           /* string[] receivedMatch = Bracket.getNextMatch();
            GameUtility.makeSpeech("The next match is " + receivedMatch[0] + " VS " + receivedMatch[1] + " on arena " + (arenaNumber+1));
            MessageBox.Show("The next match is " + receivedMatch[0] + " VS " + receivedMatch[1] + " on arena " + (arenaNumber+1), "NEXT MATCH", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(arenaNumber == 0)
            {
                arenaNumber = 1;
            } else
            {
                arenaNumber = 0;
            } */
        }
    }
}
