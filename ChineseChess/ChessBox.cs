using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChineseChess.Chesses;

namespace ChineseChess
{
    enum PlayFlag
    {
        Black,Red
    }
    class ChessBox
    {
        public static int row = 9, col = 8;
        public static int gap, radius, cell;
        public List<Chess> chesses;
        public PlayFlag flag;
        public ChessBox(PictureBox box, PlayFlag flag)
        {
            this.flag = flag;
            SetUISize(box.Width, box.Height);
            InitChesses();
        }

        private void InitChesses()
        {
            if (flag == PlayFlag.Red)
            {
                chesses.Add(new ChessCannon(2, 1, ChessFlag.Black));
                chesses.Add(new ChessCannon(2, 7, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 0, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 2, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 4, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 6, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 8, ChessFlag.Black));
                chesses.Add(new ChessChariot(0, 0, ChessFlag.Black));
                chesses.Add(new ChessChariot(0, 8, ChessFlag.Black));
                chesses.Add(new ChessKnight(0, 1, ChessFlag.Black));
                chesses.Add(new ChessKnight(0, 7, ChessFlag.Black));
                chesses.Add(new ChessElephant(0, 2, ChessFlag.Black));
                chesses.Add(new ChessElephant(0, 6, ChessFlag.Black));
                chesses.Add(new ChessMandarin(0, 3, ChessFlag.Black));
                chesses.Add(new ChessMandarin(0, 5, ChessFlag.Black));
                chesses.Add(new ChessKing(0, 4, ChessFlag.Black));
                chesses.Add(new ChessCannon(7, 1, ChessFlag.Red));
                chesses.Add(new ChessCannon(7, 7, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 0, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 2, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 4, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 6, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 8, ChessFlag.Red));
                chesses.Add(new ChessChariot(9, 0, ChessFlag.Red));
                chesses.Add(new ChessChariot(9, 8, ChessFlag.Red));
                chesses.Add(new ChessKnight(9, 1, ChessFlag.Red));
                chesses.Add(new ChessKnight(9, 7, ChessFlag.Red));
                chesses.Add(new ChessElephant(9, 2, ChessFlag.Red));
                chesses.Add(new ChessElephant(9, 6, ChessFlag.Red));
                chesses.Add(new ChessMandarin(9, 3, ChessFlag.Red));
                chesses.Add(new ChessMandarin(9, 5, ChessFlag.Red));
                chesses.Add(new ChessKing(9, 4, ChessFlag.Red));
            }
            else
            {
                chesses.Add(new ChessCannon(2, 1, ChessFlag.Red));
                chesses.Add(new ChessCannon(2, 7, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 0, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 2, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 4, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 6, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 8, ChessFlag.Red));
                chesses.Add(new ChessChariot(0, 0, ChessFlag.Red));
                chesses.Add(new ChessChariot(0, 8, ChessFlag.Red));
                chesses.Add(new ChessKnight(0, 1, ChessFlag.Red));
                chesses.Add(new ChessKnight(0, 7, ChessFlag.Red));
                chesses.Add(new ChessElephant(0, 2, ChessFlag.Red));
                chesses.Add(new ChessElephant(0, 6, ChessFlag.Red));
                chesses.Add(new ChessMandarin(0, 3, ChessFlag.Red));
                chesses.Add(new ChessMandarin(0, 5, ChessFlag.Red));
                chesses.Add(new ChessKing(0, 4, ChessFlag.Red));
                chesses.Add(new ChessCannon(7, 1, ChessFlag.Black));
                chesses.Add(new ChessCannon(7, 7, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 0, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 2, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 4, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 6, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 8, ChessFlag.Black));
                chesses.Add(new ChessChariot(9, 0, ChessFlag.Black));
                chesses.Add(new ChessChariot(9, 8, ChessFlag.Black));
                chesses.Add(new ChessKnight(9, 1, ChessFlag.Black));
                chesses.Add(new ChessKnight(9, 7, ChessFlag.Black));
                chesses.Add(new ChessElephant(9, 2, ChessFlag.Black));
                chesses.Add(new ChessElephant(9, 6, ChessFlag.Black));
                chesses.Add(new ChessMandarin(9, 3, ChessFlag.Black));
                chesses.Add(new ChessMandarin(9, 5, ChessFlag.Black));
                chesses.Add(new ChessKing(9, 4, ChessFlag.Black));
            }
        }

        public void SetUISize(int width, int height)
        {

        }

        public void UpdateChesses(Graphics g)
        {
            foreach(Chess chess in chesses)
            {
                chess.Draw(g);
            }
        }

        
    }
}
