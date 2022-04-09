using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class SprayBrush : Brush
    {
        public SprayBrush(Color brushColor,int size)
            : base(brushColor, size) { }
        public override void Draw(Bitmap image, int x, int y)
        {
            Random rnd = new Random();
            int r1;
            int r2;
            for (int i = 0; i < 10; i++)
            {
                r1 = rnd.Next(x, x + Size);
                r2 = rnd.Next(y, y + Size);
                SetPixel(image,r1, r2, BrushColor);
            }
        }
    }
}
