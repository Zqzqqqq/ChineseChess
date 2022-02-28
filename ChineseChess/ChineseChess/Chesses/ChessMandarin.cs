using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessMandarin : Chess
    {
        public ChessMandarin(int row, int col, ChessFlag flag) : base(row, col, flag, flag == ChessFlag.Black ? "士" : "仕")
        {

        }
        public override bool Move(int row, int col, List<Chess> chesses)
        {
            throw new NotImplementedException();
        }
    }
}
