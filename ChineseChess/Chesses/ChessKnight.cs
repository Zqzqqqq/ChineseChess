using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessKnight : Chess
    {
        public ChessKnight(int row, int col, ChessFlag flag) : base(row, col, flag, "馬")
        {

        }
        public override Step Move(int row, int col, List<Chess> chesses)
        {

            bool flag = false;
            ChessInfoArgument e = null;

            if (row == this.row - 2 && col == this.col - 1) // 左上1
            {
                foreach (Chess c in chesses)
                {
                    if (c.row == this.row - 1 && c.col == this.col) // 被卡马脚就不能移动
                        return null;
                    if (c.row == this.row - 2 && c.col == this.col - 1) // 目标点有棋子
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
            if (row == this.row - 1 && col == this.col - 2) // 左上2
            {
                foreach (Chess c in chesses)
                {
                    if (c.row == this.row && c.col == this.col - 1) // 被卡马脚就不能移动
                        return null;
                    if (c.row == this.row -1 && c.col == this.col - 2) // 目标点有棋子
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
            if (row == this.row + 1 && col == this.col - 2) // 左下1
            {
                foreach (Chess c in chesses)
                {
                    if (c.row == this.row && c.col == this.col - 1) // 被卡象脚就不能移动
                        return null;
                    if (c.row == this.row + 1 && c.col == this.col - 2) // 目标点有棋子
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
            if (row == this.row + 2 && col == this.col - 1) // 左下2
            {
                foreach (Chess c in chesses)
                {
                    if (c.row == this.row + 1 && c.col == this.col) // 被卡象脚就不能移动
                        return null;
                    if (c.row == this.row + 2 && c.col == this.col - 1) // 目标点有棋子
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
            if (row == this.row + 2 && col == this.col + 1) // 右下1
            {
                foreach (Chess c in chesses)
                {
                    if (c.row == this.row + 1 && c.col == this.col) // 被卡象脚就不能移动
                        return null;
                    if (c.row == this.row + 2 && c.col == this.col + 1) // 目标点有棋子
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
            if (row == this.row + 1 && col == this.col + 2) // 右下2
            {
                foreach (Chess c in chesses)
                {
                    if (c.row == this.row && c.col == this.col + 1) // 被卡象脚就不能移动
                        return null;
                    if (c.row == this.row + 1 && c.col == this.col + 2) // 目标点有棋子
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
            if (row == this.row - 1 && col == this.col + 2) // 右上1
            {
                foreach (Chess c in chesses)
                {
                    if (c.row == this.row && c.col == this.col + 1) // 被卡象脚就不能移动
                        return null;
                    if (c.row == this.row - 1 && c.col == this.col + 2) // 目标点有棋子
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
            if (row == this.row - 2 && col == this.col + 1) // 右上2
            {
                foreach (Chess c in chesses)
                {
                    if (c.row == this.row - 1 && c.col == this.col) // 被卡象脚就不能移动
                        return null;
                    if (c.row == this.row - 2 && c.col == this.col + 1) // 目标点有棋子
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
