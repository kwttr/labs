using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTaskClassLibrary
{
    public class QuadEquation
    {
        public double[] Discriminant(double a,double b,double c)
        {
            if (a == 0) throw new ArgumentException();
            double[] arr = new double[2];
            double d = b * b - 4 * a * c;
            if (d > 0) {
                arr[0] = (-b + Math.Sqrt(d)) / (2 * a);
                arr[1] = (-b - Math.Sqrt(d)) / (2 * a);
            }
            if (d==0)
            {
                arr[0] = -b / (2 * a);
            }
            if (d<0) throw new ArgumentException();
            return arr;
        }
    }
}
