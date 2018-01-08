using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Threading;

namespace Display
{
    class PipeClient
    {
        public static NamedPipeClientStream client;
        public static Boolean connectionState = false;

        /// <summary>
        /// This function handles connecting to a server pipe for the Leaderboard system
        /// </summary>
        /// <param name="ioDirection"></param>
        /// <returns name="Boolean"></returns>
        public static Boolean connectToPipe(PipeDirection ioDirection)
        {
            Boolean returnState = false;
            client = new NamedPipeClientStream(".", "boardPipe", ioDirection);
            Console.WriteLine("Attempting to connect to server's pipe. Will timeout in 30 seconds if no connection is made");
            try
            {
                client.Connect(10);
            } catch (Exception e)
            {
                Console.WriteLine("Error during pipe connect!");
                Console.WriteLine(e.ToString());
            }
            if(client.IsConnected)
            {
                returnState = true;
                Console.WriteLine("Connected to pipe.");
                Console.WriteLine("There are currently {0} pipe server instances open.", client.NumberOfServerInstances);
            } else
            {
                Console.WriteLine("Connection to the server pipe was not successful.");
                returnState = false;
            }
            connectionState = returnState; // set the connection state within this class so use in other functions
            return returnState;
        }

        /// <summary>
        /// This function will handle sending messages to the server via the connected pipe
        /// </summary>
        /// <param name="msg"></param>
        public static void sendToServer(byte msg)
            /*
             * The way the byte for sending is set up will be in this fashion:
             * MSB                         LSB
             *  |   |   |   |   |   |   |   |
             *  0   0   0   0   0   0   0   0
             *  Team# | PType |     Flags     |
             *  Example:
             *  
             *  01010000 - give team 1 the points associated with score type 1 and there are no flags
             */
        {
            if(connectionState)
            {
                Console.WriteLine("Connection to the server is enabled, continuing with the sending of the message to server.");
                client.WriteByte(msg); //send the data byte to the server via the connected pipe
            }

        }
    }
}
