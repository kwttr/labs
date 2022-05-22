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
            Alphabet a = new Alphabet();
            string actual = a.PrintAlphabet(N);
            string expected = "ABCDEFGHIJKLMNO";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AlphabitAreInvalidTest()
        {
            int N = -2;
            Alphabet a = new Alphabet();
            Assert.ThrowsException<ArgumentException>(() => a.PrintAlphabet(N), "не обработан запрос вне диапазона");
        }
    }
}
