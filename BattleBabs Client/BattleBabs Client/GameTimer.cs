using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Media;
using System.Threading;
using System.Timers;

namespace Display
{
    class GameUtility
    {
        static SpeechSynthesizer synth = new SpeechSynthesizer();
        static SoundPlayer musicPlayer = new SoundPlayer();
        static System.Timers.Timer gameTimer = new System.Timers.Timer();
        static int gameTime = 75; // default will be 1 minute 15 seconds
        static int currentTime = 0;

        public static void setupObjects()
        {
            gameTimer.Enabled = false; // make sure it dont start ticking
            gameTimer.Interval = 1000; //1000 milliseconds per call
            gameTimer.AutoReset = true; //keep resetting timer as it goes off
            gameTimer.Elapsed += handleTimerTicks;
        }
        

        public static void setSongLocation(string path)
        {
            musicPlayer.SoundLocation = path;
        }

        public static void makeSpeech(string msg)
        {
            synth.SpeakAsync(msg);
        }

        public static void alterGameTime(int newTime)
        {
            gameTime = newTime;
        }

        public static void beginMatchTimer()
        {

        }

        public static void handleTimerTicks (object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Timer Tick!");

        }
    }
}
