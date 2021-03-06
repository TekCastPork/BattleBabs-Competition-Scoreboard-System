﻿using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

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
