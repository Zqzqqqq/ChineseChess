using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.message_processing
{
    class StepMessageProcessing : MessageProcessing
    {
        public void Process(Form1 form, string message)
        {
            string[] m = message.Split(' ');
            form.OpponentMove(int.Parse(m[0]), int.Parse(m[1]), int.Parse(m[2]), int.Parse(m[3]));
        }
    }
}
