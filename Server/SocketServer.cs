using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class SocketServer
    {
        public Dictionary<string, Socket> clients = new Dictionary<string, Socket> { };
        public Dictionary<Socket, Socket> opponent = new Dictionary<Socket, Socket> { };
        private string ip = string.Empty;
        private int port = 0;
        private Socket socket = null;
        private byte[] buffer = new byte[1024 * 1024 * 2];

        public SocketServer(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }
        public SocketServer(int port)
        {
            this.ip = "0.0.0.0";
            this.port = port;
        }

        public void StartListen()
        {
            try
            {
                //1.0 实例化套接字(IP4寻找协议,流式协议,TCP协议)
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.0 创建IP对象
                //IPAddress address = IPAddress.Parse(ip);
                IPAddress address = IPAddress.Any;
                //3.0 创建网络端口,包括ip和端口
                IPEndPoint endPoint = new IPEndPoint(address, port);
                //4.0 绑定套接字
                socket.Bind(endPoint);
                //5.0 设置最大连接数
                socket.Listen(int.MaxValue);
                Console.WriteLine("监听{0}消息成功", socket.LocalEndPoint.ToString());
                //6.0 开始监听
                Thread thread = new Thread(ListenClientConnect);
                thread.Start();

            }
            catch (Exception ex)
            {
            }
        }

        private void ListenClientConnect()
        {
            try
            {
                while (true)
                {
                    //Socket创建的新连接
                    Socket clientSocket = socket.Accept();
                    Thread thread = new Thread(FormLink);
                    thread.Start(clientSocket);
                }
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 判断是否能开始连接
        /// </summary>
        /// <param name="socket"></param>
        private void FormLink(Object socket)
        {
            Socket clientSocket = (Socket)socket;
            byte[] buf = new byte[1024 * 1024 * 2];
            int len = clientSocket.Receive(buf);
            String[] s = Encoding.UTF8.GetString(buf, 0, len).Split('^');
            Console.WriteLine("接收到客户端{0},消息{1},{2},{3}", clientSocket.RemoteEndPoint.ToString(), s[0], s[1], s[2]);
            try
            {
                // 客户端请求连接对手
                if (s[0].Equals("link-status"))
                {
                    if (!clients.ContainsKey(s[1]) && !s[1].Equals(s[2]))
                    {
                        clients.Add(s[1], clientSocket);
                        int c = 0;
                        while (!clients.ContainsKey(s[2]) && c < 60000)
                        {
                            
                            clientSocket.Send(Encoding.UTF8.GetBytes("wait "));
                            c++;
                            Thread.Sleep(10);
                        }
                        if (c >= 60000)
                        {
                            clientSocket.Send(Encoding.UTF8.GetBytes("failure "));
                            clients.Remove(s[1]);
                        }
                        else
                        {
                            clientSocket.Send(Encoding.UTF8.GetBytes("success-" + c + " "));
                            Console.WriteLine("发送至客户端{0},消息{1}", clientSocket.RemoteEndPoint.ToString(), "success-" + c + " ");
                            opponent.Add(clients[s[1]], clients[s[2]]);
                            Thread thread = new Thread(ReceiveMessage);
                            thread.Start(clientSocket);
                        }
                    }
                    else
                    {
                        clientSocket.Send(Encoding.UTF8.GetBytes("name-repeated "));
                    }
                }
            }
            catch (Exception)
            {
                if (clients.ContainsKey(s[1]))
                    clients.Remove(s[1]);
            }
        }

        /// <summary>
        /// 形成连接后开始转发消息
        /// </summary>
        /// <param name="socket"></param>
        private void ReceiveMessage(Object socket)
        {
            Socket clientSocket = (Socket)socket;
            byte[] buf = new byte[1024 * 1024 * 2];
            while (true)
            {
                try
                {
                    //获取从客户端发来的数据
                    int length = clientSocket.Receive(buf);
                    string step = Encoding.UTF8.GetString(buf, 0, length);
                    Console.WriteLine("接收客户端{0},消息{1}", clientSocket.RemoteEndPoint.ToString(), step);
                    //发送至对手的客户端
                    opponent[clientSocket].Send(Encoding.UTF8.GetBytes(step));
                    Console.WriteLine("发送至客户端{0},消息{1}", opponent[clientSocket].RemoteEndPoint.ToString(), step);
                    string[] over = step.Split('^');
                    //消息为gameover的话就移除双方的socket和昵称记录
                    if (over[0].Equals("gameover"))
                    {
                        foreach(string s in clients.Keys)
                        {
                            if (clients[s] == clientSocket)
                            {
                                clients.Remove(s);
                                break;
                            }
                            
                        }
                        foreach (string s in clients.Keys)
                        {
                            if (clients[s] == opponent[clientSocket])
                            {
                                clients.Remove(s);
                                break;
                            }
                        }
                        
                        opponent.Remove(opponent[clientSocket]);
                        opponent.Remove(clientSocket);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }
            }
        }
    }
}
