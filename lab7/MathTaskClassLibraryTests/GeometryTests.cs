using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class GeometryTests
    {
        [TestMethod]
        public void RectangleAreaTest()
        {
            int a = 3;
            int b = 5;
            int expected = 15;

            Geometry g = new Geometry();
            int actual = g.CalculateArea(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RectangleAreInvalidDataTest1()
        {
            bool catched = false;
            try
            {
                int a = -4;
                int b = 10;

                Geometry g = new Geometry();
                g.CalculateArea(a, b);
            }
            catch (ArgumentException ex)
            {
                catched = true;
            }
            Assert.IsTrue(catched, "не обработаны недопустимые данные");
        }
        [TestMethod]
        public void RectangleAreInvalidDataTest2()
        {
            int a = -4;
            int b = 10;

            Geometry g = new Geometry();
            Assert.ThrowsException<ArgumentException>(() => g.CalculateArea(a, b), "не обработаны отрицательные длины сторон прямоугольника");
        }
    }
}
