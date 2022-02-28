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
        ChessBox chessbox;
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
            float h = (float)(this.Height * 0.8);
            float w = (float)(this.Width * 0.75);
            //pictureBox1.Size = new Size(412, 458);
            pictureBox1.Size = new Size((int)Math.Min(h * 9, w * 10) / 10, (int)Math.Min(h * 9, w * 10) / 9);
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
        protected override void OnPaint(PaintEventArgs e)
        {
<<<<<<< HEAD
            base.OnPaint(e);  
=======
            base.OnPaint(e);
            
>>>>>>> 37ab955684a07ff5ff29622078eb5a2d272bc535
            Graphics g = pictureBox1.CreateGraphics();
            chessbox.SetUISize(pictureBox1);
            chessbox.UpdateChesses(g);
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            float h = (float)(this.Height * 0.8);
            float w = (float)(this.Width * 0.75);
            //pictureBox1.Size = new Size(412, 458);
            pictureBox1.Size = new Size((int)Math.Min(h * 9, w * 10) / 10, (int)Math.Min(h * 9, w * 10) /9);
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chessbox = new ChessBox(pictureBox1, PlayFlag.Black);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            chessbox.SetUISize(pictureBox1);
            chessbox.UpdateChesses(g);
        }
    }
}
