using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.message_processing
{
    class RegretMessageProcessing : MessageProcessing
    {
        public void Process(Form1 form, string message)
        {
            switch (message)
            {
                case "request":
                    form.RegretRequested();
                    break;
                case "confirm":
                    form.RegretConfirmed();
                    break;
                case "reject":
                    form.RegretRejected();
                    break;
                default:
                    break;
            }
        }
    }
}
