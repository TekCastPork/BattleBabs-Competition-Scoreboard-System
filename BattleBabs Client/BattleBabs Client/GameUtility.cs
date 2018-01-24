using System;
using System.Speech.Synthesis;
using System.Media;

namespace BattleBabs_Client
{
    /// <summary>
    /// GameUtility is used for things like timers and speech synthesis, or music during the match
    /// </summary>
    class GameUtility
    {
        static SpeechSynthesizer synth = new SpeechSynthesizer(); // make a TTS instance so we can so text to speech
        static System.Timers.Timer gameTimer = new System.Timers.Timer(); // create a timer for making the match a specific length
        public static System.Media.SoundPlayer music = new SoundPlayer(Properties.Resources.Heart_of_Courage);
        public static int gameTime = 120; // default match time will be 1 minute 15 seconds, as requested
        static float currentTime = 0.0f; // current time used for match times
        static Random RNGesus = new Random(); // Pray to him! Kappa
        static int previousSongID = -1; // used with RNGesus for picking the next song

        public static float getGameTime()
        {
            return (float)Math.Round(currentTime, 2);
        } // returns the current match time

        public static void setupObjects() // must be called before using any other functions!
        {
            gameTimer.Stop(); // make sure it dont start ticking
            gameTimer.Interval = 10; //10 milliseconds per call, allowing for 2 decimal place on the timer
            gameTimer.AutoReset = true; //keep resetting timer as it goes off
            gameTimer.Elapsed += handleTimerTicks;
            setRandomSong();
        }

        public static void setRandomSong() // uses RNG to pick a new song to play, so long as it wasnt just played
        {
            int RNGResult = 0; // result of the RNG
            System.IO.Stream str = null; // stream instance for use with audio
            while (true) // while true statement for randomly choosing the next song, dont worry t breaks eventually
            {
                RNGResult = RNGesus.Next(0, 3); // get the next value according to the RNG for use with picking the song
                if(RNGResult != previousSongID) // is the "new" song the same as the last one?
                {
                    // It was not! make it the new song
                    Console.WriteLine("RNG result wasnt revious song! Using chosen value.");
                    previousSongID = RNGResult;
                    break;
                } else
                {
                    // It was the same, reroll the RNG
                    Console.WriteLine("RNG result matched previous song, re-rolling.");
                }
            }            
            switch (RNGResult) // switch for determining the song to play, this means however that the songs are hardcoded and cannot be changed easily
            {
                case 0:
                    str = Properties.Resources.Popcorn_Techno;
                    music.Stream = str; // set the new song stream source 
                    break;
                case 1:
                    str = Properties.Resources.Ken_s_Theme;
                    music.Stream = str; // set the new song stream source 
                    break;
                case 2:
                    str = Properties.Resources.Heart_of_Courage;
                    music.Stream = str; // set the new song stream source 
                    break;
                case 3:
                    str = Properties.Resources.Tetris_B;
                    music.Stream = str; // set the new song stream source 
                    break;
                default:
                    str = Properties.Resources.Popcorn_Techno;
                    music.Stream = str; // set the new song stream source 
                    break;
            }
                 
        }

        public static void makeSpeech(string msg) // uses the TTS engine to talk
        {
            synth.Speak(msg); // do some robit speak stuff
        }

        public static void alterGameTime(int newTime) // used to change the duration of a match
        {
            gameTime = newTime; // set the game time to the specified value
        }

        public static void beginMatch() // start a match's timer and will handle other match start events
        {
            
            Console.WriteLine("Game timer started since the match is starting");
            setRandomSong();
            music.Play(); // start the audio
            currentTime = gameTime;
            gameTimer.Start(); // start the game timer
        }

        public static void resumeMatch()
        {
            makeSpeech("Resuming Match.");
            gameTimer.Start();
            music.Play();
        }

        public static void endMatch() // ends the match's timer and will handle other end match events
        {
            gameTimer.Enabled = false; // stop the game timer
            Console.WriteLine("Game timer stopped since match is ending.");
            music.Stop(); // stop the audio from playing
            setRandomSong(); // pick a new song randomly
        }

        public static void pauseMatch()
        {
            gameTimer.Stop();
            Console.WriteLine("Match Paused.");
            music.Stop();
            makeSpeech("The referee paused the game.");
        }

        public static void handleTimerTicks (object sender, System.Timers.ElapsedEventArgs e) // handles timer ticks
        {
            Console.WriteLine("Timer Tick!");
            currentTime -= 0.01f;
            if(currentTime < 0.0f)
            {
                Console.WriteLine("match time hit 0!");
                endMatch();
                music.Stop();
                currentTime = 0.00f;
            }

        }
    }
}
