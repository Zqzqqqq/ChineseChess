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
            bool b = this.row / 5 == 1;
            if (b) // 没有过河的时候只能往前走
            {
                if (col != this.col || row != this.row - 1)
                    return false;
                else
                {
                    bool flag = false;
                    ChessInfoArgument e = null;

                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col) // 目标点有棋子
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
            }
            else
            {
                bool flag = false;
                ChessInfoArgument e = null;
                if (row == this.row && col == this.col - 1) // 左
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row && c.col == this.col - 1) // 目标点有棋子
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
                if (row == this.row && col == this.col + 1) // 右
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row && c.col == this.col + 1) // 目标点有棋子
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
                if (row == this.row - 1 && col == this.col) // 上
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col) // 目标点有棋子
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
