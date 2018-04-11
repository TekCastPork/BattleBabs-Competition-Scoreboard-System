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
            public static string name;
            public static int score;
            public static int rank;
            public static int sessionID;
        };
    }
}
