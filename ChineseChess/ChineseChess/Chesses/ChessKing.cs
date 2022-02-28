using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessKing : Chess
    {
        public ChessKing(int row, int col, ChessFlag flag) : base(row, col, flag, flag == ChessFlag.Black ? "将" : "帥")
        {

        }
        public override bool Move(int row, int col, List<Chess> chesses)
        {
            throw new NotImplementedException();
        }
    }
}
