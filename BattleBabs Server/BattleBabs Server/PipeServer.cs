using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Threading;
using System.IO;

namespace BattleBabs_Server
{
    class PipeServer
    {
        public static int serverThreadCount = 2;
        public static Thread[] serverThreads = new Thread[2];        

        /// <summary>
        /// This function will create the server pipes via multi-threading so that both scoreboards can connect
        /// to the leaderboard. The threads are made as active and will close when the form's OnFormClosing is
        /// called so that they get closed properly.
        /// </summary>
        public static void openServer()
        {
            Console.WriteLine("Creating {0} server threads for connections",serverThreads);
            for (int i = 0; i < serverThreads.Length; i++) // for integer i starting at 0, while i is less than the length of the server threads array, increment i by 1
            {
                serverThreads[i] = new Thread(new ThreadStart(serverCommandThread));//create the thread
                serverThreads[i].IsBackground = false; //make the thread an active thread
                serverThreads[i].Start(); // start the threads
                Console.WriteLine("Server {0} started.", i);
            }            
        }
        /// <summary>
        /// This will be the function that handles most server pipe duties, and will be the function used in the multithreading
        /// process.
        /// </summary>
        private static void serverCommandThread()
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;
            NamedPipeServerStream server = new NamedPipeServerStream("boardPipe", PipeDirection.InOut, serverThreadCount); // create a server pipe instance
            Console.WriteLine("[{0}] Server pipe created, awaiting a connection from a client pipe.",threadID);
            server.WaitForConnection(); // now we wait for the client to connect
            Console.WriteLine("Scoreboard's client pipe has connected to thread {0}", threadID);
            while(true) // temp while true to make sure stuff works properly after client connection
            {
                Thread.Sleep(500);
                Console.WriteLine("[{0}] Ping!",threadID);
            }
        }

        public static void closeServers()
        {
            for (int i = 0; i < serverThreads.Length; i++) // for integer i starting at 0, while i is less than the length of the server threads array, increment i by 1
            {
                serverThreads[i].Abort(); // stop the threads
                Console.WriteLine("Server {0} stopped.", i);
            }
        }
    }
}
