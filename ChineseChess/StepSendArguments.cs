using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess
{
        public class StepSendArguments : EventArgs
        {
            private string step;
            public StepSendArguments(string step)
            {
                this.step = step;
            }
            public string Step
            {
                get { return this.step; }
            }
        }
}
