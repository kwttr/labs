using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class IntegrateSimpson : Integrator
    {
        public IntegrateSimpson(){ }
        public override double Integrate(GetValueDelegate gv, double x1, double x2)
        {            
            if (x1 >= x2)
            {
                throw new ArgumentException("Правая граница интегирования должны быть больше левой!");
            }
            int N = 100;
            double h = (x2 - x1) / N;
            double sum = 0;
            
            for (int i = 0; i < N; i++)
            {
                sum += (gv(x1 + h * i) + 4 * gv(x1 + h * (i + 0.5)) + gv(x1 + h * (i + 1))) * h / 6;
            }
            return sum;
        }

        public override double Integrate(Equation equation, double x1, double x2)
        {  
           return Integrate(equation.GetValue, x1, x2);
        }

        public override string ToString()
        {
            return "Интегрирование Симсона";
        }
    }
}
