using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class CircleBrush : Brush
    {
        public CircleBrush(Color brushColor,int size)
            : base(brushColor, size) { }
        public override void Draw(Bitmap image, int x, int y)
        {
                for (int x1 = x - Size; x1 < x + Size; x1++)
                {
                    for (int y1 = y - Size; y1 < y + Size; y1++)
                    {
                        if ((x1 - x) * (x1 - x) + (y1 - y) * (y1 - y) <= Size * Size)
                        {
                            SetPixel(image,x1, y1, BrushColor);
                        }
                    }
                }
        }
    }
}
