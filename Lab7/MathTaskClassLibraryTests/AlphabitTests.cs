using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class AlphabitTests
    {
        [TestMethod]
        public void AlphabitAreaTest()
        {
            int N = 15;
            Alphabit a = new Alphabit();
            string actual = a.AlphabitArea(N);
            string expected = "ABCDEFGHIJKLMNO";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AlphabitAreInvalidTest()
        {
            int N = -2;
            Alphabit a = new Alphabit();
            Assert.ThrowsException<ArgumentException>(() => a.AlphabitArea(N), "не обработан запрос вне диапазона");
        }
    }
}
