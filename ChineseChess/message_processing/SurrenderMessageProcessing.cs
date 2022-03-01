using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.message_processing
{
    class SurrenderMessageProcessing : MessageProcessing
    {
        public void Process(Form1 form, string message)
        {
            form.Surrendered("对方已投降");
        }
    }
}
