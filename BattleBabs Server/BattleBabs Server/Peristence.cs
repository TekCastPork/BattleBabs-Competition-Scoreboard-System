using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            for(int i = 0; i < GameUtility.names.Length; i++)
            {
                savingNames[i] = GameUtility.names[i];
                savingNames[i + 9] = GameUtility.session2Names[i];
                savingPoints[i] = GameUtility.points[i].ToString();
                savingPoints[i + 9] = GameUtility.session2Points[i].ToString();
            }
            File.WriteAllLines("names.persist", savingNames);
            File.WriteAllLines("scores.persist", savingPoints);
            Console.WriteLine("Complete");
        }
    }
}
