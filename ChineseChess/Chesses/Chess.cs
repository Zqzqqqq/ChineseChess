﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            Color SColor1 = Color.FromArgb(241, 207, 135);
            Color EColor1 = Color.FromArgb(73, 47, 24);
            Color SColor2 = Color.FromArgb(232, 193, 118);
            Color EColor2 = Color.FromArgb(230, 166, 79);

            Rectangle r1 = new Rectangle(x - ChessBox.radius * 11 / 10, y - ChessBox.radius * 11 / 10, 2 * ChessBox.radius * 11 / 10, 2 * ChessBox.radius * 11 / 10);
            Rectangle r2 = new Rectangle(x - ChessBox.radius * 9 / 10, y - ChessBox.radius * 9 / 10, 2 * ChessBox.radius * 9 / 10, 2 * ChessBox.radius * 9 / 10);

            Brush b1 = new LinearGradientBrush(r1, SColor1, EColor1, LinearGradientMode.ForwardDiagonal);
            Brush b2 = new LinearGradientBrush(r2, SColor2, EColor2, LinearGradientMode.ForwardDiagonal);

            g.FillEllipse(b1, r1.X, r1.Y, r1.Width, r1.Height);
            g.FillEllipse(b2, r2.X, r2.Y, r2.Width, r2.Height);

            g.DrawEllipse(Pens.Gray, x - ChessBox.radius * 8 / 10, y - ChessBox.radius * 8 / 10, 2 * ChessBox.radius * 8 / 10, 2 * ChessBox.radius * 8 / 10);

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
