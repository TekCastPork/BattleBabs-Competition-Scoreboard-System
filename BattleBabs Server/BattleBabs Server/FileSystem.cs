using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleBabs_Server
{
    class FileSystem
    {
        static string saveName = "SessionList.save"; // Allows for easy changing of save file name instead of having to go into the function itself
        public static void saveData()
        {
            Console.WriteLine("Saving Dictionary to file");
            Session session = new Session();
            //Lets open a StreamWriter so that we can write individual lines instead of all of them at once (will make for loop easier)
            StreamWriter saver = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData", saveName))
            {
                AutoFlush = true
            };
            string[] keys = GameData.getStoredKeys();
            for(int i = 0; i > keys.Length; i++)
            {
                session = GameData.getSessionByName(keys[i]);
                saver.WriteLine("[]"); //Write a session beginner
                saver.WriteLine(keys[i]); // Write the session's name (its key)
                saver.WriteLine(session.teamCount); // Write the session's team count, used for hiding/showing Labels on GUI
                for(int j = 0; j < session.teamCount; j++) // time to write individual teams and scores
                {
                    Session.teamData teamData = session.teams.ElementAt(j); // get a team structure from the session's internal list
                    string teamString = String.Join(teamData.name, ":", teamData.score);
                    saver.WriteLine(teamString);
                }
                saver.WriteLine("{}"); // Write a terminator to make finding the end of each session easier                
            }
            Console.WriteLine("Done writing all sessions and team data. Flushing and Closing");
            saver.Flush();
            saver.Close();
            Console.WriteLine("Disposing StreamWriter Object");
            saver.Dispose();
        }

        public static void loadData()
        {
            Console.WriteLine("Loading data from file into dictionary");
            Session session = new Session();
            string[] dataLines = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData", saveName));
            Console.WriteLine("Finding locations of session beginning lines...");
            for(int i = 0; i < dataLines.Length; i++)
            {
                if(dataLines[i].Equals("[]"))
                {
                    //a starter is found
                }
            }
        }
    }
}