using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace BattleBabs_Server
{
    class Peristence
    {
        /// <summary>
        /// OBSOLETE IN THIS BRANCH
        /// </summary>
        [Obsolete("In this branch please use loadTeamData()")]
        public static void load()
        {
            Console.WriteLine("[Pre] Loading scores and names");
            string[] defaultNames = { "Johhny-5", "Iron Giant", "Rodney CopperBottom", "Bender", "WALL-E", "EVE", "MO", "Chappy", "Crimson Typhoon", "Gypsy Danger", "Voyager", "CanadaArm2", "T-800", "T-1000", "SkyNet", "NS-5", "Sonny", "V.I.K.I" };
            string[] defaultScores = { "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0"};
            Logger.writeGeneralLog("Program starting, loading names and scores from their respective persistence files");
            string[] loadedScores = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard","scores.persist"));
            string[] loadedNames = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "names.persist"));
            if(loadedNames.Length == 0)
            {
                Logger.writeCriticalLog("Names persist file was EMPTY, writing default names to it and overwritting laoded names with default names");
                File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "names.persist"), defaultNames);
                for(int i = 0; i < loadedNames.Length; i++)
                {
                    loadedNames[i] = defaultNames[i];
                    Console.WriteLine("Default name {0} loaded", defaultNames[i]);
                }
            }
            if (loadedScores.Length == 0)
            {
                Logger.writeCriticalLog("Scores persist file was EMPTY, writing default scores to it and overwritting laoded names with default scores");
                File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "scores.persist"), defaultScores);
                for (int i = 0; i < loadedScores.Length; i++)
                {
                    loadedScores[i] = defaultScores[i];
                    Console.WriteLine("Default score {0} loaded", defaultScores[i]);
                }
            }
            for (int i = 0; i < GameUtility.names.Length; i++)
            {
                GameUtility.points[i] = int.Parse(loadedScores[i]);
                GameUtility.names[i] = loadedNames[i];
                GameUtility.sortedNames[i] = loadedNames[i];
                GameUtility.sortedScores[i] = int.Parse(loadedScores[i]);
                GameUtility.session2Points[i] = int.Parse(loadedScores[i+9]);
                GameUtility.session2Names[i] = loadedNames[i + 9];
                Logger.writeGeneralLog(String.Format("Loaded following data into arrays: names[{0}]: {1}  |  points[{0}]: {2}  |  session2Names[{3}]: {4}  |  session2Points[{3}]: {5}", i, loadedNames[i], loadedScores[i], i + 9, loadedNames[i + 9], loadedScores[i + 9]));
            }
        }

        /// <summary>
        /// OBSOLETE IN THIS BRANCH
        /// </summary>
        [Obsolete("In this branch please use saveTeamData()")]
        public static void saveAll()
        {
            Console.WriteLine("[Post] Saving names & scores to names.persist");
            Logger.writeGeneralLog("Program is closing, saving names and scores to respective persistence files");
            string[] savingNames = new string[18];
            string[] savingPoints = new string[18];
            for(int i = 0; i < GameUtility.names.Length; i++)
            {
                try
                {
                    savingNames[i] = GameUtility.names[i];
                    savingNames[i + 9] = GameUtility.session2Names[i];
                    savingPoints[i] = GameUtility.points[i].ToString();
                    savingPoints[i + 9] = GameUtility.session2Points[i].ToString();
                } catch (Exception e)
                {
                    Console.WriteLine("Exception! {0} {1}", e.Message, e.TargetSite);
                    Logger.writeExceptionLog(e);
                }
            }
            File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "names.persist"), savingNames);
            File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "scores.persist"), savingPoints);
            Console.WriteLine("Complete");
            Logger.writeGeneralLog("Saving complete.");
        }

        /// <summary>
        /// A new function that will work with the structure for teams - handles loading
        /// </summary>
        public static void loadTeamData()
        {
            Logger.writeGeneralLog("Loading team data from persistence file");
            string[] loadedTeamData = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "TeamData.persist"));
            Logger.writeGeneralLog("Data loaded into holding string array, loading into list entries...");
            GameUtility.teamCount = int.Parse(loadedTeamData[0]);
            for(int i = 1; i < loadedTeamData.Length; i++)
            {
                string[] splitTeamData = loadedTeamData[i].Split(':'); // split a single team's data
                Logger.writeGeneralLog(String.Format("Split team data at index {0}:\n" +
                    "\tName: {1}\n" +
                    "\tScore: {2}\n" +
                    "\tRank: {3}\n" +
                    "\tID: {4}", i,splitTeamData[0],splitTeamData[1],splitTeamData[2],splitTeamData[3]));
                GameUtility.teamData teamEntry = new GameUtility.teamData();
                teamEntry.name = splitTeamData[0];
                teamEntry.score = int.Parse(splitTeamData[1]);
                teamEntry.rank = int.Parse(splitTeamData[2]);
                teamEntry.ID = int.Parse(splitTeamData[3]);
                GameUtility.teamEntries.Add(teamEntry);
                Logger.writeGeneralLog("Team entry added to list");
            }
            Logger.writeGeneralLog("Team data loaded.");
        }

        /// <summary>
        /// A new function that will work with the structure for teams - handles saving
        /// </summary>
        public static void saveTeamData()
        {
            string[] saveData = new string[GameUtility.teamCount];
            Logger.writeGeneralLog("Now saving team data");
            for(int i = 0; i < GameUtility.teamEntries.Count; i++)
            {
                Logger.writeGeneralLog(String.Format("Loading structure located at index {0} of the list...", i));
                GameUtility.teamData teamEntry = new GameUtility.teamData();
                teamEntry = GameUtility.teamEntries.ElementAt(i);
                string[] teamData = new string[4];
                teamData[0] = teamEntry.name;
                teamData[1] = teamEntry.score.ToString();
                teamData[2] = teamEntry.rank.ToString();
                teamData[3] = teamEntry.ID.ToString();
                string teamSaveData = String.Join(":", teamData);
                Logger.writeGeneralLog(String.Format("Data to be saved: {0}", teamSaveData));
                saveData[i] = teamSaveData;
            }
            File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "TeamData.persist"),saveData);
            Logger.writeGeneralLog("Team data saved to persistence file.");
        }
    }
}
