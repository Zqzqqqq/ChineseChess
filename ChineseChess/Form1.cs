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
            float h = (float)(tableLayoutPanel1.Height * 0.80);
            float w = (float)(tableLayoutPanel1.Width * 0.75);
            pictureBox1.Size = new Size((int)Math.Min(h * 9, w * 10) / 10, (int)Math.Min(h * 9, w * 10) / 9);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            /*Bitmap image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            g = Graphics.FromImage(image);
            pictureBox1.BackgroundImage = image;*/
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
        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            float h = (float)(tableLayoutPanel1.Height * 0.80);
            float w = (float)(tableLayoutPanel1.Width * 0.75);
            pictureBox1.Size = new Size((int)Math.Min(h * 9, w * 10) / 10, (int)Math.Min(h * 9, w * 10) / 9);

            if (chessbox != null)
            {
                chessbox.SetUISize(pictureBox1);
                chessbox.UpdateChesses(pictureBox1.CreateGraphics());
            }

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


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            chessbox.SetUISize(pictureBox1);
            if (chessbox.picked) // 如果当前已经选中了某个棋子
            {
                chessbox.MoveChess(e.Location); // 移动棋子，若成功
                
            }
            else
            {
                chessbox.PickChess(e.Location);
            }

            chessbox.UpdateChesses(pictureBox1.CreateGraphics());
        }

       
    }
}
