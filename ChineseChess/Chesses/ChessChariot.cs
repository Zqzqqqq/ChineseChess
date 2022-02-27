using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessChariot : Chess
    {
        public ChessChariot(int row, int col, ChessFlag flag) : base(row, col, flag, "車")
        {

        }
        public override bool Move(int row, int col, List<Chess> chesses)
        {
            throw new NotImplementedException();
        }
    }
}
