﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ChineseChess.Chesses;

namespace ChineseChess
{
    enum PlayFlag
    {
        Black,Red
    }
    class ChessBox
    {
        public static int row = 9, col = 8;
        public static int gap, radius, cell;
        int boxwidth, boxheight;
        public List<Chess> chesses;
        public List<Chess>[] lastChesses = new List<Chess>[2];
        public ChessFlag flag;
        public bool picked = false;
        List<Point> avail = new List<Point>();
        public ChessBox(PictureBox box, ChessFlag flag)
        {
            this.flag = flag;
            SetUISize(box);
            InitChesses();
            lastChesses[0] = null;
            lastChesses[1] = null;
            Chess.Eat += new Chess.EatHandler(Chess_Eaten);
        }

        private void InitChesses()
        {
            chesses = new List<Chess>();
            if (flag == ChessFlag.Red)
            {
                chesses.Add(new ChessCannon(2, 1, ChessFlag.Black));
                chesses.Add(new ChessCannon(2, 7, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 0, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 2, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 4, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 6, ChessFlag.Black));
                chesses.Add(new ChessSoldier(3, 8, ChessFlag.Black));
                chesses.Add(new ChessChariot(0, 0, ChessFlag.Black));
                chesses.Add(new ChessChariot(0, 8, ChessFlag.Black));
                chesses.Add(new ChessKnight(0, 1, ChessFlag.Black));
                chesses.Add(new ChessKnight(0, 7, ChessFlag.Black));
                chesses.Add(new ChessElephant(0, 2, ChessFlag.Black));
                chesses.Add(new ChessElephant(0, 6, ChessFlag.Black));
                chesses.Add(new ChessMandarin(0, 3, ChessFlag.Black));
                chesses.Add(new ChessMandarin(0, 5, ChessFlag.Black));
                chesses.Add(new ChessKing(0, 4, ChessFlag.Black));
                chesses.Add(new ChessCannon(7, 1, ChessFlag.Red));
                chesses.Add(new ChessCannon(7, 7, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 0, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 2, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 4, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 6, ChessFlag.Red));
                chesses.Add(new ChessSoldier(6, 8, ChessFlag.Red));
                chesses.Add(new ChessChariot(9, 0, ChessFlag.Red));
                chesses.Add(new ChessChariot(9, 8, ChessFlag.Red));
                chesses.Add(new ChessKnight(9, 1, ChessFlag.Red));
                chesses.Add(new ChessKnight(9, 7, ChessFlag.Red));
                chesses.Add(new ChessElephant(9, 2, ChessFlag.Red));
                chesses.Add(new ChessElephant(9, 6, ChessFlag.Red));
                chesses.Add(new ChessMandarin(9, 3, ChessFlag.Red));
                chesses.Add(new ChessMandarin(9, 5, ChessFlag.Red));
                chesses.Add(new ChessKing(9, 4, ChessFlag.Red));
            }
            else
            {
                chesses.Add(new ChessCannon(2, 1, ChessFlag.Red));
                chesses.Add(new ChessCannon(2, 7, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 0, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 2, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 4, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 6, ChessFlag.Red));
                chesses.Add(new ChessSoldier(3, 8, ChessFlag.Red));
                chesses.Add(new ChessChariot(0, 0, ChessFlag.Red));
                chesses.Add(new ChessChariot(0, 8, ChessFlag.Red));
                chesses.Add(new ChessKnight(0, 1, ChessFlag.Red));
                chesses.Add(new ChessKnight(0, 7, ChessFlag.Red));
                chesses.Add(new ChessElephant(0, 2, ChessFlag.Red));
                chesses.Add(new ChessElephant(0, 6, ChessFlag.Red));
                chesses.Add(new ChessMandarin(0, 3, ChessFlag.Red));
                chesses.Add(new ChessMandarin(0, 5, ChessFlag.Red));
                chesses.Add(new ChessKing(0, 4, ChessFlag.Red));
                chesses.Add(new ChessCannon(7, 1, ChessFlag.Black));
                chesses.Add(new ChessCannon(7, 7, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 0, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 2, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 4, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 6, ChessFlag.Black));
                chesses.Add(new ChessSoldier(6, 8, ChessFlag.Black));
                chesses.Add(new ChessChariot(9, 0, ChessFlag.Black));
                chesses.Add(new ChessChariot(9, 8, ChessFlag.Black));
                chesses.Add(new ChessKnight(9, 1, ChessFlag.Black));
                chesses.Add(new ChessKnight(9, 7, ChessFlag.Black));
                chesses.Add(new ChessElephant(9, 2, ChessFlag.Black));
                chesses.Add(new ChessElephant(9, 6, ChessFlag.Black));
                chesses.Add(new ChessMandarin(9, 3, ChessFlag.Black));
                chesses.Add(new ChessMandarin(9, 5, ChessFlag.Black));
                chesses.Add(new ChessKing(9, 4, ChessFlag.Black));
            }
        }

