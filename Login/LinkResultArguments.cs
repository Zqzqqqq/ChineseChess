using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class LinkResultArguments : EventArgs
    {
        private int playFlag;
        public LinkResultArguments(int playFlag)
        {
            this.playFlag = playFlag;
        }
        public int PlayFlag
        {
            get { return this.playFlag; }
        }

    }
}
