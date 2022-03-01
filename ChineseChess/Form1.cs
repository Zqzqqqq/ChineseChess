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
        public bool canPick = true;
        MessageProcessingFactory messageProcessingFactory = new MessageProcessingFactory();
        string me, opponent;
        /*public delegate void StepSendHandler(object sender, StepSendArguments e);
        public static event StepSendHandler StepSend;*/
        public Form1(Socket socket, string me, string opponent, int flag)
        {
            InitializeComponent();
            this.socket = socket;
            this.me = me;
            this.opponent = opponent;
            if(flag == 1)
                chessbox = new ChessBox(pictureBox1, PlayFlag.Black);
            else
                chessbox = new ChessBox(pictureBox1, PlayFlag.Red);
            Thread t = new Thread(BeginReceiving);
            t.Start(this.socket);
            SetPictureBoxSize();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        public Form1()
        {
            InitializeComponent();
            chessbox = new ChessBox(pictureBox1, PlayFlag.Red);
        }

        private void SetPictureBoxSize()
        {
            float h = (float)(tableLayoutPanel1.Height * 0.90);
            float w = (float)(tableLayoutPanel1.Width * 0.75);
            pictureBox1.Size = new Size((int)Math.Min(h * 9, w * 10) / 10, (int)Math.Min(h * 9, w * 10) / 9);
        }

        public void AddMessage(string message)
        {
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(message);
            }));
        }

        public void OpponentMove(int sRow, int sCol, int eRow, int eCol)
        {
            chessbox.MoveChess(sRow, sCol, eRow, eCol);
            canPick = true;
            chessbox.UpdateChesses(pictureBox1.CreateGraphics());
        }

        private void BeginReceiving(object client)
        {
            Socket socket = (Socket)client;
            while (true)
            {
                byte[] buf = new byte[1024 * 1024 * 2];
                int len = socket.Receive(buf);
                string[] s = Encoding.UTF8.GetString(buf, 0, len).Split('^');
                string type = s[0];

                string message = "";
                for(int i = 1; i < s.Length; i++)
                {
                    message += s[i];
                }

                messageProcessingFactory.Produce(type).Process(this,message);
            }
        }
        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SetPictureBoxSize();

            if (chessbox != null)
            {
                chessbox.SetUISize(pictureBox1);
                chessbox.UpdateChesses(pictureBox1.CreateGraphics());
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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
            if (canPick)
            {
                if (chessbox.picked) // 如果当前已经选中了某个棋子
                {
                    Step step = null;
                    if ((step=chessbox.MoveChess(e.Location))!=null) // 移动棋子，若成功
                    {
                        canPick = false;
                        string s = "step^"+step.ToString();
                        socket.Send(Encoding.UTF8.GetBytes(s));
                    }
                }
                else
                {
                    chessbox.PickChess(e.Location);
                }

            }
            chessbox.UpdateChesses(pictureBox1.CreateGraphics());
        }

        private void button_regret_Click(object sender, EventArgs e)
        {
            chessbox.Regret(0);
            chessbox.UpdateChesses(pictureBox1.CreateGraphics());
        }

        private void button_surrender_Click(object sender, EventArgs e)
        {

        }

        private void button_draw_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                socket.Send(Encoding.UTF8.GetBytes("chat^" + me+ ":" + textBox1.Text.ToString()));
                AddMessage(me + ":" + textBox1.Text.ToString());
                textBox1.Text = "";

            }
        }
    }
}