        public void SetUISize(PictureBox box)
        {
            boxwidth = box.Width;
            boxheight = box.Height;
            /*if (box.Height * 9 > box.Width * 10)
            {
                boxwidth = box.Width;
                boxheight = box.Width * 10 / 9;
            }
            else
            {
                boxwidth = box.Height * 9 / 10;
                boxheight = box.Height;
            }*/
            cell = boxwidth / (col + 1);
            gap = cell;
            radius = cell * 2 / 5;
        }

        public void UpdateChesses(Graphics g1)
        {
            //创建位图
            Bitmap bmp = new Bitmap(boxwidth, boxheight);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(227, 192, 138));
            Pen p = new Pen(Color.Black, 6);
            g.DrawLine(p, 3, 0, 3, boxheight);
            g.DrawLine(p, 0, 3, boxwidth - boxwidth % 8, 3);
            g.DrawLine(p, boxwidth - boxwidth % 8, 0, boxwidth - boxwidth % 8, boxheight);
            g.DrawLine(p, 0, boxheight - 3, boxwidth - boxwidth % 8, boxheight - 3);
            p = new Pen(Color.Black, 2);
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(p, gap / 2, gap * i + gap / 2, gap * 17 / 2, gap * i + gap / 2);
            }
            g.DrawLine(p, gap / 2, gap / 2, gap / 2, gap * 19 / 2);
            g.DrawLine(p, gap * 17 / 2, gap / 2, gap * 17 / 2, gap * 19 / 2);
            for (int i = 1; i < 8; i++)
            {
                g.DrawLine(p, gap * i + gap / 2, gap / 2, gap * i + gap / 2, gap * 9 / 2);
                g.DrawLine(p, gap * i + gap / 2, gap * 5 + gap / 2, gap * i + gap / 2, gap * 19 / 2);
            }
            g.DrawLine(p, gap * 7 / 2, gap / 2, gap * 11 / 2, gap * 5 / 2);
            g.DrawLine(p, gap * 11 / 2, gap / 2, gap * 7 / 2, gap * 5 / 2);
            g.DrawLine(p, gap * 7 / 2, gap * 15 / 2, gap * 11 / 2, gap * 19 / 2);
            g.DrawLine(p, gap * 11 / 2, gap * 15 / 2, gap * 7 / 2, gap * 19 / 2);
            foreach (Chess chess in chesses)
            {
                chess.Draw(g);
            }
            for (int i = 0; i < avail.Count; i++)
            {
                int x = avail[i].Y * ChessBox.cell + ChessBox.cell / 2;
                int y = avail[i].X * ChessBox.cell + ChessBox.cell / 2;
                Rectangle r1 = new Rectangle(x - ChessBox.radius * 11 / 10, y - ChessBox.radius * 11 / 10, 2 * ChessBox.radius * 11 / 10, 2 * ChessBox.radius * 11 / 10);
                g.DrawRectangle(Pens.Green, r1);
            }
            g1.DrawImage(bmp, 0, 0);
            bmp.Dispose();
            g.Dispose();
            //g1.Dispose();
        }

        public void PickChess(Point p)
        {
            int r = (int)((p.Y) / cell);
            int c = (int)((p.X) / cell);
            foreach (Chess chess in chesses)
            {
                chess.Picked = false;
                picked = false;
            }
            for (int i = 0; i < chesses.Count; i++)
            {
                if (r == chesses[i].row && c == chesses[i].col && chesses[i].flag == flag)
                {
                    avail = GetAvailable(chesses[i]);
                    chesses[i].Picked = true;
                    picked = true;
                    return;
                }
            }
            avail.Clear();

        }

        public int JudgeLose()
        {
            int count1 = 0, count2 = 0;
            for (int i = 0; i < chesses.Count; i++)
            {
                if (chesses[i].flag == flag)
                    count1 += GetAvailable(chesses[i]).Count;
                else
                    count2 += GetAvailable(chesses[i]).Count;
            }
            if (count1 == 0)
                return 1;
            else if (count2 == 0)
                return 2;
            return 0;
        }
        public List<Point> GetAvailable(Chess C)
        {
            List<Point> Avail = new List<Point>();
            List<Chess> Tempchesses = new List<Chess>();
            foreach (Chess chess in chesses)
            {
                Tempchesses.Add(chess.Clone());
            }
            for (int i = 0; i < chesses.Count; i++)
            {
                if (C.row == chesses[i].row && C.col == chesses[i].col && chesses[i].flag == C.flag)
                {
                    Avail = chesses[i].Available(GenerateMatrix(), C.flag == flag);
                    for (int j = 0; j < Avail.Count; j++)
                    {
                        chesses[i].Move(Avail[j].X, Avail[j].Y, chesses, C.flag == flag);
                        if (C.flag == flag)
                        {
                            if (JudgeChecked() == true || JudgeFace() == true)
                                Avail.Remove(Avail[j--]);
                        }
                        else
                            if (JudgeCheck() == true || JudgeFace() == true)
                            Avail.Remove(Avail[j--]);
                    }
                    chesses.Clear();
                    foreach (Chess ch in Tempchesses)
                    {
                        chesses.Add(ch.Clone());
                    }
                }
            }
            return Avail;
        }
        public bool JudgeFace()
        {
            int colr = 0, colb = 0, rowr = 0, rowb = 0;
            foreach (Chess chess in chesses)
            {
                if (chess is ChessKing && chess.flag == flag)
                {
                    colr = chess.col;
                    rowr = chess.row;
                }
                if (chess is ChessKing && chess.flag != flag)
                {
                    colb = chess.col;
                    rowb = chess.row;
                }
            }
            if (colr != colb)
                return false;
            foreach (Chess chess in chesses)
            {
                if (chess.col == colr && chess.row > rowb && chess.row < rowr)
                    return false;
            }
            return true;
        }
        public int[,] GenerateMatrix()
        {
            int[,] Matrix = new int[row + 1, col + 1];

            foreach (Chess chess in chesses)
            {
                if (chess.flag != flag)
                {
                    Matrix[chess.row, chess.col] = 1;
                }
                else
                {
                    Matrix[chess.row, chess.col] = 2;
                }
            }
            return Matrix;
        }

        public bool CanMove(Point p)
        {
            int r = (int)((p.Y) / cell);
            int c = (int)((p.X) / cell);
            Point a = new Point(r, c);
            for (int i = 0; i < avail.Count; i++)
            {
                if (avail[i].X == r && avail[i].Y == c)
                    return true;
            }
            return false;
        }

        public bool MoveChess(int sRow, int sCol, int eRow, int eCol)
        {
            foreach(Chess chess in chesses)
            {
                if(chess.row == sRow && chess.col == sCol)
                {
                    lastChesses[1] = new List<Chess>();
                    chesses.ForEach(i => lastChesses[1].Add(i.Clone()));
                    chess.Move(eRow, eCol, chesses, false);
                    return true;
                }
            }
            return false;
        }

        public Step MoveChess(Point p)
        {
            int r = (int)((p.Y) / cell);
            int c = (int)((p.X) / cell);
            Step f = null;
            foreach (Chess chess in chesses)
            {
                if (chess.Picked) // 找到被选中的棋子
                {
                    int sRow = chess.row;
                    int sCol = chess.col;
                    lastChesses[0] = new List<Chess>();
                    chesses.ForEach(i => lastChesses[0].Add(i.Clone()));
                    chess.Move(r, c, chesses, false);
                    chess.Picked = false;
                    this.picked = false;
                    avail.Clear();
                    return new Step(sRow, sCol, r, c);
                }
            }
            return f;
        }

        public bool JudgeCheck()
        {
            int r = -1, c = -1;
            foreach (Chess chess in chesses)
            {
                if (chess is ChessKing && chess.flag != flag)
                {
                    r = chess.row;
                    c = chess.col;
                }
            }
            foreach (Chess chess in chesses)
            {
                if (chess.flag == flag)
                {
                    List<Point> av = chess.Available(GenerateMatrix(), chess.flag == flag);
                    for (int i = 0; i < av.Count; i++)
                    {
                        if (av[i].X == r && av[i].Y == c)
                            return true;
                    }
                }
            }
            return false;
        }
        public bool JudgeChecked()
        {
            int r = -1, c = -1;
            foreach (Chess chess in chesses)
            {
                if (chess is ChessKing && chess.flag == flag)
                {
                    r = chess.row;
                    c = chess.col;
                }
            }
            foreach (Chess chess in chesses)
            {
                if (chess.flag != flag && (chess is ChessCannon) || (chess is ChessChariot) || (chess is ChessKnight))
                {
                    List<Point> av = chess.Available(GenerateMatrix(), chess.flag == flag);
                    for (int i = 0; i < av.Count; i++)
                    {
                        if (av[i].X == r && av[i].Y == c)
                            return true;
                    }
                }
                else if (chess.flag != flag && (chess is ChessSoldier))
                {
                    List<Point> av = chess.Available(GenerateMatrix(), chess.flag == flag);
                    for (int i = 0; i < av.Count; i++)
                    {
                        if (av[i].X == r && av[i].Y == c)
                            return true;
                    }
                }
            }
            return false;
        }

        public void Chess_Eaten(object o, ChessInfoArgument e)
        {
            chesses.Remove(e.Chess);
        }

        public void Regret(int i)
        {
            if (lastChesses[i] != null)
            {
                chesses = new List<Chess>(); 
                lastChesses[i].ForEach(j => chesses.Add(j));
                lastChesses[i] = null;
            }
        }
        public int JudgeGame()
        {
            if (JudgeLose() == 1)
            {
                MessageBox.Show("您被绝杀，输掉了本局比赛！");
                return 1;
            }

            if (JudgeLose() == 2)
            {
                MessageBox.Show("您绝杀了对方，获得了胜利！");
                return 2;
            }
            if (JudgeCheck() == true)
                MessageBox.Show("将军");
            if (JudgeChecked() == true)
                MessageBox.Show("被将军");
            return 0;
        }
    }
}
