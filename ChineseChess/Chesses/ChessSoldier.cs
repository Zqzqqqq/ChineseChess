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

        public override Step Move(int row, int col, List<Chess> chesses)
        {
            bool b = this.row / 5 == 1;
            if (b) // 没有过河的时候只能往前走
            {
                if (col != this.col || row != this.row - 1)
                    return null;
                else
                {
                    bool flag = false;
                    ChessInfoArgument e = null;

                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col) // 目标点有棋子
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
                if (row == this.row && col == this.col + 1) // 右
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row && c.col == this.col + 1) // 目标点有棋子
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
                if (row == this.row - 1 && col == this.col) // 上
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col) // 目标点有棋子
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
        }
    }
}
