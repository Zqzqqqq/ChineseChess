using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessKing : Chess
    {
        public ChessKing(int row, int col, ChessFlag flag) : base(row, col, flag, flag == ChessFlag.Black ? "将" : "帥")
        {

        }
        public override bool Move(int row, int col, List<Chess> chesses)
        {

            if (col != 3 && col != 4 && col != 5)
            {
                return false;
            }
            else
            {
                if (row != 7 && row != 8 && row != 9 )
                {
                    ChessInfoArgument e = null;
                    foreach (Chess chess in chesses)
                    {
                        if ((chess.name.Equals("将") || chess.name.Equals("帥")) && (chess.flag != this.flag))
                        {
                            // 如果选中的不是对方的主将或双方主将不在一列上，直接返回false
                            if (chess.row != row || chess.col != col || chess.col != this.col)
                                return false;
                            e = new ChessInfoArgument(chess);
                            break;
                        }
                    }

                    foreach (Chess chess in chesses)
                    {
                        // 如果敌我主将间有棋子，直接返回false
                        if (chess.col == e.Chess.col && chess.row > e.Chess.row && chess.row < this.row)
                        {
                            return false;
                        }
                    }

                    this.row = row;
                    this.col = col;
                    base.OnEating(e);
                    return true;
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
                    if (row == this.row + 1 && col == this.col) // 下
                    {
                        foreach (Chess c in chesses)
                        {
                            if (c.row == this.row + 1 && c.col == this.col) // 目标点有棋子
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
}
