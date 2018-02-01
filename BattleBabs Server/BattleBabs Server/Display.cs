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
using System.IO;

namespace BattleBabs_Server
{
    public partial class Display : Form
    {
        AboutBox about = new AboutBox();
        Thread guiUpdate;
        public Display()
        {
            InitializeComponent();
            Networking.create();
            guiUpdate = new Thread(new ThreadStart(updateComponents));
            guiUpdate.IsBackground = true;            
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("An available IP: {0}.", ip.ToString());
                    ipLabel.Text = "IP: " + ip.ToString();
                }
            }
            guiUpdate.Start();
        }
        delegate void SetTextCallback(string text);

        private void updateComponents()
        {
            while (true)
            {
                Console.WriteLine("Updating screen components");
                Thread.Sleep(500);
                try
                {
                    place1Update(String.Format("{0,8}", "Team: " + GameUtility.names[0]));
                    score1Update(String.Format("{0}", "Points: " + GameUtility.points[0].ToString("000,000")));

                    place2Update(String.Format("{0,8}","Team: " + GameUtility.names[1]));
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
            }
            

        }

        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {

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
            try
            {
                GameUtility.names = File.ReadAllLines(loadfile.FileName);
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
                for(int i = 0; i < GameUtility.points.Length; i++)
                {
                    GameUtility.points[i] = 0;
                }
            }
        }

        //All of these functions relate to updating the GUI. NO TOUCHIE

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
    }
}
