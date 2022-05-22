using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class MailTests
    {
        [TestMethod]
        public void CheckMailTest()
        {
            bool actual = new Mail().CheckMail("hello@world.ru");
            Assert.IsTrue(actual);
        }
        //todo: тесты падают

        [TestMethod]
        public void CheckInvalidMailTest1()
        {
            Mail actual = new Mail();
            Assert.IsFalse(actual.CheckMail("absssssssssssss"));
        }
        [TestMethod]
        public void CheckInvalidMailTest2()
        {
            Mail actual = new Mail();
            Assert.ThrowsException<ArgumentNullException>(() => actual.CheckMail(null), "пустая строка");

            Assert.IsFalse(actual.CheckMail(String.Empty));
        }
        //todo: проверить случаи null строки и пустой строки
    }
}
