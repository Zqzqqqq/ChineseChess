using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess
{

    class Step
    {
        public int sRow, sCol, eRow, eCol;
        public Step(int sRow,int sCol, int eRow, int eCol)
        {
            this.sRow = sRow;
            this.sCol = sCol;
            this.eRow = eRow;
            this.eCol = eCol;
        }

        public override string ToString()
        {
            return sRow + " " + sCol + " " + eRow + " " + eCol;
        }
    }
}
