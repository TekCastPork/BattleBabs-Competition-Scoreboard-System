using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace BattleBabs_Server
{
    public partial class DisplayStruct : Form
    {
        public static Boolean updateDisplay = false;
        BracketeersStruct brackets = new BracketeersStruct();
        Thread guiUpdate;
        public DisplayStruct()
        {
            InitializeComponent();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            int IPCount = 0; // used for determininbg some label stuff
            updateIPLabel(false);
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("An available IP: {0}.", ip.ToString());
                    ipLabel.Text = ip.ToString();
                    IPCount++; // yo we found a new IP that can communicate
                }
            }
            if (IPCount > 1)
            {
                Console.WriteLine("More than 1 IP was found, enabling the label.");
                Logger.writeWarningLog("More than 1 IP was discovered! Will enable IP list label");;
                updateIPLabel(true);
            }
            guiUpdate = new Thread(new ThreadStart(updateComponents))
            {
                Name = "DisplayUpdate",
                IsBackground = true
            };
            guiUpdate.Start();
            PersistenceStruct.loadTeamData();
            SorterStruct.sortStructure();
        }
        delegate void SetBooleanCallback(Boolean isVisible);
        private void updateIPLabel(Boolean isVisible)
        {
            if(ipAlert.InvokeRequired)
            {
                SetBooleanCallback d = new SetBooleanCallback(updateIPLabel);
                this.Invoke(d, new object[] { isVisible });
            } else
            {
                ipAlert.Visible = isVisible;
            }
        }

        private void updateComponents()
        {
            while (true)
            {
                Thread.Sleep(200);
                if (updateDisplay)
                {
                    updateDisplay = false;
                    GameData.teamData teamInfo = new GameData.teamData();
                    Label[] nameLabels = {
                name1,name2,name3,name4,name5,name6,name7,name8,name9,name10,
                name11,name12,name13,name14,name15,name16,name17,name18
            };
                    Label[] scoreLabels = {
                score1,score2,score3,score4,score5,score6,score7,score8,score9,score10,
                score11,score12,score13,score14,score15,score16,score17,score18
            };
                    Thread.Sleep(200);
                    GameData.teamEntries = GameData.teamEntries.OrderBy(x => x.sessionID).ToList<GameData.teamData>(); // organize by sessionID so that 9 appear in session 1 and 9 appear in session 2
                    Console.WriteLine("Ordered");
                    for (int i = 0; i < GameData.teamEntries.Count; i++)
                    {
                        teamInfo = GameData.teamEntries.ElementAt(17-i);
                        updateLabel(nameLabels[i], teamInfo.name);
                        updateLabel(scoreLabels[i], teamInfo.score.ToString("000,000"));
                     }
                }
            }

        }
        delegate void UpdateCallback(Label label, string message);
        private void updateLabel(Label label, string message)
        {
            if(label.InvokeRequired)
            {
                UpdateCallback d = new UpdateCallback(updateLabel);
                this.Invoke(d,new object[] { label, message });
            } else
            {
                label.Text = message;
            }
        }

        private void showMatchListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(BracketeersStruct.isShowing == false)
            {
                BracketeersStruct.isShowing = true;
                brackets.Show();
            }
        }

        private void ipAlert_Click(object sender, EventArgs e)
        {
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
                    }
                    catch (Exception e1)
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
            MessageBox.Show("All Available IPs: (Each IP is on it's own network adapter)" + Environment.NewLine + allIps, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
