using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sockets;
using ChineseChess;

namespace Login
{
    public partial class ChineseChess : Form
    {

        private SocketClient client = null;
        private Link link = null;
        private Form_Dialog form_Waiting = null;
        private Thread thread = null;
        public Form1 form1 = null;

        public ChineseChess()
        {
            InitializeComponent();
            Link.Succeeded += new Link.LinkSuccessHandler(Link_Succeeded);
            Link.Failed += Link_Failed;
            Link.Repeated += Link_Repeated;
            Form_Dialog.Canceled += Form_Waiting_Canceled;
            Form1.WindowClosed += Form1_Closed;
        }

        /// <summary>
        /// 象棋界面关了则显示登录界面
        /// </summary>
        private void Form1_Closed()
        {
            this.Show();
        }

        /// <summary>
        /// 点击取消按钮
        /// </summary>
        private void Form_Waiting_Canceled()
        {
            if (thread != null)
            {
                thread.Abort();
                this.Invoke(new Action(() =>
                {
                    this.form_Waiting.Close();
                }));
            }
        }

        /// <summary>
        /// 连接成功
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void Link_Succeeded(object o, int e)
        {
            this.Invoke(new Action(() =>
            {
                this.form_Waiting.Close();
                this.Hide();
            }));

            form1 = new global::ChineseChess.Form1(client.socket, textBox_NickName1.Text.ToString(), textBox_NickName2.Text.ToString(), e);
            form1.ShowDialog();

        }

        /// <summary>
        /// 连接失败
        /// </summary>
        private void Link_Failed()
        {
            this.Invoke(new Action(() =>
            {
                this.form_Waiting.Close();
            }));
            MessageBox.Show("连接失败！", "提示");
        }

        /// <summary>
        /// 昵称重复
        /// </summary>
        private void Link_Repeated()
        {
            this.Invoke(new Action(() =>
            {
                this.form_Waiting.Close();
            }));
            
            MessageBox.Show("该昵称已存在！", "提示");
        }

        /// <summary>
        /// 点击连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Link_Click(object sender, EventArgs e)
        {
            client = new SocketClient(8088);
            link = new Link(client);
            form_Waiting = new Form_Dialog("连接中，请稍等");
            form_Waiting.Show();
            thread = new Thread(BeginLinking);
            thread.Start();
        }

        /// <summary>
        /// 开始连接函数
        /// </summary>
        private void BeginLinking()
        {
            link.linking(textBox_NickName1.Text.ToString(), textBox_NickName2.Text.ToString());
        }

    }
}
