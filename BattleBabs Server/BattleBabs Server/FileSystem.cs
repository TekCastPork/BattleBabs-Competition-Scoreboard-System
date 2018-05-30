using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BattleBabs_Server
{
    class FileSystem
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static string saveName = "SessionList.save"; // Allows for easy changing of save file name instead of having to go into the function itself
        public static void saveData()
        {
            Console.WriteLine("Saving Dictionary to file");
            Session session = new Session();
            StreamWriter saver = null;
            Boolean go = false;
            //Lets open a StreamWriter so that we can write individual lines instead of all of them at once (will make for loop easier)
            if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard")))
            {
                if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData")))
                {
                    if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData", saveName)))
                    {
                        saver = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData", saveName))
                        {
                            AutoFlush = true
                        };
                        go = true;
                        logger.Info("Entire filepath for saving exists.");
                    }
                    else
                    {
                        Console.WriteLine("The File didnt exist!!!!!!!!");
                        logger.Warn("Save file didn't exist! Will re-create before streaming data.");
                        File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData", saveName));
                        saveData();
                    }
                }
                else
                {
                    Console.WriteLine("The Directory for save data within the folder in appdata didnt exist!!!!!!!!");
                    logger.Warn("SaveData directory didn't exist! Will re-create before creating file for streaming.");
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData"));
                    saveData();
                }
            } else
            {
                Console.WriteLine("The directory for data within appdata didn't exist!!!!!!!");
                logger.Warn("BattleBot Leaderboard folder didn't exist inside of this system's Application Data folder! Will re-create before checking rest of filepath.");
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard"));
                saveData();
            }

            if (go)
            {
                logger.Info("Filepath was verified, beginning to save data stream.");
                string[] keys = GameData.getStoredKeys();
                logger.Info("Keys gathered:");
                for(int i = 0; i < keys.Length; i++)
                {
                    logger.Info("\t" + keys[i]);
                }
                for (int i = 0; i < keys.Length; i++)
                {
                    logger.Info("Beginning stream of a session.");
                    logger.Info("Session being saved: " + keys[i]);
                    session = GameData.getSessionByName(keys[i]);
                    saver.WriteLine("[]"); //Write a session beginner
                    saver.WriteLine(keys[i]); // Write the session's name (its key)
                    saver.WriteLine(session.teamCount); // Write the session's team count, used for hiding/showing Labels on GUI
                    logger.Info("Starter line, session name, and team count streamed to file. Beginning team stream...");
                    for (int j = 0; j < session.teamCount; j++) // time to write individual teams and scores
                    {
                        Session.teamData teamData = session.teams.ElementAt(j); // get a team structure from the session's internal list
                        logger.Info("Streaming team \"" + teamData.name + "\" with score: " + teamData.score);
                        string teamString = String.Join(teamData.name, ":", teamData.score);
                        saver.WriteLine(teamString);
                    }
                    saver.WriteLine("{}"); // Write a terminator to make finding the end of each session easier      
                    logger.Info("Line saved.");
                }
                Console.WriteLine("Done writing all sessions and team data. Flushing and Closing");
                saver.Flush();
                saver.Close();
                Console.WriteLine("Disposing StreamWriter Object");
                logger.Info("Data streamed to file and flushed. Disposing Streamwriter object.");
                saver.Dispose();
            }
        }

        public static void loadData()
        {
            Boolean go = false;
            if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard"))) {
                if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData"))) {
                    if(File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData", saveName)))
                    {
                        go = true;
                        logger.Info("Entire filepath existed.");
                    } else
                    {
                        Console.WriteLine("The save file didn't exist!!!!");
                        logger.Warn("The save file did not exist in the directory. Loading will be skipped.");
                        MessageBox.Show("ERROR: Session file does not exist or could not be found. Please check the location of the file and that it is named correctly. (Should be called SessionList.save and located at <Application Data>\\BattleBot Leaderboard\\SaveData)","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                } else
                {
                    Console.WriteLine("The savedata directory didn't exist!");
                    logger.Warn("SaveData directory didn't exist. Loading will be skipped.");
                    MessageBox.Show("ERROR: Session file does not exist or could not be found. Please check the location of the file and that it is named correctly. (Should be called SessionList.save and located at <Application Data>\\BattleBot Leaderboard\\SaveData)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else
            {
                Console.WriteLine("The leaderboard directory didn't exist!");
                logger.Warn("BattleBot Leaderboard directory didn't exist. Loading will be skipped.");
                MessageBox.Show("ERROR: Session file does not exist or could not be found. Please check the location of the file and that it is named correctly. (Should be called SessionList.save and located at <Application Data>\\BattleBot Leaderboard\\SaveData)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (go)
            {
                logger.Info("Filepath was verified. Loading saved data...");
                Console.WriteLine("Loading data from file into dictionary");
                Session session = new Session();
                string[] dataLines = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBot Leaderboard", "SaveData", saveName));
                logger.Info("Save file loaded into array, beginning parse...");
                logger.Info("Finding all locations of session beginner/terminator lines...");
                Console.WriteLine("Finding locations of session beginning lines...");
                List<int> starterLocations = new List<int>(); // List to hold positions of starter lines
                List<int> enderLocations = new List<int>(); // list to hold positions of ender lines
                for (int i = 0; i < dataLines.Length; i++)
                {
                    if (dataLines[i].Equals("[]"))
                    {
                        logger.Info("A session beginner line was found, marking location..." + i);
                        Console.WriteLine("A starter line has been found, marking location in list.");
                        starterLocations.Add(i);
                        Console.WriteLine("Marked location {0}", i);
                    }
                    else if (dataLines[i].Equals("{}"))
                    {
                        logger.Info("A session terminator line was found, marking location..." + i);
                        Console.WriteLine("A ender line has been found, marking location in list.");
                        enderLocations.Add(i);
                        Console.WriteLine("Marked location {0}", i);
                    }
                }

                Session loadedSession = new Session(); // varaible to use to place data into the Dictionary
                string key = String.Empty; // variable to hold the session's key name
                string teamString = String.Empty; // variable to hold a line of team data (Name:Score)
                string[] teamData = new string[2]; // array to hold a parsed line of team data {Name,Score}
                logger.Info("variables for loaded data created");
                for (int i = 0; i < starterLocations.Count; i++)
                {
                    loadedSession.teamCount = 0; // clear the team count
                    loadedSession.clearList(); // clear the Session list before loading a new session
                    Console.WriteLine("Session Data Cleared");
                    key = dataLines[starterLocations.ElementAt(i) + 1]; // place the session name into the variable
                    loadedSession.teamCount = int.Parse(dataLines[starterLocations.ElementAt(i) + 2]); // place the team count in the loaded session
                    Console.WriteLine("Session teamcount and key found");
                    //Seems to be throwing an exception somewhere here \/
                    for (int j = (starterLocations.ElementAt(i)) + 3; j < enderLocations.ElementAt(i); j++) // start at the line after the starter and end before the ender
                    {
                        Console.WriteLine("Getting line at index {0}", j);
                        teamString = dataLines[j]; // get a line of team data
                        Console.WriteLine("Input line: {0}", teamString);
                        teamData = teamString.Split(':'); // split the line of team data into their individual name and score
                        Console.WriteLine("data split");
                        loadedSession.insertNewTeam(teamData[0], int.Parse(teamData[1])); // add the team
                        Console.WriteLine("team inserted into session");

                    }
                    GameData.saveSessionByName(loadedSession, key);
                }
                Console.WriteLine("Done loading.");
            }
        }
    }
}