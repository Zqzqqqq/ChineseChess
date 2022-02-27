using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseChess
{
    public partial class Form1 : Form
    {
        private Socket socket;
        /*public delegate void StepSendHandler(object sender, StepSendArguments e);
        public static event StepSendHandler StepSend;*/
        public Form1(Socket socket)
        {
            InitializeComponent();
            this.socket = socket;
            Thread t = new Thread(BeginReceiving);
            t.Start(this.socket);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            socket.Send(Encoding.UTF8.GetBytes(textBox2.Text.ToString()));
            /*StepSendArguments se = new StepSendArguments(textBox2.Text.ToString());
            StepSend(this, se);*/
            listBox1.Items.Add(textBox2.Text.ToString());
        }

        public void AddMessage(string message)
        {
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(message);
            }));
        }

        private void BeginReceiving(object client)
        {
            Socket socket = (Socket)client;
            while (true)
            {
                byte[] buf = new byte[1024 * 1024 * 2];
                int len = socket.Receive(buf);
                string s = Encoding.UTF8.GetString(buf, 0, len);
                AddMessage(s);
            }
        }


    }
}
