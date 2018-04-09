using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBabs_Server
{
    /// <summary>
    /// A WIP class to try placing ranks again
    /// </summary>
    class Sorter
    {
        /// <summary>
        /// Sorts a teamData list based on the score
        /// </summary>
        /// <remarks>CAN ONLY SORT LISTS OF TYPE 'GameUtility.teamData'</remarks>
        /// <param name="teamData"></param>
        /// <returns></returns>
        public static List<GameUtility.teamData> sortTeamData(List<GameUtility.teamData> teamData)
        {
            Logger.writeGeneralLog("Now sorting team data based on score");
            List<GameUtility.teamData> sortedData = new List<GameUtility.teamData>();
            sortedData = GameUtility.teamEntries.OrderBy(x => x.score).ToList<GameUtility.teamData>();
            Logger.writeGeneralLog("Data sorted, returning");
            return sortedData;
        }
    }
}
