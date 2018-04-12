using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBabs_Server
{
    class SorterStruct
    {
        public static List<GameData.teamData> sortStructure(List<GameData.teamData> list)
        {
            GameData.teamData teamInfo = new GameData.teamData();
            Console.WriteLine("sorting by score");
            List<GameData.teamData> returnStruct = new List<GameData.teamData>();
            returnStruct = GameData.teamEntries;
            returnStruct.OrderBy(x => x.score).ToList<GameData.teamData>();
            for (int i = 0; i < returnStruct.Count; i++)
            {
                teamInfo = returnStruct.ElementAt(i);
                if (teamInfo.sessionID == 1)
                {
                    teamInfo.rank = Math.Abs((9 - i))+1;
                }
                else
                {
                    teamInfo.rank = Math.Abs((i)+1);
                }
                returnStruct.RemoveAt(i);
                returnStruct.Insert(i, teamInfo);
            }
            DisplayStruct.updateDisplay = true;
            return returnStruct;
        }
    }
}
