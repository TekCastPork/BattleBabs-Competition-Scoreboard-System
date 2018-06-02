using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace BattleBabs_Server
{
    class NetClient
    {
        public static int port = 5801;
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static Socket commSocket;
        static IPAddress address;
        static IPEndPoint endPoint;
        static byte[] sendBuffer;
        public static string IP = "127.0.0.1";
        public static void create()
        {
            address = IPAddress.Parse(IP);
            endPoint = new IPEndPoint(IPAddress.Broadcast, port);
            commSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public static void update()
        {
            address = IPAddress.Parse(IP);
            endPoint.Address = address;
        }

        public static void sendData(string data)
        {
            logger.Info("Preparing to send data.");
            string message = data + "\n";
            sendBuffer = Encoding.ASCII.GetBytes(message);
            logger.Info("message encoded into bytes, transmitting");
            try
            {
                commSocket.SendTo(sendBuffer, endPoint);
            } catch (Exception e)
            {
                logger.Fatal("Exception!", e);
            }
        }
    }
}
