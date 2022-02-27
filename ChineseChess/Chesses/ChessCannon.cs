using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseChess.Chesses
{
    class ChessCannon : Chess
    {
        public ChessCannon(int row, int col, ChessFlag flag): base(row, col, flag, "炮")
        {
            
        }
        public override bool Move(int row, int col, List<Chess> chesses)
        {
            if(row == this.row)
            {
                bool flag = false; // 是否目标点有对面棋子
                int num = 0;
                ChessInfoArgument e = null;
                foreach (Chess c in chesses)
                {
                    if (c.col == col && c.row == row)
                    {
                        if (c.flag == this.flag) // 目标点是己方则不能动
                            return false;
                        flag = true;
                        e = new ChessInfoArgument(c);
                    }
                    // 统计相同行且纵坐标在两点之间的棋子数
                    if(c.row == this.row && 
                        (c.col < this.col && c.col > col || c.col < col && c.col > this.col))
                    {
                        num++;
                        
                    }

                    if (num >= 2)
                        return false;
                }
                if(flag && (num == 1)) // 目标点为敌方且中间隔了一个棋子，则可以吃
                {
                    this.row = row;
                    this.col = col;
                    base.OnEating(e);
                    return true;
                }
                if(!flag && (num == 0)) // 目标点没东西那么需要路径上没有棋子
                {
                    this.row = row;
                    this.col = col;
                    return true;
                }
            }

            if(col == this.col)
            {
                bool flag = false;
                int num = 0;
                ChessInfoArgument e = null;
                foreach (Chess c in chesses)
                {
                    if (c.col == col && c.row == row)
                    {
                        if (c.flag == this.flag)
                            return false;
                        flag = true; 
                        e = new ChessInfoArgument(c);
                    }
                    if (c.col == this.col &&
                        (c.row < this.row && c.row > row || c.row < row && c.row > this.row))
                    {
                        num++;
                        
                    }
                    if (num >= 2)
                        return false;
                }
                if (flag && (num == 1))
                {
                    this.row = row;
                    this.col = col;
                    base.OnEating(e);
                    return true;
                }
                if (!flag && (num == 0))
                {
                    this.row = row;
                    this.col = col;
                    return true;
                }
            }

            return false; // 非直线移动那么直接返回false
        }

        
    }
}
