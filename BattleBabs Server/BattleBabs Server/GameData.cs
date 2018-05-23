using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBabs_Server
{
    class GameData
    {
        static Dictionary<string, Session> sessionDict = new Dictionary<string, Session>(); // Dictionary that will store all sessions by session name

        /// <summary>
        /// Gets a session from the dictionary based on a given key (session name) Returns null if an error occurs
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Session getSessionByName(string key)
        {
            try
            {
                Session returnSession = sessionDict[key];
                return returnSession;
            } catch( Exception e)
            {
                Console.WriteLine("Error with key {0}!  |  {1}. {2}", key, e.ToString(), e.Message);
                return null;
            }
        }

        /// <summary>
        /// Tests to see if a given key is valid, returns true if key is valid (has a session linked to it), false if otherwise
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Boolean tryGetSession(string key)
        {
            try
            {
                if(sessionDict.ContainsKey(key))
                {
                    return true;
                } else
                {
                    return false;
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error! {0} | {1}", e.ToString(), e.Message);
                return false;
            }
        }

        /// <summary>
        /// Saves a session to the dictionary using the specified key
        /// WARNING: WILL OVERWRITE IF KEY ALREADY EXISTS
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        public static void saveSessionByName(Session session, string key)
        {
            try
            {
                if (sessionDict.ContainsKey(key))
                {
                    Console.WriteLine("session dictrionary has a value stored at this key, overwriting");
                    sessionDict[key] = session;
                }
                else
                {
                    Console.WriteLine("Session Dictionary has no value with given key, creating");
                    sessionDict.Add(key, session);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Some shit happened saving the session! {0} | {1}", e.ToString(), e.Message);
            }
        }

        public static void removeSessionByName(string key)
        {
            sessionDict.Remove(key);
        }

        public static string[] getStoredKeys()
        {
            return sessionDict.Keys.ToArray();
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
        public int teamCount { get; set; }
        public string name;
        public Session() {
        }


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
        /// Removes a team from the internal list
        /// </summary>
        /// <param name="index"></param>
        public void removeTeam(int index)
        {
            Console.WriteLine("Removing team from internal List at index {0} \n" +
                              "Team being removed is being stored into pushedTeam teamData structure incase it is needed again.", index);
            pushedTeam = teams.ElementAt(index);
            teams.RemoveAt(index);
        }

        public void clearList()
        {
            teams.Clear();
        }
    }
}
