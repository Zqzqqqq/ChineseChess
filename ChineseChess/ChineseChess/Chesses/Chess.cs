using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            g.FillEllipse(Brushes.Gray, x - ChessBox.radius, y - ChessBox.radius, 2 * ChessBox.radius, 2 * ChessBox.radius);
            if (flag == ChessFlag.Black)
                g.DrawString(name, new Font("宋体", 14), Brushes.Black, (float)(x - ChessBox.radius * 0.5), (float)(y - ChessBox.radius * 0.5));
            else
                g.DrawString(name, new Font("宋体", 14), Brushes.Red, (float)(x - ChessBox.radius * 0.5), (float)(y - ChessBox.radius * 0.5));
        }

        public bool Equal(Chess chess)
        {
            if (chess.row == this.row && chess.col == this.col)
                return true;
            return false;
        }

        public abstract bool Move(int row, int col, List<Chess> chesses);
        
        // changeeawdDwdasd
        // dwadasd
    }
}
