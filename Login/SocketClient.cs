using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Login
{
    class SocketClient
    {
        private string ip;
        private int port;
        public Socket socket;
        private byte[] buffer = new byte[1024 * 1024 * 2];

        public SocketClient(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }
        public SocketClient(int port)
        {
            this.ip = "127.0.0.1";
            this.port = port;
        }

        public string StartClient(string src, string dest)
        {
            try
            {
                //实例化套接字(IPv4寻址地址,流式传输,TCP协议)
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //创建IP对象
                IPAddress address = IPAddress.Parse(ip);
                //创建网络端口包括ip和端口
                IPEndPoint endPoint = new IPEndPoint(address, port);
                //建立连接
                socket.Connect(endPoint);
                //向服务器发送消息
                string sendMessage = "link-status" + "^" + src + "^" + dest;
                socket.Send(Encoding.UTF8.GetBytes(sendMessage));
               
                while (true)
                {
                    int len = socket.Receive(buffer);
                    string[] s = Encoding.UTF8.GetString(buffer, 0, len).Split(' ');
                    if (s[s.Length - 2].Contains("success"))
                    {
                        if (s[s.Length - 2].Contains("-0"))
                            return 0+"";
                        return 1+"";
                    }
                    switch (s[s.Length-2])
                    {
                        case "failure":
                            return "failure";
                        case "wait":
                            continue;
                        case "name-repeated":
                            return "name-repeated";
                        default:
                            return "failure";
                    }
                }
            }
            catch (Exception)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                return "failure";
            }
        }

    }
}
