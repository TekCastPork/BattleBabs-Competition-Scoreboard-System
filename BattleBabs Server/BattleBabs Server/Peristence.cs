using System;
using System.IO;

namespace BattleBabs_Server
{
    class Peristence
    {
        public static void load()
        {
            Console.WriteLine("[Pre] Loading scores and names");
            Logger.writeGeneralLog("Program starting, loading names and scores from their respective persistence files");
            string[] loadedScores = File.ReadAllLines("./scores.persist");
            string[] loadedNames = File.ReadAllLines("./names.persist");
            
            for(int i = 0; i < GameUtility.names.Length; i++)
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
            File.WriteAllLines("names.persist", savingNames);
            File.WriteAllLines("scores.persist", savingPoints);
            Console.WriteLine("Complete");
            Logger.writeGeneralLog("Saving complete.");
        }
    }
}
