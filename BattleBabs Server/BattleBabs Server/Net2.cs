using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace BattleBabs_Server
{
    class Net2
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const int port = 5800; // port will be kept constant

        static IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
        static string message;
        static byte[] receiveBuffer;
        static Thread serverThread;
        static UdpClient listener = new UdpClient(port);
        public static void create()
        {
            serverThread = new Thread(new ThreadStart(receive));
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        public static void receive()
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("Waiting for broadcast.");
                    logger.Info("Net2: Awaiting Data Broadcast");
                    receiveBuffer = listener.Receive(ref endPoint);
                    message = Encoding.ASCII.GetString(receiveBuffer, 0, receiveBuffer.Length - 1);
                    Console.WriteLine("Data received: \"{0}\"", message);
                    logger.Info(String.Format("Data broadcast received. Data: {0} | Parsing...", message));
                    object[] parsedData = parseMessage();
                    for(int i = 0; i < Display.displaySession.teams.Count; i++)
                    {
                        if(Display.displaySession.teams.ElementAt(i).name.Equals(parsedData[0]))
                        {
                            Session.teamData data = new Session.teamData();
                            data = Display.displaySession.teams.ElementAt(i);
                            Display.displaySession.removeTeam(i);
                            data.score += int.Parse(parsedData[1].ToString());
                            Display.displaySession.teams.Add(data);
                        } else if(Display.displaySession.teams.ElementAt(i).Equals(parsedData[2]))
                        {
                            Session.teamData data = new Session.teamData();
                            data = Display.displaySession.teams.ElementAt(i);
                            Display.displaySession.removeTeam(i);
                            data.score += int.Parse(parsedData[3].ToString());
                            Display.displaySession.teams.Add(data);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception! {0} at location {1}", e.Message, e.TargetSite);
                    logger.Fatal("Exception!", e);
                }
                Thread.Sleep(20);
            }
        }

        /// <summary>
        /// Parses and returns team names and scores {Team1, team1Score, Team2, Team2score}
        /// </summary>
        /// <returns></returns>
        private static object[] parseMessage()
        {
            Console.WriteLine("Now parsing message");
           
            string[] splitMessage = message.Split(':');
            object[] returnArray = {"", 0, "", 0 };
            returnArray[3] = int.Parse(splitMessage[1]); // team 2 score
            returnArray[1] = int.Parse(splitMessage[0]); // team 1 score
            returnArray[0] = splitMessage[2]; // team 1 name
            returnArray[2] = splitMessage[3]; // team 2 name
            Console.WriteLine("Success.");
            return returnArray;
        }

        public static void stop()
        {
            serverThread.Abort();
        }
    }
}