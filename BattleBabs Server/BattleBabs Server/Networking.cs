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
        static Thread serverThread = new Thread(new ThreadStart(receive));
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

        public static void receive()
        {
            while (true)
            {
                try
                {
                    
                    Console.WriteLine("Waiting for broadcast.");
                    Logger.writeGeneralLog("||NETWORK|| Waiting to receive data...");
                    receiveBuffer = listener.Receive(ref endPoint);
                    message = Encoding.ASCII.GetString(receiveBuffer, 0, receiveBuffer.Length - 1);
                    Console.WriteLine("Data received: \"{0}\"", message);
                    Logger.writeGeneralLog(String.Format("Data was received. Data: {0}", message));
                    Logger.writeGeneralLog("Now parsing into teams and scores.");
                    GameUtility.parsedScores = parseMessage();
                    GameUtility.addScores();
                    Logger.writeGeneralLog("Parsing complete.");
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception! {0} at location {1}", e.Message, e.TargetSite);
                    Logger.writeExceptionLog(e);
                }
                Thread.Sleep(20);
            }
        }

        public static int[] parseMessage()
        {
            Console.WriteLine("Now parsing message");
            Logger.writeGeneralLog("Parsing message");
            string[] splitMessage = message.Split(':');
            Console.WriteLine("Results of splitting:");
            Logger.writeGeneralLog("Message has been split according to seperating character ':'. Results:");
            for(int i = 0; i < splitMessage.Length; i++)
            {
                Console.WriteLine("[{0}]: {1}", i, splitMessage[i]);
                Logger.writeGeneralLog(String.Format("[{0}]: {1}", i, splitMessage[i]));
            }
            Console.WriteLine("Parsing into integers.");
            Logger.writeGeneralLog("Parsing indexes 0 and 1 into integers.");
            int[] returnArray = { 0, 0 };
            returnArray[1] = int.Parse(splitMessage[1]); // team 2 score
            returnArray[0] = int.Parse(splitMessage[0]); // team 1 score
            Logger.writeGeneralLog("Success, storing team names into GameUtility");
            GameUtility.receivedNames[0] = splitMessage[2]; // team 1 name
            GameUtility.receivedNames[1] = splitMessage[3]; // team 2 name
            Logger.writeGeneralLog("Success");
            Console.WriteLine("Success.");
            Logger.writeGeneralLog("updating played flags");
            Bracketeers.updateBoolean(GameUtility.receivedNames[0], GameUtility.receivedNames[1], true);
            Logger.writeGeneralLog("Complete.");
            return returnArray;
        }
    }
}
