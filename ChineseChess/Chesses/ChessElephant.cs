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
        public override bool Move(int row, int col, List<Chess> chesses)
        {
            bool b = row / 5 == 1;
            if (b)
            {
                if (row != 5 && row != 7 && row != 9)
                    return false;
                if (col != 0 && col != 2 && col != 4 && col != 6 && col != 8)
                    return false;
                bool flag = false;
                ChessInfoArgument e = null;
                
                if (row == this.row - 2 && col == this.col - 2) // 左上
                {
                    foreach(Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col - 1) // 被卡象脚就不能移动
                            return false;
                        if (c.row == this.row - 2 && c.col == this.col - 2) // 目标点有棋子
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
                if(row == this.row + 2 && col == this.col - 2) // 左下
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row + 1 && c.col == this.col - 1) // 被卡象脚就不能移动
                            return false;
                        if (c.row == this.row + 2 && c.col == this.col - 2) // 目标点有棋子
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
                if (row == this.row - 2 && col == this.col + 2) // 右上
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row - 1 && c.col == this.col + 1) // 被卡象脚就不能移动
                            return false;
                        if (c.row == this.row - 2 && c.col == this.col + 2) // 目标点有棋子
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
                if (row == this.row + 2 && col == this.col + 2) // 右下
                {
                    foreach (Chess c in chesses)
                    {
                        if (c.row == this.row + 1 && c.col == this.col + 1) // 被卡象脚就不能移动
                            return false;
                        if (c.row == this.row + 2 && c.col == this.col + 2) // 目标点有棋子
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
            else
            {
                return false;
            }
        }


    }
}
