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
    class Net3
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static UdpClient udp = new UdpClient();
        static int groupPort = 25566; // used for all comms
        static IPEndPoint groupEP = new IPEndPoint(IPAddress.Broadcast, groupPort);
        static IPEndPoint receiveEP = new IPEndPoint(IPAddress.Any, groupPort);
        public static Thread listener;

        /*
         * Packet types:
         * Score->Leader
         * Identifier: Byte[0] = ,
         * Teams->Score
         * Identifier: Byte[0] = .
         */

        private static Boolean started = false;
        public static void start()
        {
            if (!started)
            {
                udp.EnableBroadcast = true;
                listener = new Thread(new ThreadStart(receiveMessage));
                listener.Start();
                started = true;
            } else
            {
                logger.Warn("The thread is already running! Not making another!");
            }
        }

        public static void stop()
        {
            udp.Client.Disconnect(true);
            listener.Abort();
            started = false;
        }

        private static void receiveMessage()
        {
            udp.Client.Bind(receiveEP);
            while (true)
            {
                Console.WriteLine("Waiting...");
                
                byte[] receivedData = udp.Receive(ref receiveEP);
                if(receivedData[0].Equals('.'))
                {
                    for(int i = 1; i < receivedData.Length; i++)
                    {
                        receivedData[i - 1] = receivedData[i];
                    }
                }
                string message = Encoding.ASCII.GetString(receivedData);
                Console.WriteLine("RECEIVED: {0}", message);
                object[] parsedData = parseMessage(message);
                for (int i = 0; i < Display.displaySession.teams.Count; i++)
                {
                    if (Display.displaySession.teams.ElementAt(i).name.Equals(parsedData[0]))
                    {
                        Session.teamData data = new Session.teamData();
                        data = Display.displaySession.teams.ElementAt(i);
                        Display.displaySession.removeTeam(i);
                        data.score += int.Parse(parsedData[1].ToString());
                        Display.displaySession.teams.Add(data);
                    }
                    else if (Display.displaySession.teams.ElementAt(i).Equals(parsedData[2]))
                    {
                        Session.teamData data = new Session.teamData();
                        data = Display.displaySession.teams.ElementAt(i);
                        Display.displaySession.removeTeam(i);
                        data.score += int.Parse(parsedData[3].ToString());
                        Display.displaySession.teams.Add(data);
                    }
                }
            }
        }

        public static void send(string message)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(message + "\n");
            Console.WriteLine("SENT: {0} as bytes.", message);
            udp.Send(byteData, byteData.Length, groupEP);
        }

        private static object[] parseMessage(string message)
        {
            Console.WriteLine("Now parsing message");

            string[] splitMessage = message.Split(':');
            object[] returnArray = { "", 0, "", 0 };
            returnArray[3] = int.Parse(splitMessage[1]); // team 2 score
            returnArray[1] = int.Parse(splitMessage[0]); // team 1 score
            returnArray[0] = splitMessage[2]; // team 1 name
            returnArray[2] = splitMessage[3]; // team 2 name
            Console.WriteLine("Success.");
            return returnArray;
        }
    }
}
