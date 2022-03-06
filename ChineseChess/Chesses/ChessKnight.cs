using System;
using System.Collections.Generic;
using System.Drawing;
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

        public override List<Point> Available(int[,] martrix, bool flag)//与象类似，枚举8个方向，不过不用判断边界
        {
            List<Point> aval = new List<Point>();
            if (col - 2 >= 0 && col - 2 <= 8 && row + 1 >= 0 && row + 1 <= 9)
            {
                if (martrix[row, col - 1] == 0)////如果没有被卡马脚
                {
                    if (martrix[row + 1, col - 2] != martrix[row, col])//如果是空点或对方棋子则可移动
                        aval.Add(new Point(row + 1, col - 2));
                }
            }
            if (col - 2 >= 0 && col - 2 <= 8 && row - 1 >= 0 && row - 1 <= 9)
            {
                if (martrix[row, col - 1] == 0)
                {
                    if (martrix[row - 1, col - 2] != martrix[row, col])
                        aval.Add(new Point(row - 1, col - 2));
                }
            }
            if (col + 2 >= 0 && col + 2 <= 8 && row - 1 >= 0 && row - 1 <= 9)
            {
                if (martrix[row, col + 1] == 0)
                {
                    if (martrix[row - 1, col + 2] != martrix[row, col])
                        aval.Add(new Point(row - 1, col + 2));
                }
            }
            if (col + 2 >= 0 && col + 2 <= 8 && row + 1 >= 0 && row + 1 <= 9)
            {
                if (martrix[row, col + 1] == 0)
                {
                    if (martrix[row + 1, col + 2] != martrix[row, col])
                        aval.Add(new Point(row + 1, col + 2));
                }
            }
            if (col - 1 >= 0 && col - 1 <= 8 && row + 2 >= 0 && row + 2 <= 9)
            {
                if (martrix[row + 1, col] == 0)
                {
                    if (martrix[row + 2, col - 1] != martrix[row, col])
                        aval.Add(new Point(row + 2, col - 1));
                }
            }
            if (col + 1 >= 0 && col + 1 <= 8 && row + 2 >= 0 && row + 2 <= 9)
            {
                if (martrix[row + 1, col] == 0)
                {
                    if (martrix[row + 2, col + 1] != martrix[row, col])
                        aval.Add(new Point(row + 2, col + 1));
                }
            }
            if (col - 1 >= 0 && col - 1 <= 8 && row - 2 >= 0 && row - 2 <= 9)
            {
                if (martrix[row - 1, col] == 0)
                {
                    if (martrix[row - 2, col - 1] != martrix[row, col])
                        aval.Add(new Point(row - 2, col - 1));
                }
            }
            if (col + 1 >= 0 && col + 1 <= 8 && row - 2 >= 0 && row - 2 <= 9)
            {
                if (martrix[row - 1, col] == 0)
                {
                    if (martrix[row - 2, col + 1] != martrix[row, col])
                        aval.Add(new Point(row - 2, col + 1));
                }
            }
            return aval;
        }

        /*public override Step Move(int row, int col, List<Chess> chesses)
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


        }*/
    }
}
