using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    static class DrawHelper
    {
        public static void DrawLine(Bitmap image,Color brushColor, int x1, int y1, int x2, int y2)
        {
            if (x2<x1) { int swap = x1; x1 = x2; x2 = swap; }
            if (x2 - x1 != 0)
            {
                double k = (double)(y2 - y1) / (double)(x2 - x1);
                double b = y2 - k * x2;

                for (int i = x1; i < x2; i++)
                {
                    double y = (k*x1) + b;
                    image.SetPixel(x1, (int)y, brushColor);
                    x1++;
                }
            }
            else
            {
                if (y2 < y1) { int swap = y1; y1 = y2; y2 = swap; }
                for (int i = 0; i < y2 - y1; i++)
                {
                    image.SetPixel(x1, y1 + i, brushColor);
                }
            }
        }
    }
}
