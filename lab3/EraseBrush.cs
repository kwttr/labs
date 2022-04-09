using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class EraseBrush : Brush
    {
        public EraseBrush(Color brushColor, int size)
            : base(brushColor, size) { }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {
                  //  if (x0 > pictureBox1.Width || y0 > pictureBox1.Height) break;
                    SetPixel(image,x0, y0, Color.White);
                }
            }
        }
    }
}
