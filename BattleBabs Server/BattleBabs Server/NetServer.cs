using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace BattleBabs_Server
{
    class NetServer
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const int port = 5800;
        static IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
        static string message;
        static byte[] receiveBuffer;
        static Thread serverThread = new Thread(new ThreadStart(receiveData));
        static UdpClient listener = new UdpClient(port);
        public static void create()
        {
            serverThread.IsBackground = true;
            serverThread.Start();
        }
        public static void receiveData()
        {
            while(true)
            {
                try
                {
                    logger.Info("Waiting for a data stream from networked scoreboard");
                    receiveBuffer = listener.Receive(ref endPoint);
                    message = Encoding.ASCII.GetString(receiveBuffer, 0, receiveBuffer.Length - 1);
                    logger.Info(String.Format("Received string\"{0}\"", message));
                    //String style: Team1Score:Team2Score:Team1:Team2
                    string[] splitData = message.Split(':');
                    logger.Info("Data has been split, finding teams in session and adding");
                    Session.teamData data = new Session.teamData();
                    for(int i = 0; i < Display.displaySession.teams.Count; i++)
                    {

                        if(splitData[2].Equals(Display.displaySession.teams.ElementAt(i).name))
                        {
                            logger.Info("Team 1 has found a match");
                            data = Display.displaySession.teams.ElementAt(i);
                            data.score = int.Parse(splitData[0]);
                            Display.displaySession.removeTeam(i);
                            Display.displaySession.teams.Add(data); // will need sorting right away

                        } else if(splitData[3].Equals(Display.displaySession.teams.ElementAt(i).name))
                        {
                            logger.Info("Team 2 has found a match");
                            data = Display.displaySession.teams.ElementAt(i);
                            data.score = int.Parse(splitData[1]);
                            Display.displaySession.removeTeam(i);
                            Display.displaySession.teams.Add(data); // will need sorting right away
                        }
                    }
                } catch (Exception e)
                {
                    logger.Fatal("Exception Caught!", e);
                }
            }
        }
    }
}
