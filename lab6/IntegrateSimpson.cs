using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Lab6
{
    public class IntegrateSimpson : Integrator
    {
        public IntegrateSimpson(){ }
        public override double Integrate(GetValueDelegate gv, double x1, double x2,double N)
        {
            if (x1 >= x2)
            {
                throw new ArgumentException("Правая граница интегирования должны быть больше левой!");
            }
            if (N < 0) throw new ArgumentException();
            double h = (x2 - x1) / N;
            double sum = 0;
            BlockingButton(false);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                Thread.Sleep(100);
                sum += (gv(x1 + h * i) + 4 * gv(x1 + h * (i + 0.5)) + gv(x1 + h * (i + 1))) * h / 6;
                RaiseStepEvent(x1 + i, gv(x1 + i), sum);
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            int ThreadSum = ts.Milliseconds;
            ThreadOnFinishCount(ThreadSum);
            RaiseFinishEvent(sum);
            BlockingButton(true);
            return sum;
        }
        void ThreadOnFinishCount(int ThreadSum)
        {
            if (ThreadCount != null)
            {
                ThreadEventArgs args = new ThreadEventArgs()
                {
                    CalcTime = ThreadSum
                };
                ThreadCount(this, args);
            }
        }
        void RaiseStepEvent(double x, double f, double sum)
        {
            if (OnStep != null)
            {
                IntegratorEventArgs args = new IntegratorEventArgs()
                {
                    X = x,
                    F = f,
                    Integr = sum
                };
                OnStep(this, args);
            }
        }
        void BlockingButton(bool sw)
        {
            ButtonEventArgs args = new ButtonEventArgs()
            {
                sw = sw
            };
            BlockButton(this, args);
        }
        void RaiseFinishEvent(double sum)
        {
            if (OnFinish != null)
            {
                IntegratorEventArgs args = new IntegratorEventArgs()
                {
                    Integr = sum
                };
                OnFinish(this,args);
            }
        }
        public override double Integrate(Equation equation, double x1, double x2, double N)
        {
            return Integrate(equation.GetValue, x1, x2,N);
        }

        public override string ToString()
        {
            return "Интегрирование Симсона";
        }
    }
}
