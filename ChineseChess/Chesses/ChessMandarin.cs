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
            bool b = this.row / 5 == 1;
            if (row != 7 && row != 8 && row != 9 && col != 3 && col != 4 && col != 5)
            {
                return false;
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
                                return false;
                            flag = true;
                            e = new ChessInfoArgument(c);
                        }
                    }
                    if (flag)
                    {
                        this.row = row;
                        this.col = col;
                        base.OnEating(e);
                        return true;
                    }
                    else
                    {
                        this.row = row;
                        this.col = col;
                        return true;
                    }
                }
                if (row == this.row + 1 && col == this.col - 1) // 左下
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row + 1 && c.col == this.col - 1) // 目标点有棋子
                        {
                            if (c.flag == this.flag)
                                return false;
                            flag = true;
                            e = new ChessInfoArgument(c);
                        }

                    }
                    if (flag)
                    {
                        this.row = row;
                        this.col = col;
                        base.OnEating(e);
                        return true;
                    }
                    else
                    {
                        this.row = row;
                        this.col = col;
                        return true;
                    }
                }
                if (row == this.row - 1 && col == this.col + 1) // 右上
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col + 1) // 目标点有棋子
                        {
                            if (c.flag == this.flag)
                                return false;
                            flag = true;
                            e = new ChessInfoArgument(c);
                        }

                    }
                    if (flag)
                    {
                        this.row = row;
                        this.col = col;
                        base.OnEating(e);
                        return true;
                    }
                    else
                    {
                        this.row = row;
                        this.col = col;
                        return true;
                    }
                }
                if (row == this.row + 1 && col == this.col + 1) // 右下
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row + 1 && c.col == this.col + 1) // 目标点有棋子
                        {
                            if (c.flag == this.flag)
                                return false;
                            flag = true;
                            e = new ChessInfoArgument(c);
                        }
                    }
                    if (flag)
                    {
                        this.row = row;
                        this.col = col;
                        base.OnEating(e);
                        return true;
                    }
                    else
                    {
                        this.row = row;
                        this.col = col;
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
