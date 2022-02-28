using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseChess
{
    class GameBoard
    {
        public void Draw(PictureBox box)
        {
            Graphics g = box.CreateGraphics();
            int height, width;
            if (box.Height * 9 > box.Width * 10)
            {
                width = box.Width;
                height = width * 10 / 9;
            }
            else
            {
                height = box.Height;
                width = height * 9 / 10;
            }
            Pen p = new Pen(Color.Black, 6);
            g.DrawLine(p, 3, 0, 3, height);
            g.DrawLine(p, 0, 3, width - width % 8, 3);
            g.DrawLine(p, width - width % 8, 0, width - width % 8, height);
            g.DrawLine(p, 0, height - 3, width - width % 8, height - 3);
            float gap = width / 9;
            //gap = (int)gap;
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
            
        }
    }
}
