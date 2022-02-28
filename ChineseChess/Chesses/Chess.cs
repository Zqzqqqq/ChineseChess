using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChineseChess.Chesses;

namespace ChineseChess
{
    enum ChessFlag
    {
        Black,Red
    }

    abstract class Chess
    {
        public int row,col;
        public ChessFlag flag;
        public string name;
        public delegate void EatHandler(object o, ChessInfoArgument e);
        public static event EatHandler Eat;
        public Chess(int row, int col, ChessFlag flag, string name)
        {
            this.row = row;
            this.col = col;
            this.flag = flag;
            this.name = name;
        }

        public void Draw(Graphics g)
        {
            int x = col * ChessBox.cell + ChessBox.cell / 2;
            int y = row * ChessBox.cell + ChessBox.cell / 2;
            g.FillEllipse(new SolidBrush(Color.FromArgb(232, 167, 67)), x - ChessBox.radius, y - ChessBox.radius, 2 * ChessBox.radius, 2 * ChessBox.radius);
            if (flag == ChessFlag.Black)
                g.DrawString(name, new Font("楷体", ChessBox.radius, FontStyle.Bold), Brushes.Black, (float)(x - ChessBox.radius * 0.87), (float)(y - ChessBox.radius * 0.7));
            else
                g.DrawString(name, new Font("楷体", ChessBox.radius, FontStyle.Bold), Brushes.Red, (float)(x - ChessBox.radius * 0.87), (float)(y - ChessBox.radius * 0.7));
        }

        public bool Equal(Chess chess)
        {
            if (chess.row == this.row && chess.col == this.col)
                return true;
            return false;
        }

        public abstract bool Move(int row, int col, List<Chess> chesses);
        public bool Move(int row, int col, List<Chess> chesses, bool flag)
        {
            if (flag) // 如果对面吃棋了，就找到并删掉
            {
                ChessInfoArgument e = null;
                foreach (Chess c in chesses)
                {
                    if (c.row == row && c.col == col)
                    {
                        e = new ChessInfoArgument(c);
                        OnEating(e);
                        break;
                    }
                    return false;
                }
            }
            this.row = row;
            this.col = col;
            return true;
        }
       
        protected virtual void OnEating(ChessInfoArgument e)
        {
            Eat?.Invoke(this, e);
        } 
        

    }
}
