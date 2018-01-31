using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace BattleBabs_Client
{
    class Networking
    {
        static Socket commSocket;
        static IPAddress address;
        static IPEndPoint endPoint;
        public static string IP = "1.1.1.1";
        static StringBuilder sb = new StringBuilder();
        public static void create()
        {
            //We need a IP to communicate on
            address = IPAddress.Parse(IP);
            endPoint = new IPEndPoint(address, 5800);
            Console.WriteLine("UDP Settings and socket created.");
        }

        public static void update()
        {
            address = IPAddress.Parse(IP);
            endPoint.Address = address;
        }

        public static void sendData(string data)
        {
            commSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //exchange string for byte[]
            //   string message = sb.AppendLine(data).ToString();
            string message = data + "\n";
            byte[] sendBuffer = new byte[20];
            sendBuffer = Encoding.ASCII.GetBytes(message);
            Console.Write("Sending data: \"");
            for(int i =0;i<sendBuffer.Length; i++)
            {
                Console.Write("{0} ", sendBuffer[i]);
            }
            Console.WriteLine("\" to \"{0}\" on port {1}.", endPoint.Address, endPoint.Port);
            try
            {
                //attempt to send data
                commSocket.SendTo(sendBuffer, endPoint);
                commSocket.Close();
                Console.WriteLine("Data {0} send", data);
            } catch (Exception e)
            {
                Console.WriteLine("Exception! {0}", e.Message);
            }
        }
    }
}
