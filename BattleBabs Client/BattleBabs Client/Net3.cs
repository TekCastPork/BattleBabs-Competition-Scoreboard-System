using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BattleBabs_Client
{
    class Net3
    {
        //private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static UdpClient udp = new UdpClient();
        static int groupPort = 25566; // used for all comms
        static IPEndPoint groupEP = new IPEndPoint(IPAddress.Broadcast, groupPort);
        static IPEndPoint receiveEP = new IPEndPoint(IPAddress.Any, groupPort);
        public static Thread listener;

        /*
         * Packet types:
         * Score->Leader
         * Identifier: Byte[0] = ,
         * Leader->Score
         * Identifier: Byte[0] = .
         */

        public static void start()
        {
            udp.EnableBroadcast = true;
            listener = new Thread(new ThreadStart(receiveMessage))
            {
                Name = "NetReceive",
                IsBackground = true
            };
            listener.Start();
        }

        public static void stop()
        {
            udp.Client.Disconnect(true);
            listener.Abort();
        }

        private static void receiveMessage()
        {
            udp.Client.Bind(receiveEP);
            while (true)
            {
                Console.WriteLine("Waiting...");

                byte[] receivedData = udp.Receive(ref receiveEP);
                if (receivedData[0].Equals('.')) // if the message is intended for a scoreboard
                {
                    for (int i = 1; i < receivedData.Length; i++) // shift everything left to take out that identifier
                    {
                        receivedData[i - 1] = receivedData[i];
                    }
                }
                string message = Encoding.ASCII.GetString(receivedData);
                Console.WriteLine("RECEIVED: {0}", message);
                object[] parsedData = parseMessage(message);
                //put stuff to do the things here
            }
        }

        /// <summary>
        /// Broadcasts a message to the LAN in hopes it gets received at the leaderboard. Sends using identifier byte ","
        /// </summary>
        /// <param name="message"></param>
        public static void send(string message)
        {
            byte[] byteData = Encoding.ASCII.GetBytes("," + message + "\n");
            Console.WriteLine("SENT: {0} as bytes.", message);
            udp.Send(byteData, byteData.Length, groupEP);
        }

        /// <summary>
        /// Parses the message into individual items based on the seperator: ":"
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string[] parseMessage(string message)
        {
            //All we need to do on the scoreboard side of parsing is just split the team names up from the main string, no scores to parse :)
            Console.WriteLine("Now parsing message");
            string[] splitMessage = message.Split(':');
            Console.WriteLine("Success.");
            return splitMessage;
        }
    }
}
