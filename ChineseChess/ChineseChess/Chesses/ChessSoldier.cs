using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessSoldier : Chess
    {
        public ChessSoldier(int row, int col, ChessFlag flag) : base(row, col, flag, flag == ChessFlag.Black ? "卒" : "兵")
        {
        }
    
        public override bool Move(int row, int col, List<Chess> chesses)
        {
            throw new NotImplementedException();
        }
    }
}
