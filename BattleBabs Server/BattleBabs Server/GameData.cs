using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBabs_Server
{
    /// <summary>
    /// Newer version of GameUtility to use structures, dont let the names confuse you
    /// </summary>
    class GameData
    {
        public static List<teamData> teamEntries = new List<teamData>();
        public struct teamData
        {
            public string name;
            public int score;
            public int rank;
            public int sessionID;
        };
        /// <summary>
        /// Adds a new entry to the team entries list, uses default score and rank data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public static int addTeamEntry(string name, int sessionID)
        {
            teamData newData;
            try
            {
                newData.name = name;
                newData.score = 0;
                newData.rank = 1;
                newData.sessionID = sessionID;
                teamEntries.Add(newData);
                return 1;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Adds a new team entry to the team entries list, allows custom values for all data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="rank"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public static int addTeamEntry(string name, int score, int rank, int sessionID)
        {
            teamData newData;
            try
            {
                newData.name = name;
                newData.score = score;
                newData.rank = rank;
                newData.sessionID = sessionID;
                teamEntries.Add(newData);
                return 1;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
