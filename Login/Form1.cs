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

namespace Login
{
    public partial class 中国象棋 : Form
    {

        private SocketClient client = null;
        private Link link = null;
        private Form_Waiting form_Waiting = null;
        private Thread thread = null;
        public ChineseChess.Form1 form1 = null;
        private SynchronizationContext mainThreadSynContext;
        public 中国象棋()
        {
            InitializeComponent();
            //ChineseChess.Form1.StepSend += new ChineseChess.Form1.StepSendHandler(Form1_Sended);
            Link.Succeeded += Link_Succeeded;
            Link.Failed += Link_Failed;
            Link.Repeated += Link_Repeated;
            Form_Waiting.Canceled += Form_Waiting_Canceled;
            mainThreadSynContext = SynchronizationContext.Current;
        }

       
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

        private void Link_Succeeded()
        {
            this.Invoke(new Action(() =>
            {
                this.form_Waiting.Close();
                this.Hide();
            }));
            
            form1 = new ChineseChess.Form1(client.socket);
            form1.ShowDialog();
            /*Thread t = new Thread(BeginReceiving);
            t.Start(client);*/
        }

        private void Link_Failed()
        {
            this.Invoke(new Action(() =>
            {
                this.form_Waiting.Close();
            }));
            MessageBox.Show("连接失败！", "提示");
        }

        private void Link_Repeated()
        {
            this.Invoke(new Action(() =>
            {
                this.form_Waiting.Close();
            }));
            
            MessageBox.Show("该昵称已存在！", "提示");
        }

        private void button_Link_Click(object sender, EventArgs e)
        {
            client = new SocketClient(8088);
            link = new Link(client);
            form_Waiting = new Form_Waiting();
            form_Waiting.Show();
            thread = new Thread(BeginLinking);
            thread.Start();
        }

        private void BeginLinking()
        {
            link.linking(textBox_NickName1.ToString(), textBox_NickName2.ToString());
        }

        /*private void BeginReceiving(object client)
        {
            SocketClient socketClient = (SocketClient)client;
            while (true)
            {
                string s = socketClient.Receive();
                mainThreadSynContext.Post(new SendOrPostCallback(Received), s);
            }
        }

        private void Received(object state)
        {
            form1.addMessage((string)state);
        }*/
    }
}
