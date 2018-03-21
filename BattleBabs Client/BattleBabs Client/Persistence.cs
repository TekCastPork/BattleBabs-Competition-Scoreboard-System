using System;
using System.IO;

namespace BattleBabs_Client
{
    class Persistence
    {
        public static void saveScoringData()
        {
            Logger.writeGeneralLog("Saving scoring data so it can be loaded from a persistence file");
            File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Scoreboard", "ScoringMethods.persist"), RefForm.ScoreNames);
            Logger.writeGeneralLog("Logging scoring point values...");
            string[] scoreStringValues = new string[RefForm.ScoreValues.Length];
            for(int i = 0; i < RefForm.ScoreValues.Length; i++)
            {
                scoreStringValues[i] = RefForm.ScoreValues[i].ToString();
            }
            File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Scoreboard", "ScoringValues.persist"), scoreStringValues);
            Logger.writeGeneralLog("Saving complete.");
        }

        public static void loadScoringData()
        {
            Logger.writeGeneralLog("Loading scoring data for the referee form...");
            RefForm.ScoreNames = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Scoreboard", "ScoringMethods.persist"));
            string[] inputScoreValues = new string[RefForm.ScoreValues.Length];
            inputScoreValues = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Scoreboard", "ScoringMethods.persist"));
            for(int i = 0; i < inputScoreValues.Length; i++)
            {
                RefForm.ScoreValues[i] = int.Parse(inputScoreValues[i]);
            }
            Logger.writeGeneralLog("Loading complete.");
        }
    }
}
