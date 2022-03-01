using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.message_processing
{
    class DrawMessageProcessing : MessageProcessing
    {
        public void Process(Form1 form, string message)
        {
            switch (message)
            {
                case "request":
                    form.DrawRequested();
                    break;
                case "confirm":
                    form.DrawConfirmed();
                    break;
                case "reject":
                    form.DrawRejected();
                    break;
                default:
                    break;
            }
        }
    }
}
