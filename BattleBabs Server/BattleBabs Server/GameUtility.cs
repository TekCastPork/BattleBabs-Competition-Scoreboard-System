﻿using System;
using System.Speech.Synthesis;

namespace BattleBabs_Server
{
    class GameUtility
    {
        static SpeechSynthesizer synth = new SpeechSynthesizer(); // make a TTS instance so we can so text to speech
        public static string[] names =  { "TestName", "Team2", "ImmaTeam3", "Haiku", "Bab", "Bhab", "Robitz", "LulBot", "TAS" }; // names used on leaderboard, name names for clent program
        public static string[] session2Names = { "", "", "", "", "", "", "", "", "" };
        public static string[] sortedNames = new string[9];
        public static int[] sortedScores = new int[9];
   //     public static int[] round =     { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0  };
        public static int[] points =    { 1337 , 25843 , 0 , 0 , 0 , 0 , 0 , 0 , 0  };
        public static int[] session2Points = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
   //     public static int[] rank =      { 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9  };
        public static int[] parsedScores = { 0, 0 };
        public static string[] receivedNames = { "", "", };

        public static void makeSpeech(string msg) // uses the TTS engine to talk
        {
            synth.SpeakAsync(msg); // do some robit speak stuff
        }

        public static void addScores()
        {
            Console.WriteLine("Finding names and adding scores");
            for(int i = 0; i < names.Length; i++)
            {
                if (Display.sessionId == 0)
                {
                    if (names[i].Equals(receivedNames[0]))
                    {
                        Console.WriteLine("input name {0} matches name {1} at index {2}", receivedNames[0], names[i], i);
                        Console.WriteLine("Adding score.");
                        points[i] += parsedScores[0];
                    }
                    else if (names[i].Equals(receivedNames[1]))
                    {
                        Console.WriteLine("input name {0} matches name {1} at index {2}", receivedNames[1], names[i], i);
                        Console.WriteLine("Adding score.");
                        points[i] += parsedScores[1];
                    }
                } else
                {
                    if (session2Names[i].Equals(receivedNames[0]))
                    {
                        Console.WriteLine("input name {0} matches name {1} at index {2}", receivedNames[0], session2Names[i], i);
                        Console.WriteLine("Adding score.");
                        session2Points[i] += parsedScores[0];
                    }
                    else if (session2Names[i].Equals(receivedNames[1]))
                    {
                        Console.WriteLine("input name {0} matches name {1} at index {2}", receivedNames[1], session2Names[i], i);
                        Console.WriteLine("Adding score.");
                        session2Points[i] += parsedScores[1];
                    }
                }
            }
        }
    }
}
