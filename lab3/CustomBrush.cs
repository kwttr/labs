using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class CustomBrush : Brush
    {
        const double Scale = 6;
        public CustomBrush(Color brushColor, int size)
            : base(brushColor, size) { }
        public override void Draw(Bitmap image, int x, int y)
        {
            double x1=0,y1=0,x0,y0;
            double r = 0;
            for (int phi = 0; phi < 360; phi++)
            {
                x0 = x1;
                y0 = y1;
                r = Size*Math.Sin(3 * phi);
                x1 = Math.Cos(phi) * r;
                y1 = Math.Sin(phi) * r;
                //DrawHelper.DrawLine(image, BrushColor, (int)x0+x,(int)y0+y,(int)x1+x,(int)y1+y);
                SetPixel(image,(int)x1+x, (int)y1+y, BrushColor);
            }
        }
    }
}
