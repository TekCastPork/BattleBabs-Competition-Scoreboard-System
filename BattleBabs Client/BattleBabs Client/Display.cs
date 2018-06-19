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
        Boolean lastScreenState = false;
        Thread GUIupdate;
        public static Boolean screenMode = false;



        public Display()
        {
          
            InitializeComponent();
           
            GameUtility.setupObjects();

            GUIupdate = new Thread(new ThreadStart(updateComponents))
            {
                Name = "Display_GUI_Update",
                IsBackground = true // make the GUI updating thread a background thread so it closes when the window closes
            }; // create a GUI updating thread
            GUIupdate.Start(); // start the GUI updating thread
           
            referee.Show(); // create the referee window so that points can be allocated and team names set

            GoFullscreen(screenMode); // set the fullscreen mode

        }

        delegate void SetBooleanCallback(Boolean state);

        /// <summary>
        /// Allows the toggling of fullscreen for this display
        /// </summary>
        /// <param name="fullscreen"></param>
        private void GoFullscreen(bool fullscreen)
        {
          
            if (this.InvokeRequired)
            {
              
                SetBooleanCallback d = new SetBooleanCallback(GoFullscreen);
                this.Invoke(d, new object[] { fullscreen });
            }
            else
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
        }

        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            GUIupdate.Abort();
          
            referee.Close();
            referee.Dispose();
        }

        //GUI UPDATING FUNCTIONS

        private void updateComponents()
        {
            while (true)
            {
                SetTeam1Text(team1);
                SetTeam2Text(team2);
                SetTeam1Score(team1Score.ToString());
                SetTeam2Score(team2Score.ToString());
                SetTitleText(GameUtility.compName);
                if(screenMode != lastScreenState)
                {
                    lastScreenState = screenMode;
                    GoFullscreen(lastScreenState);
                }
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

        private void SetTitleText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.titleLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTitleText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.titleLabel.Text = text;
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

        //EVENTS

        private void exitButton_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        public static Boolean connectOpen = false;

        private void connectToArduinoControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("connect button was clicked.");
            if (connectOpen == false)
            {
                arduinoForm.Show();
                connectOpen = true;
            }
        }

        
    }
}
