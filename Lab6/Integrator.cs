using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public delegate double GetValueDelegate(double x);

    public class IntegratorEventArgs
    {
        public double X { get; set; }
        public double F { get; set; }
        public double Integr { get; set; }
    }
    public abstract class Integrator
    {
        public delegate void IntStepDelegate(double x, double f, double integr);
        public delegate void IntFinishDelegate(double integr);
        public EventHandler<IntegratorEventArgs> OnStep;
        public EventHandler<IntegratorEventArgs> OnFinish;

        public abstract double Integrate(GetValueDelegate getValue, double x1, double x2,double N);
        public abstract double Integrate(Equation equation, double x1, double x2,double N);

    }

}
