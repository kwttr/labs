using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class YearTests
    {
        [TestMethod]
        public void DetermineLeapYearTest()
        {
            Assert.AreEqual(DateTime.IsLeapYear(2022),Year.DetermineLeapYear(2022)==366);
            Assert.AreEqual(DateTime.IsLeapYear(2020), Year.DetermineLeapYear(2020)==366);
            Assert.AreEqual(DateTime.IsLeapYear(300), Year.DetermineLeapYear(300)== 366);
            Assert.AreEqual(DateTime.IsLeapYear(1200), Year.DetermineLeapYear(1200)== 366);
            Assert.AreEqual(DateTime.IsLeapYear(4), Year.DetermineLeapYear(4)==366);
        }
        [TestMethod]
        public void BelowZero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Year.DetermineLeapYear(0), "Отрицательный год");

        }
    }
}
