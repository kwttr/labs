using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class QuadEquationTest
    {
        [TestMethod]
        public void DiscriminantTest()
        {
            QuadEquation qE = new QuadEquation();
            double[] arr = new double[1] {-1};
            double[] actual;
            actual = qE.Discriminant(1, 2, 1);
            Assert.AreEqual(arr, actual);
        }
    }
}