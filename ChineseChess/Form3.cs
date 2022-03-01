using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseChess
{
    public partial class Form_Request : Form
    {
        int i;
        public delegate void ResultHandler();
        public static event ResultHandler Confirmed1;
        public static event ResultHandler Confirmed2;
        public static event ResultHandler Rejected1;
        public static event ResultHandler Rejected2;
        public Form_Request(string text, int i)
        {
            InitializeComponent();
            label1.Text = text;
            this.i = i;
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (i == 1) // 悔棋
            {
                Confirmed1?.Invoke();
            }
            if (i == 2)
            {
                Confirmed2?.Invoke();
            }
        }

        private void button_reject_Click(object sender, EventArgs e)
        {
            if (i == 1) // 悔棋
            {
                Rejected1?.Invoke();
            }
            if (i == 2)
            {
                Rejected2?.Invoke();
            }
        }
    }
}
