using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab6;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void RectangleIntegrationTest()
        {
            IntegrateSimpson ig = new IntegrateSimpson();
            double S = ig.Integrate(new MonoEquation(1, 1).GetValue, 0, 10, 100);
            double expected = 60;
            Assert.AreEqual(expected, S,0.01);
        }
        [TestMethod]
        public void RectangleIntegrationAreInvalidTest1()
        {
            IntegrateSimpson ig = new IntegrateSimpson();
            double S = ig.Integrate(new MonoEquation(1, 1).GetValue, 0, 10, 100);
            double expected = 0;
            Assert.IsTrue(Math.Abs(S - expected) > 0.01);
        }
        [TestMethod]
        public void RectangleIntegrationAreInvalidTest2()
        {
            IntegrateSimpson ig = new IntegrateSimpson();

            Assert.ThrowsException<ArgumentException>(() => 
               ig.Integrate(new MonoEquation(1, 1).GetValue, 10, 0, 100),
               "Правая граница интегирования должны быть больше левой!");
        }
        [TestMethod]
        public void RectangleIntegrationAreInvalidTest3()
        {
            IntegrateSimpson ig = new IntegrateSimpson();

            Assert.ThrowsException<ArgumentException>(() =>
                ig.Integrate(new MonoEquation(1, 1).GetValue, 0, 10, -2),
                "Шаг интегрирования не может быть отрицательным или равным нулю");
        }
    }
}