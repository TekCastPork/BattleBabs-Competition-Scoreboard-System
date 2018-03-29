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
        public static System.Media.SoundPlayer buzzer = new SoundPlayer(Properties.Resources.Buzzer);
        public static int gameTime = 75; // default match time will be 1 minute 15 seconds, as requested
        public static Boolean doSend = false; // used only for the first match to not broadcast stuff
        static string lastTeam1; // used for broadcasting
        static string lastTeam2; // used for broadcasting
        public static string compName = "Robert Thirsk's Bi-Annual BattleBots Competition"; // competition's name
        public static Boolean showChanges = true;
        /// <summary>
        /// matchState has 3 states, 0, 1, 2.
        /// State 0 means the game is stopped. State 1 is match running State 2 is match is paused, and can only be resumed or stopped.
        /// there is no restart state.
        /// </summary>
        public static int matchState = 0;

        public static int SEED = 1337; // seed for random number generation via specified seed
        public static Boolean useSeeded = false; // enables random override
        static float currentTime = 0.0f; // current time used for match times
        static Random RNGesus = new Random(); // Pray to him! Kappa, this one does not have a pre-set seed, so it will seed based on the time
        static Random RNGesusSeed;
        static int previousSongID = -1; // used with RNGesus (both seeded and unseeded) for picking the next song

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
            Networking.create();
        }

        public static void setSeed()
        {
            RNGesusSeed = new Random(SEED); // use if you want to debug via seeding
            Console.WriteLine("RNGesesSeed made");
        }

        public static void setRandomSong() // uses RNG to pick a new song to play, so long as it wasnt just played
        {
            int RNGResult = 0; // result of the RNG
            System.IO.Stream str = null; // stream instance for use with audio
            while (true) // while true statement for randomly choosing the next song, dont worry t breaks eventually
            {
                if (useSeeded)
                {
                    RNGResult = RNGesusSeed.Next(0, 7);
                }
                else
                {
                    RNGResult = RNGesus.Next(0, 7); // get the next value according to the RNG for use with picking the song
                }
                if(RNGResult != previousSongID) // is the "new" song the same as the last one?
                {
                    // It was not! make it the new song
                    Console.WriteLine("RNG result wasnt revious song! Using chosen value.");
                    previousSongID = RNGResult; // set the previous song ID to the new one for next time
                    break; // break the while loop
                } else
                {
                    // It was the same, reroll the RNG
                    Console.WriteLine("RNG result matched previous song, re-rolling.");
                }
            }
            Console.WriteLine("Selected number is {0}", RNGResult);
            switch (RNGResult) // switch for determining the song to play, this means however that the songs are hardcoded and cannot be changed easily
            {
                case 0: // case 0 and default will both be Popcorn techno. default is here to prevent potential crashes
                default:
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
                case 4:
                    str = Properties.Resources.Guile_s_Theme;
                    music.Stream = str;
                    break;
                case 5:
                    str = Properties.Resources.Trainer_Battle;
                    music.Stream = str;
                    break;
                case 6:
                    str = Properties.Resources.Ryu_s_Theme;
                    music.Stream = str;
                    break;
                case 7:
                    str = Properties.Resources.Sonic2_Zone;
                    music.Stream = str;
                    break;
            }
            
                 
        }

        public static void makeSpeech(string msg) // uses the TTS engine to talk
        {
            synth.SpeakAsync(msg); // do some robit speak stuff
        }

        public static void alterGameTime(int newTime) // used to change the duration of a match
        {
            gameTime = newTime; // set the game time to the specified value
            Console.WriteLine("New game time is {0} seconds.", gameTime);
        }


        public static void beginMatch() // start a match's timer and will handle other match start events
        {
            if (matchState == 0)
            {
                if(doSend)
                {
                    Console.WriteLine("Broadcasting previous match's data before clearing");
                    Networking.sendData("0:0" + ":" + Display.team1 + ":" + Display.team2);
                    //Send data like: "000:000:team1:team2"
                }
                else
                {
                    Console.WriteLine("Do Send was false, still will send data so robin is updated but will send with scores of 0\n" +
                        "This usually happens when send was clicked or when the program first runs.");
                    Networking.sendData("0:0" + ":" + Display.team1 + ":" + Display.team2);
                    doSend = true;
                }
                Console.WriteLine("Game timer started since the match is starting");
                Display.team1Score = 0;
                Display.team2Score = 0;
                setRandomSong();
                music.Play(); // start the audio
                currentTime = gameTime;
                gameTimer.Start(); // start the game timer
                matchState = 1;
            }
        }

        public static void resumeMatch()
        {
            if (matchState == 2)
            {
                makeSpeech("Resuming Match.");
                gameTimer.Start();
                music.Play();
                matchState = 1;
            }
        } // resumes the match is it was paused

        public static void endMatch() // ends the match's timer and will handle other end match events
        {
            if (matchState != 0) // this will run as long as the match state isnt already 0
            {
                gameTimer.Stop(); // stop the game timer
                Console.WriteLine("Game timer stopped since match is ending.");                
                music.Stop(); // stop the audio from playing
                buzzer.Play(); // play that sicc buzzer sound
                matchState = 0; // set the match state to 0
                currentTime = 0.0f; // set match time to 0
                lastTeam1 = Display.team1; // move the name of Team 1 to a internal variable within this class so that it is sent with the score data, since the user may change it before that happens
                lastTeam2 = Display.team2; // move the name of Team 2 to a internal variable within this class so that it is sent with the score data, since the user may change it before that happens
                if (doSend)
                {
                    Networking.sendData(Display.team1Score + ":" + Display.team2Score + ":" + lastTeam1 + ":" + lastTeam2);
                }
            }
        }

        public static void pauseMatch()
        {
            if (matchState == 1)
            {
                gameTimer.Stop();
                Console.WriteLine("Match Paused.");
                music.Stop();
                makeSpeech("The referee paused the game.");
                matchState = 2;
            }
        } // pause a match. Un-pauseable only through stopping or resuming, not starting


        public static void handleTimerTicks (object sender, System.Timers.ElapsedEventArgs e) // handles timer ticks
        {
            currentTime -= 0.01f;
            if(currentTime < 0.0f)
            {
                Console.WriteLine("match time hit 0!");
                endMatch();
                currentTime = 0.00f;
            }

        }
    }
}
