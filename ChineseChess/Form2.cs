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
    public partial class Form_Dialog : Form
    {
        public delegate void CancelHandler();
        public static event CancelHandler Canceled;
        
        public Form_Dialog(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Canceled?.Invoke();
        }

        public void HideButton()
        {
            button1.Hide();
        }
    }
}
