using System;
using System.Collections.Generic;
using System.Drawing;
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
        public override List<Point> Available(int[,] martrix, bool flag)//士与将类似
        {
            int xboundary1, xboundary2;
            if (flag)
            {
                xboundary1 = 7;
                xboundary2 = 9;
            }
            else
            {
                xboundary1 = 0;
                xboundary2 = 2;
            }

            List<Point> aval = new List<Point>();
            if (col - 1 >= 3 && col - 1 <= 5 && row - 1 >= xboundary1 && row - 1 <= xboundary2)
            {
                if (martrix[row - 1, col - 1] != martrix[row, col])
                {
                    aval.Add(new Point(row - 1, col - 1));
                }
            }
            if (col + 1 >= 3 && col + 1 <= 5 && row - 1 >= xboundary1 && row - 1 <= xboundary2)
            {
                if (martrix[row - 1, col + 1] != martrix[row, col])
                {
                    aval.Add(new Point(row - 1, col + 1));
                }
            }
            if (col - 1 >= 3 && col - 1 <= 5 && row + 1 >= xboundary1 && row + 1 <= xboundary2)
            {
                if (martrix[row + 1, col - 1] != martrix[row, col])
                {
                    aval.Add(new Point(row + 1, col - 1));
                }
            }
            if (col + 1 >= 3 && col + 1 <= 5 && row + 1 >= xboundary1 && row + 1 <= xboundary2)
            {
                if (martrix[row + 1, col + 1] != martrix[row, col])
                {
                    aval.Add(new Point(row + 1, col + 1));
                }
            }
            return aval;
        }

        /*public override Step Move(int row, int col, List<Chess> chesses)
        {
            
            if (row != 7 && row != 8 && row != 9 && col != 3 && col != 4 && col != 5)
            {
                return null;
            }
            else
            {
                bool flag = false;
                ChessInfoArgument e = null;
                if (row == this.row - 1 && col == this.col - 1) // 左上
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col - 1) // 目标点有棋子
                        {
                            if (c.flag == this.flag)
                                return null;
                            flag = true;
                            e = new ChessInfoArgument(c);
                        }
                    }
                    if (flag)
                    {
                        int x = this.row, y = this.col;
                        this.row = row;
                        this.col = col;
                        base.OnEating(e);
                        return new Step(x, y, row, col);
                    }
                    else
                    {
                        int x = this.row, y = this.col;
                        this.row = row;
                        this.col = col;
                        return new Step(x, y, row, col);
                    }
                }
                if (row == this.row + 1 && col == this.col - 1) // 左下
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row + 1 && c.col == this.col - 1) // 目标点有棋子
                        {
                            if (c.flag == this.flag)
                                return null;
                            flag = true;
                            e = new ChessInfoArgument(c);
                        }

                    }
                    if (flag)
                    {
                        int x = this.row, y = this.col;
                        this.row = row;
                        this.col = col;
                        base.OnEating(e);
                        return new Step(x, y, row, col);
                    }
                    else
                    {
                        int x = this.row, y = this.col;
                        this.row = row;
                        this.col = col;
                        return new Step(x, y, row, col);
                    }
                }
                if (row == this.row - 1 && col == this.col + 1) // 右上
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col + 1) // 目标点有棋子
                        {
                            if (c.flag == this.flag)
                                return null;
                            flag = true;
                            e = new ChessInfoArgument(c);
                        }

                    }
                    if (flag)
                    {
                        int x = this.row, y = this.col;
                        this.row = row;
                        this.col = col;
                        base.OnEating(e);
                        return new Step(x, y, row, col);
                    }
                    else
                    {
                        int x = this.row, y = this.col;
                        this.row = row;
                        this.col = col;
                        return new Step(x, y, row, col);
                    }
                }
                if (row == this.row + 1 && col == this.col + 1) // 右下
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row + 1 && c.col == this.col + 1) // 目标点有棋子
                        {
                            if (c.flag == this.flag)
                                return null;
                            flag = true;
                            e = new ChessInfoArgument(c);
                        }
                    }
                    if (flag)
                    {
                        int x = this.row, y = this.col;
                        this.row = row;
                        this.col = col;
                        base.OnEating(e);
                        return new Step(x, y, row, col);
                    }
                    else
                    {
                        int x = this.row, y = this.col;
                        this.row = row;
                        this.col = col;
                        return new Step(x, y, row, col);
                    }
                }
                return null;
            }
        }*/
    }
}
