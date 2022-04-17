using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{


    public delegate double GetValueDelegate(double x);

    public abstract class Integrator
    {    
        public abstract double Integrate(GetValueDelegate getValue, double x1, double x2,double N);
        public abstract double Integrate(Equation equation, double x1, double x2,double N);

    }
}
