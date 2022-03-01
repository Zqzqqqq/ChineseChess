using System;
using System.Collections.Generic;
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
        public override Step Move(int row, int col, List<Chess> chesses)
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
        }


    }
}
