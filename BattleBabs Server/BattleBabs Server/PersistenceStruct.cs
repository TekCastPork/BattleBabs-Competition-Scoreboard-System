using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleBabs_Server
{
    class PersistenceStruct
    {
        public static void loadTeamData()
        {
            Console.WriteLine("Loading team data from persistence...");
            string[] loadedLines = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "TeamData.SAVE"));
            for(int i = 0; i < loadedLines.Length; i++)
            {
                string decodedData = FromHexString(loadedLines[i]);
                string[] splitData = decodedData.Split(':');
                GameData.teamData teamInfo = new GameData.teamData();
                teamInfo.name = splitData[0];
                teamInfo.score = int.Parse(splitData[1]);
                teamInfo.rank = int.Parse(splitData[2]);
                teamInfo.sessionID = int.Parse(splitData[3]);
                GameData.teamEntries.Add(teamInfo);
                Console.WriteLine("Completed pass {0}",i);
            }
            DisplayStruct.updateDisplay = true;
            
        }

        public static void saveTeamData()
        {
            Console.WriteLine("Saving team data to persistence...");
            string[] saveString = new string[GameData.teamEntries.Count];
            for (int i = 0; i < GameData.teamEntries.Count; i++)
            {
                GameData.teamData teamInfo = new GameData.teamData();
                teamInfo = GameData.teamEntries.ElementAt(i);
                string[] partialData = new string[4];
                partialData[0] = teamInfo.name;
                partialData[1] = teamInfo.score.ToString();
                partialData[2] = teamInfo.rank.ToString();
                partialData[3] = teamInfo.sessionID.ToString();
                string combinedData = String.Join(":", partialData);
                string saveData = ToHexString(combinedData);
                saveString[i] = saveData;
            }
            File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "TeamData.SAVE"), saveString);
        }

        private static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.ASCII.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        private static string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.ASCII.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }
    }
}
