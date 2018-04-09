using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace BattleBabs_Server
{
    class Peristence
    {

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
                    "\tSession ID: {4}", i,splitTeamData[0],splitTeamData[1],splitTeamData[2],splitTeamData[3]));
                GameUtility.teamData teamEntry = new GameUtility.teamData();
                teamEntry.name = splitTeamData[0];
                teamEntry.score = int.Parse(splitTeamData[1]);
                teamEntry.rank = int.Parse(splitTeamData[2]);
                teamEntry.sessionID = int.Parse(splitTeamData[3]);
                GameUtility.teamEntries.Add(teamEntry);
                Logger.writeGeneralLog("Team entry added to list");
                if(i > 8)
                {
                    GameUtility.session2TeamNames[i-9] = splitTeamData[0];
                } else
                {
                    GameUtility.session1TeamNames[i] = splitTeamData[0];
                }
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
                teamData[3] = teamEntry.sessionID.ToString();
                string teamSaveData = String.Join(":", teamData);
                Logger.writeGeneralLog(String.Format("Data to be saved: {0}", teamSaveData));
                saveData[i] = teamSaveData;
            }
            File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "TeamData.persist"),saveData);
            Logger.writeGeneralLog("Team data saved to persistence file.");
        }
    }
}
