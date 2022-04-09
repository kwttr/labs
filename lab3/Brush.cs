using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    abstract class Brush
    {
        public Color BrushColor { get; set; }
        public int Size { get; set; }
        public Brush(Color brushColor, int size)
        {
            BrushColor = brushColor;
            Size = size;
        }
        public abstract void Draw(Bitmap image, int x, int y);
        protected void SetPixel(Bitmap image,int x,int y, Color BrushColor)
        {
            if ((x > 0 && y > 0) &&((x<image.Width)&&y<image.Width))
            {
                image.SetPixel(x,y, BrushColor);
            }
        }
    }
}
