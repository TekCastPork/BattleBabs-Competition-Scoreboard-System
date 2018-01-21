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
using System.Media;
using System.Collections.Generic;
using System.IO;

namespace Display
{
    public partial class Display : Form
    {
        RefForm referee = new RefForm();
        SoundPlayer musicPlayer;
        public static ArduinoForm arduinoForm = new ArduinoForm();
        public static string team1 = "Team1";
        public static string team2 = "Team2";
        public static Boolean teamOpen = false;
        public static Team_Entry teamEntryForm = new Team_Entry();
        public static Boolean enableMatch = true;

        Thread GUIupdate, threadedTimerEvents;
        System.Timers.Timer gameTime;
        public int timerCount = 75; // an indexing number to be used with the timer to determine game time
        public Display()
        {
            InitializeComponent();
            PlayBeep(440, 500);
            musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = "";
            gameTime = new System.Timers.Timer(); // create a timer
            gameTime.Interval = 1000;
            gameTime.AutoReset = true;
            gameTime.Elapsed += handleTimerTicks;
            gameTime.Enabled = false;
            GUIupdate = new Thread(new ThreadStart(updateComponents)); // create a GUI updating thread
            threadedTimerEvents = new Thread(new ThreadStart(timerThread));
            GUIupdate.IsBackground = true; // make the GUI updating thread a background thread so it closes when the window closes
            GUIupdate.Start(); // start the GUI updating thread
            threadedTimerEvents.IsBackground = true;
            threadedTimerEvents.Start();
            referee.Show(); // create the referee window so that points can be allocated and team names set
            GoFullscreen(false); // set the fullscreen mode
            PipeClient.connectToPipe(System.IO.Pipes.PipeDirection.InOut); // call the method that attempts to connect to the server's network pipe
        }

        private void timerThread()
        {
            while (true)
            {
                Thread.Sleep(500);
                if(timerCount <= 0)
                {
                    Console.WriteLine("Timer has hit 0! Match ends now!");
                }
            }

        }

        private void handleTimerTicks(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Timer tick!");
            timerCount--; // countdown to 0 for game time display
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
                SetTeam1Text(team1);
                SetTeam2Text(team2);
                SetTimerText(timerCount.ToString());
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

        public static void PlayBeep(UInt16 frequency, int msDuration, UInt16 volume = 16383)
        {
            var mStrm = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(mStrm);

            const double TAU = 2 * Math.PI;
            int formatChunkSize = 16;
            int headerSize = 8;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int samples = (int)((decimal)samplesPerSecond * msDuration / 1000);
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            // var encoding = new System.Text.UTF8Encoding();
            writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
            writer.Write(fileSize);
            writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
            writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(0x61746164); // = encoding.GetBytes("data")
            writer.Write(dataChunkSize);
            {
                double theta = frequency * TAU / (double)samplesPerSecond;
                // 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
                // we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
                double amp = volume >> 2; // so we simply set amp = volume / 2
                for (int step = 0; step < samples; step++)
                {
                    short s = (short)(amp * Math.Sin(theta * (double)step));
                    writer.Write(s);
                }
            }

            mStrm.Seek(0, SeekOrigin.Begin);
            new System.Media.SoundPlayer(mStrm).Play();
            writer.Close();
            mStrm.Close();
        } // public static void PlayBeep(UInt16 frequency, int msDuration, UInt16 volume = 16383)
    }
}
