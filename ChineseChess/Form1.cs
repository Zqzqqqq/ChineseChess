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
        public bool canPick;
        MessageProcessingFactory messageProcessingFactory = new MessageProcessingFactory();
        string me, opponent;
        Form_Dialog form_Dialog;
        Form_Request form_Request;
        private Thread thread = null;
        private Request request = null;
        public delegate void CloseHandler();
        public static event CloseHandler WindowClosed;
        private bool closedFlag = false;
        public Form1(Socket socket, string me, string opponent, int flag)
        {
            InitializeComponent();
            this.socket = socket;
            this.me = me;
            this.opponent = opponent;
            if(flag == 1)
            {
                chessbox = new ChessBox(pictureBox1, ChessFlag.Black);
                canPick = false;
            }
            else
            {
                chessbox = new ChessBox(pictureBox1, ChessFlag.Red);
                canPick = true;
            }
                
            Thread t = new Thread(BeginReceiving);
            t.Start(this.socket);
            SetPictureBoxSize();
            //Form_Dialog.Canceled += Form_Dialog_Canceled;
            Form_Request.Confirmed1 += RegretConfirmed1;
            Form_Request.Rejected1 += RegretRejected1;
            Form_Request.Confirmed2 += DrawConfirmed1;
            Form_Request.Rejected2 += DrawRejected1;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        

        public Form1()
        {
            InitializeComponent();
            SetPictureBoxSize();
            chessbox = new ChessBox(pictureBox1, ChessFlag.Red);
        }

        /*private void Form_Dialog_Canceled()
        {
            if (thread != null)
            {
                thread.Abort();
                this.Invoke(new Action(() =>
                {
                    this.form_Dialog.Close();
                }));
            }
            
            
        }*/
         
        
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
            if (chessbox.JudgeGame() == 1)
            {
                closedFlag = true;
                this.Close();
            }
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
                    if (chessbox.CanMove(e.Location))
                    {
                        Step step = null;
                        step = chessbox.MoveChess(e.Location);
                        canPick = false;
                        step.sRow = 9 - step.sRow;
                        step.eRow = 9 - step.eRow;
                        step.sCol = 8 - step.sCol;
                        step.eCol = 8 - step.eCol;
                        string s = "step^" + step.ToString();
                        socket.Send(Encoding.UTF8.GetBytes(s));
                        chessbox.UpdateChesses(pictureBox1.CreateGraphics());
                        if (chessbox.JudgeGame() == 2)
                        {
                            closedFlag = true;
                            this.Close();
                        }
                    }
                    else
                    {
                        chessbox.PickChess(e.Location);
                        chessbox.UpdateChesses(pictureBox1.CreateGraphics());
                    }
                }
                else
                {
                    chessbox.PickChess(e.Location);
                    chessbox.UpdateChesses(pictureBox1.CreateGraphics());
                }

            }
        }

        private void button_regret_Click(object sender, EventArgs e)
        {
            if (chessbox.lastChesses[0] != null)
            {
                form_Dialog = new Form_Dialog("等待对方同意中");
                form_Dialog.HideButton();
                form_Dialog.Show();
                //socket.Send(Encoding.UTF8.GetBytes("regret^request"));
                request = new Request(socket);
                thread = new Thread(BeginRegretRequesting);
                thread.Start();
            }
        }

        public void RegretConfirmed1()
        {
            socket.Send(Encoding.UTF8.GetBytes("regret^confirm"));
            this.form_Request.Close();
            canPick = false;
            chessbox.Regret(1);
            chessbox.UpdateChesses(pictureBox1.CreateGraphics());
        }

        public void RegretRejected1()
        {
            socket.Send(Encoding.UTF8.GetBytes("regret^reject"));
            this.form_Request.Close();
        }

        public void RegretConfirmed()
        {
            /*this.Invoke(new Action(() =>
            {
                chessbox.Regret(0);
                chessbox.UpdateChesses(pictureBox1.CreateGraphics());
            }));*/
            this.form_Dialog.Close();
            ShowHint("对方接受了您的悔棋要求！");
            canPick = true;
            chessbox.Regret(0);
            chessbox.UpdateChesses(pictureBox1.CreateGraphics());
        }

        public void RegretRejected()
        {
            this.form_Dialog.Close();
            ShowHint("对方拒绝了您的悔棋要求！");
            
        }

        public void RegretRequested()
        {
            form_Request = new Form_Request("对方向您发起了悔棋请求！",1);
            form_Request.ShowDialog();
        }

        private void BeginRegretRequesting()
        {
            request.Requesting("regret^request");
        }

        public void ShowHint(string hint)
        {
            MessageBox.Show(hint, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_surrender_Click(object sender, EventArgs e)
        {
            ShowHint("投降成功！");
            this.Close();
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            form_Dialog = new Form_Dialog("等待对方同意中");
            form_Dialog.Show();
            form_Dialog.HideButton();
            request = new Request(socket);
            thread = new Thread(BeginDrawRequesting);
            thread.Start();
        }

        public void DrawConfirmed1()
        {
            socket.Send(Encoding.UTF8.GetBytes("draw^confirm"));
            this.form_Request.Close();
            closedFlag = true;
            ShowHint("和棋成功！");
            this.Close();
        }

        public void DrawRejected1()
        {
            socket.Send(Encoding.UTF8.GetBytes("draw^reject"));
            this.form_Request.Close();
        }

        public void DrawConfirmed()
        {
            this.form_Dialog.Close();
            closedFlag = true;
            ShowHint("对方接受了您的和棋要求！");
            this.Close();
        }

        public void DrawRejected()
        {
            this.form_Dialog.Close();
            ShowHint("对方拒绝了您的和棋要求！");

        }

        public void DrawRequested()
        {
            form_Request = new Form_Request("对方向您发起了和棋请求！",2);
            form_Request.ShowDialog();
        }

        private void BeginDrawRequesting()
        {
            request.Requesting("draw^request");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!closedFlag)
                socket.Send(Encoding.UTF8.GetBytes("gameover^ "));
            WindowClosed?.Invoke();
        }
        
        public void Surrendered(string s)
        {
            ShowHint(s);
            closedFlag = true;
            this.Close();
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
