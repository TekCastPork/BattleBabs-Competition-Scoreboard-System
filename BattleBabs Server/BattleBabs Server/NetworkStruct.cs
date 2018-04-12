using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BattleBabs_Server
{
    class NetworkStruct
    {
        private const int port = 5800; // port will be kept constant

        static IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
        static string message;
        static byte[] receiveBuffer;
        static Thread serverThread = new Thread(new ThreadStart(receive));
        static UdpClient listener = new UdpClient(port);
        public static void startNetworkComms()
        {
            serverThread.IsBackground = true;
            serverThread.Name = "NetComms";
            serverThread.Start();
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
                    parseMessage();
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

        public static void parseMessage()
        {
            Console.WriteLine("Now parsing message");
            Logger.writeGeneralLog("Parsing message");
            string[] splitMessage = message.Split(':');
            Console.WriteLine("Results of splitting:");
            Logger.writeGeneralLog("Message has been split according to seperating character ':'. Results:");
            for (int i = 0; i < splitMessage.Length; i++)
            {
                Console.WriteLine("[{0}]: {1}", i, splitMessage[i]);
                Logger.writeGeneralLog(String.Format("[{0}]: {1}", i, splitMessage[i]));
            }
            Console.WriteLine("Looking at list...");
            GameData.teamData teamInfo = new GameData.teamData();
            for(int i = 0; i < GameData.teamEntries.Count; i++)
            {
                teamInfo = GameData.teamEntries.ElementAt(i);
                if (teamInfo.name.Equals(splitMessage[2]))
                {
                    Console.WriteLine("Match with name 0");
                    teamInfo.score = int.Parse(splitMessage[0]);
                    GameData.teamEntries.RemoveAt(i);
                    GameData.teamEntries.Insert(i, teamInfo);
                }
                else if (teamInfo.name.Equals(splitMessage[3]))
                {
                    Console.WriteLine("Match with name 1");
                    teamInfo.score = int.Parse(splitMessage[1]);
                    GameData.teamEntries.RemoveAt(i);
                    GameData.teamEntries.Insert(i, teamInfo);
                } else
                {
                    Console.WriteLine("No match");
                }
            }
            SorterStruct.sortStructure();
            DisplayStruct.updateDisplay = true;
        }
    }
}
