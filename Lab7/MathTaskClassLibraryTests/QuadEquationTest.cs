using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class QuadEquationTest
    {
        [TestMethod]
        public void DiscriminantZeroTest()
        {
            QuadEquation qE = new QuadEquation();
            double[] arr = new double[1] {-1};
            double[] actual = new double[1];
            actual = qE.SolveEquation(1, 2, 1);
            Assert.AreEqual(arr[0],actual[0],0.01);
        }
        [TestMethod]
        public void DiscriminantBelowZeroTest()
        {
            QuadEquation qE = new QuadEquation();
            double[] arr = new double[1] { -1 };
            Assert.ThrowsException<ArgumentException>(() => qE.SolveEquation(1, 1, 1), "Дискриминант меньше нуля");
        }
        [TestMethod]
        public void DiscriminantGreaterZeroTest()
        {
            QuadEquation qE = new QuadEquation();
            double[] arr = new double[2] { -0.20, -4.79 };
            double[] actual = new double[2];
            actual = qE.SolveEquation(1, 5, 1);
            Assert.AreEqual(arr[0], actual[0], 0.01);
            Assert.AreEqual(arr[1], actual[1], 0.01);
        }
        [TestMethod]
        public void AZeroTest()
        {
            QuadEquation qE = new QuadEquation();
            Assert.ThrowsException<ArgumentException>(() => qE.SolveEquation(0, 1, 1), "Уравнение не квадратичное");
        }
    }
}