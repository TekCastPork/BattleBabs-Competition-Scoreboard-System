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

        public static void connectToPipe()
        {
            client = new NamedPipeClientStream(".", "boardPipe", PipeDirection.InOut);
            Console.WriteLine("Attempting to connect to server's pipe.");
            client.Connect();
            Console.WriteLine("Connected to pipe.");
            Console.WriteLine("There are currently {0} pipe server instances open.", client.NumberOfServerInstances);

        }
    }
}
