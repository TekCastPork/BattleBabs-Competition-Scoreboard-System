using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace BattleBabs_Server
{
    class PipeServer
    {
        public static NamedPipeServerStream server;

        public static void openServer(PipeDirection direction)
        {
            server = new NamedPipeServerStream("leaderboard", direction);
        }
    }
}
