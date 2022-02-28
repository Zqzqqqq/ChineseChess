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
        int boxwidth, boxheight;
        public List<Chess> chesses;
        public PlayFlag flag;
        public bool picked = false;
        public ChessBox(PictureBox box, PlayFlag flag)
        {
            this.flag = flag;
            SetUISize(box);
            InitChesses();
            Chess.Eat += new Chess.EatHandler(Chess_Eaten);
        }

        private void InitChesses()
        {
            chesses = new List<Chess>();
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

        public void SetUISize(PictureBox box)
        {
            boxwidth = box.Width;
            boxheight = box.Height;
            /*if (box.Height * 9 > box.Width * 10)
            {
                boxwidth = box.Width;
                boxheight = box.Width * 10 / 9;
            }
            else
            {
                boxwidth = box.Height * 9 / 10;
                boxheight = box.Height;
            }*/
            cell = boxwidth / (col + 1);
            gap = cell;
            radius = cell * 2 / 5;
        }

        public void UpdateChesses(Graphics g)
        {
            g.Clear(Color.FromArgb(227, 192, 138));
            Pen p = new Pen(Color.Black, 6);
            g.DrawLine(p, 3, 0, 3, boxheight);
            g.DrawLine(p, 0, 3, boxwidth - boxwidth % 8, 3);
            g.DrawLine(p, boxwidth - boxwidth % 8, 0, boxwidth - boxwidth % 8, boxheight);
            g.DrawLine(p, 0, boxheight - 3, boxwidth - boxwidth % 8, boxheight - 3);
            p = new Pen(Color.Black, 2);
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(p, gap / 2, gap * i + gap / 2, gap * 17 / 2, gap * i + gap / 2);
            }
            g.DrawLine(p, gap / 2, gap / 2, gap / 2, gap * 19 / 2);
            g.DrawLine(p, gap * 17 / 2, gap / 2, gap * 17 / 2, gap * 19 / 2);
            for (int i = 1; i < 8; i++)
            {
                g.DrawLine(p, gap * i + gap / 2, gap / 2, gap * i + gap / 2, gap * 9 / 2);
                g.DrawLine(p, gap * i + gap / 2, gap * 5 + gap / 2, gap * i + gap / 2, gap * 19 / 2);
            }
            g.DrawLine(p, gap * 7 / 2, gap / 2, gap * 11 / 2, gap * 5 / 2);
            g.DrawLine(p, gap * 11 / 2, gap / 2, gap * 7 / 2, gap * 5 / 2);
            g.DrawLine(p, gap * 7 / 2, gap * 15 / 2, gap * 11 / 2, gap * 19 / 2);
            g.DrawLine(p, gap * 11 / 2, gap * 15 / 2, gap * 7 / 2, gap * 19 / 2);
            foreach (Chess chess in chesses)
            {
                chess.Draw(g);
            }
            
        }

        public void PickChess(Point p)
        {
            int r = (int)((p.Y ) / cell);
            int c = (int)((p.X ) / cell);
            foreach(Chess chess in chesses)
            {
                chess.Picked = false;
                picked = false;
                if (r == chess.row && c == chess.col)
                {
                    chess.Picked = true;
                    picked = true;
                    return;
                }
                
            }
        }

        public bool MoveChess(Point p)
        {
            int r = (int)((p.Y) / cell);
            int c = (int)((p.X) / cell);
            bool f = false;
            foreach (Chess chess in chesses)
            {
                if (chess.Picked) // 找到被选中的棋子
                {
                    f = chess.Move(r, c, chesses); // 如果该棋子能动
                        
                    chess.Picked = false;
                    this.picked = false;
                    break;
                }
                

            }
            return f;
        }

        public void Chess_Eaten(object o, ChessInfoArgument e)
        {
            chesses.Remove(e.Chess);
        }
    }
}
