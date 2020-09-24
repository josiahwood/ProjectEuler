using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem3;

namespace Problem3.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, Program.LargestPrimeFactor(2));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(3, Program.LargestPrimeFactor(3));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(2, Program.LargestPrimeFactor(4));
        }

        [TestMethod]
        public void Test6()
        {
            Assert.AreEqual(3, Program.LargestPrimeFactor(6));
        }

        [TestMethod]
        public void Test12()
        {
            Assert.AreEqual(3, Program.LargestPrimeFactor(12));
        }

        [TestMethod]
        public void Test600851475143()
        {
            Assert.AreEqual(6857, Program.LargestPrimeFactor(600851475143));
        }
    }
}
