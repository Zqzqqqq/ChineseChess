using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess
{
    class Request
    {
        Socket socket;
        
        public Request(Socket socket)
        {
            this.socket = socket;
        }

        public void Requesting(string s)
        {
            socket.Send(Encoding.UTF8.GetBytes(s));
        }
    }
}
