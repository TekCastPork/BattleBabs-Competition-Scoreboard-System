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
        }

        public static void loadScoringData()
        {
            Logger.writeGeneralLog("Loading scoring data for the referee form...");
     //       File.ReadAllLines
        }
    }
}
