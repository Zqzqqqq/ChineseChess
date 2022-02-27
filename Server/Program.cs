using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string s = "wait wait wait wait ";
            string[] s1 = s.Split(' ');
            Console.WriteLine(s1[s1.Length-2]);
            SocketServer server = new SocketServer(8088);
            server.StartListen();
            Console.ReadKey();

        }
    }
}
