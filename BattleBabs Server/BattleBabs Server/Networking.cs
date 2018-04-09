using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Linq;

namespace BattleBabs_Server
{
    class Networking
    {
        private const int port = 5800; // port will be kept constant
        
        static IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
        static string message;
        static byte[] receiveBuffer;
        static Thread serverThread = new Thread(new ThreadStart(receiveData));
        static UdpClient listener = new UdpClient(port);
        public static void create()
        {
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        public static void receiveData()
        {
            while (true)
            {
                Logger.writeNetLog("Waiting to receive data over network...");
                receiveBuffer = listener.Receive(ref endPoint);
                message = Encoding.ASCII.GetString(receiveBuffer, 0, receiveBuffer.Length - 1);
                Logger.writeNetLog(String.Format("Received Data! Data reads: {0}\n\t" +
                    "Now Parsing...", message));
                parseNetworkData(message);

            }
        }

        private static void parseNetworkData(string message)
        {
            Logger.writeNetLog("Beginning Parse");
            string[] splitMessageData = message.Split(':');
            Logger.writeNetLog("Message split according to seperating character ':'");
            Logger.writeNetLog("Converting scores (index 0 and 1) into integers");
            int team1Score = int.Parse(splitMessageData[0]);
            int team2Score = int.Parse(splitMessageData[1]);
            string team1 = splitMessageData[2];
            string team2 = splitMessageData[3];
            Logger.writeNetLog("Scores converted, searching structure array for matching names");
            GameUtility.teamData teamInfo = new GameUtility.teamData();
            for(int i = 0; i < GameUtility.teamEntries.Count; i++ )
            {
                teamInfo = GameUtility.teamEntries.ElementAt(i);
                if(teamInfo.name.Equals(team1))
                {
                    Logger.writeNetLog(String.Format("Team 1 ({0}) has a match at structure in list at location {1}\n\t" +
                        "Adding score to this structure", team1, i));
                    teamInfo.score += team1Score;
                    Logger.writeNetLog("Score added, replacing structure in list");
                    GameUtility.teamEntries.RemoveAt(i);
                    GameUtility.teamEntries.Insert(i, teamInfo);
                    Logger.writeNetLog("Structure replaced");
                } else if(teamInfo.name.Equals(team2))
                {
                    Logger.writeNetLog(String.Format("Team 2 ({0}) has a match at structure in list at location {1}\n\t" +
                        "Adding score to this structure", team2, i));
                    teamInfo.score += team2Score;
                    Logger.writeNetLog("Score added, replacing structure in list");
                    GameUtility.teamEntries.RemoveAt(i);
                    GameUtility.teamEntries.Insert(i, teamInfo);
                    Logger.writeNetLog("Structure replaced");
                } else
                {
                    Logger.writeNetLog(String.Format("Neither team had a match in the structure list at location {0}", i));
                }
            }
        }
    }
}
