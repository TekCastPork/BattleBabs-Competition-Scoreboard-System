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
using System.Timers;

namespace Display
{
    public partial class Display : Form
    {
        RefForm referee = new RefForm();
        public static string team1 = "Team1";
        public static string team2 = "Team2";
        public static Boolean teamOpen = false;
        public static Team_Entry teamEntryForm = new Team_Entry();

        Thread GUIupdate;
        public Display()
        {
            InitializeComponent();
            GUIupdate = new Thread(new ThreadStart(updateComponents));
            GUIupdate.IsBackground = true;
            GUIupdate.Start();
            referee.Show();
            GoFullscreen(false);
            PipeClient.connectToPipe(System.IO.Pipes.PipeDirection.InOut);
        }

        /// <summary>
        /// Allows the toggling of fullscreen for this display
        /// </summary>
        /// <param name="fullscreen"></param>
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        /// <summary>
        /// This function handles team change button click events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teamChange_Click(object sender, EventArgs e)
        {
            Console.WriteLine("teamChange button was clicked.");
            if (teamOpen == false)
            {
                teamEntryForm.Show();
            }
        }

        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            GUIupdate.Abort();
            referee.Close();
            referee.Dispose();
        }

        private void updateComponents()
        {
            while (true)
            {
                SetTeam1Text(team1);
                SetTeam2Text(team2);
                Thread.Sleep(500);
            }
        }

        delegate void SetTextCallback(string text);

        private void SetTeam1Text(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.team1Name.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTeam1Text);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team1Name.Text = text;
            }
        }

        private void SetTeam2Text(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.team1Name.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTeam2Text);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team2Name.Text = text;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

    }
}
