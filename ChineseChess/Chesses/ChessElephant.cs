using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessElephant : Chess
    {
        public ChessElephant(int row, int col, ChessFlag flag) : base(row, col, flag, flag == ChessFlag.Black ? "象" : "相")
        {
            
        }

        public override List<Point> Available(int[,] martrix, bool flag)//
        {
            int xboundary1, xboundary2;//根据flag来判断边界
            if (flag)
            {
                xboundary1 = 5;
                xboundary2 = 9;
            }
            else
            {
                xboundary1 = 0;
                xboundary2 = 4;
            }
            List<Point> aval = new List<Point>();
            if (col - 2 >= 0 && col - 2 <= 8 && row - 2 >= xboundary1 && row - 2 <= xboundary2)//枚举左上右上左下右下四个方向
            {
                if (martrix[row - 1, col - 1] == 0)//如果没有被卡象腿
                {
                    if (martrix[row - 2, col - 2] != martrix[row, col])//如果是空点或对方棋子则可移动
                        aval.Add(new Point(row - 2, col - 2));
                }
            }
            if (col + 2 >= 0 && col + 2 <= 8 && row - 2 >= xboundary1 && row - 2 <= xboundary2)
            {
                if (martrix[row - 1, col + 1] == 0)
                {
                    if (martrix[row - 2, col + 2] != martrix[row, col])
                        aval.Add(new Point(row - 2, col + 2));
                }
            }
            if (col - 2 >= 0 && col - 2 <= 8 && row + 2 >= xboundary1 && row + 2 <= xboundary2)
            {
                if (martrix[row + 1, col - 1] == 0)
                {
                    if (martrix[row + 2, col - 2] != martrix[row, col])
                        aval.Add(new Point(row + 2, col - 2));
                }
            }
            if (col + 2 >= 0 && col + 2 <= 8 && row + 2 >= xboundary1 && row + 2 <= xboundary2)
            {
                if (martrix[row + 1, col + 1] == 0)
                {
                    if (martrix[row + 2, col + 2] != martrix[row, col])
                        aval.Add(new Point(row + 2, col + 2));
                }
            }
            return aval;
        }


        /*public override Step Move(int row, int col, List<Chess> chesses)
        {
            bool b = row / 5 == 1;
            if (b)
            {
                if (row != 5 && row != 7 && row != 9)
                    return null;
                if (col != 0 && col != 2 && col != 4 && col != 6 && col != 8)
                    return null;
                bool flag = false;
                ChessInfoArgument e = null;
                
                if (row == this.row - 2 && col == this.col - 2) // 左上
                {
                    foreach(Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col - 1) // 被卡象脚就不能移动
                            return null;
                        if (c.row == this.row - 2 && c.col == this.col - 2) // 目标点有棋子
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
                if(row == this.row + 2 && col == this.col - 2) // 左下
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row + 1 && c.col == this.col - 1) // 被卡象脚就不能移动
                            return null;
                        if (c.row == this.row + 2 && c.col == this.col - 2) // 目标点有棋子
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
                if (row == this.row - 2 && col == this.col + 2) // 右上
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col + 1) // 被卡象脚就不能移动
                            return null;
                        if (c.row == this.row - 2 && c.col == this.col + 2) // 目标点有棋子
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
                if (row == this.row + 2 && col == this.col + 2) // 右下
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row + 1 && c.col == this.col + 1) // 被卡象脚就不能移动
                            return null;
                        if (c.row == this.row + 2 && c.col == this.col + 2) // 目标点有棋子
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
            else
            {
                return null;
            }
        }*/


    }
}
