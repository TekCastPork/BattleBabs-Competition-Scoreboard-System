using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace BattleBabs_Server
{
    class Networking
    {
        private const int port = 5800;
        static UdpClient listener;
       // static IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
        static IPEndPoint endPoint;
        static string message;
        static byte[] receiveBuffer;
        static Thread serverThread = new Thread(new ThreadStart(receive));
        public static void create()
        {
            endPoint = new IPEndPoint(IPAddress.Parse("192.168.2.255"), port);
            listener = new UdpClient(port);
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
                    receiveBuffer = listener.Receive(ref endPoint);
                    message = Encoding.ASCII.GetString(receiveBuffer, 0, receiveBuffer.Length);
                    Console.WriteLine("Received data: {0}", message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception! {0}", e.Message);
                }
                Thread.Sleep(20);
            }
        }
    }
}
