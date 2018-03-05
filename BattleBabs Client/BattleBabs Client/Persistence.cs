using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleBabs_Client
{
    class Persistence
    {
        public static void saveScoringData()
        {
            Logger.writeGeneralLog("Saving scoring data so it can be loaded from a persistence file");
            File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Scoreboard", "ScoringMethods.persist"), RefForm.team1ScoreNames);
        }
    }
}
