using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessCannon : Chess
    {
        public ChessCannon(int row, int col, ChessFlag flag): base(row, col, flag, "炮")
        {
            
        }
        public override bool Move(int row, int col, List<Chess> chesses)
        {
            throw new NotImplementedException();
        }
    }
}
