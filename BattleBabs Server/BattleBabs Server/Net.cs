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
    class Net
    {
        static UdpClient udp = new UdpClient();
        static int groupPort = 25566; // used for all comms
        static IPEndPoint groupEP = new IPEndPoint(IPAddress.Broadcast, groupPort);
        static IPEndPoint receiveEP = new IPEndPoint(IPAddress.Any, groupPort);
        static Thread listener = new Thread(new ThreadStart(receiveMessage));

        /*
         * Packet types:
         * Score->Leader
         * Identifier: Byte[0] = :
         * Teams->Score
         * Identifier: Byte[0] = ;
         */

        public static void start()
        {
            udp.EnableBroadcast = true;
            listener.Start();
        }

        private static void receiveMessage()
        {
            udp.Client.Bind(receiveEP);
            while (true)
            {
                Console.WriteLine("Waiting...");
                
                byte[] receivedData = udp.Receive(ref receiveEP);
                string data = Encoding.ASCII.GetString(receivedData);
                Console.WriteLine("RECEIVED: {0}", data);
            }
        }

        public static void send(string message)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(message + "\n");
            Console.WriteLine("SENT: {0} as bytes.", message);
            udp.Send(byteData, byteData.Length, groupEP);
        }
    }
}
