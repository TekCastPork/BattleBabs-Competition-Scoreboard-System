using System;
using System.IO;

namespace BattleBabs_Server
{
    class Peristence
    {
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
                GameUtility.session2Points[i] = int.Parse(loadedScores[i+9]);
                GameUtility.session2Names[i] = loadedNames[i + 9];
                Logger.writeGeneralLog(String.Format("Loaded following data into arrays: names[{0}]: {1}  |  points[{0}]: {2}  |  session2Names[{3}]: {4}  |  session2Points[{3}]: {5}", i, loadedNames[i], loadedScores[i], i + 9, loadedNames[i + 9], loadedScores[i + 9]));
            }
            Logger.writeGeneralLog("Names and scores loaded");
        }

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
    }
}
