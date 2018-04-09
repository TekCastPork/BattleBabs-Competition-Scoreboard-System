using System;
using System.Speech.Synthesis;
using System.Collections.Generic;

namespace BattleBabs_Server
{
    class GameUtility
    {
        public static int teamCount = 99;
        /// <summary>
        /// A structure to contain information about each team.
        /// enterable data follows
        /// <para>string name</para>
        /// <para>int score</para>
        /// <para>int rank</para>
        /// <para>int ID</para>
        /// </summary>
        public struct teamData
        {
            public string name;
            public int score;
            public int rank;
            public int sessionID;
        };

        public static string[] session1TeamNames = new string[9];
        public static string[] session2TeamNames = new string[9];
        public static List<teamData> teamEntries = new List<teamData>();


        /// <summary>
        /// This list will hold all team entries
        /// </summary>
        static SpeechSynthesizer synth = new SpeechSynthesizer(); // make a TTS instance so we can so text to speech
        public static void makeSpeech(string msg) // uses the TTS engine to talk
        {
            synth.SpeakAsync(msg); // do some robit speak stuff
        }
    }
}
