using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBabs_Server
{
    class GameData
    {
        public struct teamData
        {
            public string name;
            public int score;
            public int sessionID;
        };

        public static List<teamData> masterList = new List<teamData>();
        public static List<teamData> teamList = new List<teamData>();

        public static void setListCapacities(int master)
        {
            masterList.Capacity = master;
            teamList.Capacity = 16;
        }
    }

    class Session
    {
        public struct teamData
        {
            public string name;
            public int score;
        };

        teamData pushedTeam = new teamData();
        public List<teamData> teams { get; set; }
        public Session() { }
        /// <summary>
        /// Inserts a new team into the Session's internal teams List
        /// </summary>
        /// <param name="name"></param>
        /// <param name="initialScore"></param>
        public void insertNewTeam(string name, int initialScore)
        {
            teamData data = new teamData()
            {
                name = name,
                score = initialScore
            };
            teams.Add(data);
            Console.WriteLine("Team {0} with initial score {1} added to Session list",name, initialScore);
        }
        /// <summary>
        /// Fetches and returns a stored teamData structure at the specified index in the internal List
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public teamData getStoredTeam(int index)
        {
            Console.WriteLine("Fetching teamData element located at index {0}", index);
            return teams.ElementAt(index);
        }

        public void removeTeam(int index)
        {
            Console.WriteLine("Removing team from internal List at index {0} \n" +
                              "Team being removed is being stored into pushedTeam teamData structure incase it is needed again.", index);
            pushedTeam = teams.ElementAt(index);
            teams.RemoveAt(index);
        }
    }
}
