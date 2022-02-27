using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessInfoArgument : EventArgs
    {
        private Chess chess;
        public ChessInfoArgument(Chess chess)
        {
            this.chess = chess;
        }
        public Chess Chess
        {
            get { return this.chess; }
        }

    }
}
