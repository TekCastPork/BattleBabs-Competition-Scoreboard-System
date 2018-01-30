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
        static StringBuilder sb = new StringBuilder();
        public static void create()
        {
            //Lets use a UDP socket for communication
            commSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //We need a IP to communicate on
            address = IPAddress.Parse("192.168.2.255");
            endPoint = new IPEndPoint(address, 5800);
            Console.WriteLine("UDP Settings and socket created.");
        }

        public static void sendData(string data)
        {
            //exchange string for byte[]
            string message = sb.AppendLine(data).ToString();
            byte[] sendBuffer = Encoding.ASCII.GetBytes(message);
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
                Console.WriteLine("Data {0} send", data);
            } catch (Exception e)
            {
                Console.WriteLine("Exception! {0}", e.Message);
            }
        }
    }
}
