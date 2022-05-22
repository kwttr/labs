using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class MonoEquation : Equation
    {
        public double k { get; set; }
        public double b { get; set; }
        public MonoEquation(double k,double b)
        {
            this.k = k;
            this.b = b;
        }
        public override double GetValue(double x)
        {
            return k * x + b;
        }
        public override string ToString()
        {
            return "Линейная функция";
        }
    }
}
