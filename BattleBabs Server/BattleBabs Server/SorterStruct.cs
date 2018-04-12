using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBabs_Server
{
    class SorterStruct
    {
        public static void sortStructure()
        {
            Console.WriteLine("Sorting by score");
            GameData.teamEntries = GameData.teamEntries.OrderBy(x => x.score).ToList<GameData.teamData>();
            Console.WriteLine("Complete");
            DisplayStruct.updateDisplay = true;
        }
    }
}
