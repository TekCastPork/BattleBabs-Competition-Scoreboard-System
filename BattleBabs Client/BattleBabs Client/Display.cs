using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace BattleBabs_Client
{
    public partial class Display : Form
    {
        RefForm referee = new RefForm();        
        public static ArduinoForm arduinoForm = new ArduinoForm();
        public static string team1 = "Team1";
        public static string team2 = "Team2";
        public static int team1Score = 0;
        public static int team2Score = 0;
        public static Boolean teamOpen = false;
        public static Team_Entry teamEntryForm = new Team_Entry();
        AboutBox about = new AboutBox();
        NetworkWindow networking = new NetworkWindow();
        RefFormSettings refSettings = new RefFormSettings();
        Settings settingWindow = new Settings();
        Thread GUIupdate;
        public static Boolean screenMode = false;



        public Display()
        {
            InitializeComponent();
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(Path.Combine(Application.StartupPath, "erbos_draco_1st_open_nbp.ttf"));
            privateFonts.AddFontFile(Path.Combine(Application.StartupPath, "GODOFWAR.TTF"));
            System.Drawing.Font scoreFont = new Font(privateFonts.Families[0], 27);
            System.Drawing.Font timeFont = new Font(privateFonts.Families[0], 40);
            System.Drawing.Font titleFont = new Font(privateFonts.Families[1], 36);
            team1Name.Font = titleFont;
            team2Name.Font = titleFont;
            team2ScoreLbl.Font = scoreFont;
            team1ScoreLbl.Font = scoreFont;
            timerLabel.Font = timeFont;
            titleLabel.Font = titleFont;
            GameUtility.setupObjects();
            GUIupdate = new Thread(new ThreadStart(updateComponents)); // create a GUI updating thread
            GUIupdate.IsBackground = true; // make the GUI updating thread a background thread so it closes when the window closes
            GUIupdate.Start(); // start the GUI updating thread
            referee.Show(); // create the referee window so that points can be allocated and team names set
            GoFullscreen(screenMode); // set the fullscreen mode
       //     PipeClient.connectToPipe(System.IO.Pipes.PipeDirection.InOut); // call the method that attempts to connect to the server's network pipe
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
                teamOpen = true;
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
             //   GoFullscreen(screenMode);
                SetTeam1Text(team1);
                SetTeam2Text(team2);
                SetTeam1Score(team1Score.ToString());
                SetTeam2Score(team2Score.ToString());
                if (GameUtility.gameTime <= 99)
                {
                    SetTimerText(GameUtility.getGameTime().ToString("00.00"));
                } else
                {
                    SetTimerText(GameUtility.getGameTime().ToString("000.00"));
                }
                Thread.Sleep(50);
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
            if (this.team2Name.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTeam2Text);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team2Name.Text = text;
            }
        }

        private void SetTeam1Score(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.team1ScoreLbl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTeam1Score);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team1ScoreLbl.Text = text;
            }
        }

        private void SetTeam2Score(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.team2ScoreLbl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTeam2Score);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.team2ScoreLbl.Text = text;
            }
        }

        private void SetTimerText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.timerLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTimerText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.timerLabel.Text = text;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        public static Boolean connectOpen = false;

        private void connectButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("connect button was clicked.");
            if (connectOpen == false)
            {
                arduinoForm.Show();
                connectOpen = true;
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
           if(AboutBox.isShowing == false) {
                about.Show();
                AboutBox.isShowing = true;
            } 
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingWindow.Show();
        }

        private void networkButton_Click(object sender, EventArgs e)
        {
            if(NetworkWindow.isOpen == false)
            {
                networking.Show();
                NetworkWindow.isOpen = true;
            }
        }

        private void bugButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Report bug button clicked.");
            MessageBox.Show("Now opening bug report page. Please include the following: \n" +
                "Which program experienced the bug (Scoreboard, Leaderboard, or both). \n" +
                "What you were trying to do when the bug occurred.\n" +
                "The log file located in the Logs folder located in the installation folder (close the program before uploading the log)\n" +
                "Any additional comments that could help reproduce the issue so it may be solved.", "Bug Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("https://github.com/TekCastPork/BattleBabs-Competition-Scoreboard-System/issues/new");
        }

        private void scoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(RefFormSettings.isShowing == false)
            {
                refSettings.Show();
                RefFormSettings.isShowing = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void networkingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void connectToArduinoControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generalToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
