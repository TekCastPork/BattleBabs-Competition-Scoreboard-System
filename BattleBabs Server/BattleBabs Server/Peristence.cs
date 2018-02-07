using System;
using System.IO;

namespace BattleBabs_Server
{
    class Peristence
    {
        public static void load()
        {
            Console.WriteLine("[Pre] Loading scores and names");
            string[] loadedScores = File.ReadAllLines("./scores.persist");
            string[] loadedNames = File.ReadAllLines("./names.persist");
            
            for(int i = 0; i < 19; i++)
            {
                GameUtility.points[i] = int.Parse(loadedScores[i]);
                GameUtility.names[i] = loadedNames[i];
                GameUtility.session2Points[i] = int.Parse(loadedScores[i+9]);
                GameUtility.session2Names[i] = loadedNames[i + 9];
            }           
        }

        public static void saveAll()
        {
            Console.WriteLine("[Post] Saving names & scores to names.persist");
            string[] savingNames = new string[18];
            string[] savingPoints = new string[18];
            string[] saveRounds = new string[36];
            string[] saveFlags = new string[36];
            for(int i = 0; i < saveRounds.Length; i++)
            {
                saveRounds[i] = Bracketeers.allCombinations[i];
                if(Bracketeers.isChosen[i] == true)
                {
                    saveFlags[i] = "1";
                } else
                {
                    saveFlags[i] = "0";
                }
            }
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
                }
            }
            File.WriteAllLines("flags.persist", saveFlags);
            File.WriteAllLines("rounds.persist", saveRounds);
            File.WriteAllLines("names.persist", savingNames);
            File.WriteAllLines("scores.persist", savingPoints);
            Console.WriteLine("Complete");
        }
    }
}
