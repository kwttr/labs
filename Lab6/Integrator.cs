﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{


    public class Integrator
    {
        private readonly Equation equation;
        public Integrator(Equation equation)
        {
            //проверяем допустимость параметров:
            if (equation == null)
            {
                throw new ArgumentNullException();
            }
            this.equation = equation;
        }
        /// <summary>
        /// Функция интегрирования
        /// </summary>
        /// <param name="x1">левая граница интегрирования</param>
        /// <param name="x2">правая граница интегрирования</param>
        public double IntegrateRectangle(double x1, double x2)
        {
            //проверяем допустимость параметров:
            if (x1 >= x2)
            {
                throw new ArgumentException("Правая граница интегирования должны быть больше левой!");
            }
            /* для интегирования разобъем исходный отрезок на 100 точек. 
             * Считаем значение функции в точке, умножаем на ширину интервала.
             * Площадь полученного прямоугольника приблизительно равна значению интеграла на этом отрезке
             * суммируем значения площадей, получаем значение интеграла на отрезке [X1;X2]*/
            int N = 100;    //количество интервалов разбиения
            //определяем ширину интервала:
            double h = (x2 - x1) / N;
            double sum = 0; //"накопитель" для значения интеграла
            for (int i = 0; i < N; i++)
            {
                sum = sum + equation.GetValue(x1 + i * h) * h;
            }
            return sum;
        }
        public double IntegrateSimpson(double x1, double x2)
        {
            if (x1 >= x2)
            {
                throw new ArgumentException("равая граница интегирования должны быть больше левой!");
            }
            int N = 100;
            double h = (x2 - x1) / N;
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                //sum = sum+equation.GetValue()
            }
            return sum;
        }
    }
}
