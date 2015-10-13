using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem502.UnitTests
{
	[TestClass]
	public class ProgramTest
	{
		[TestMethod]
		public void TestWithBase4_2()
		{
			Result result = Program.WithBase(4, 2);
			Assert.AreEqual(10, result.MaxHeightEven);
			Assert.AreEqual(5, result.MaxHeightOdd);
			Assert.AreEqual(0, result.NotMaxHeightEven);
			Assert.AreEqual(1, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void TestWithoutBase4_2()
		{
			Result result = Program.WithoutBase(4, 2);
			Assert.AreEqual(44, result.MaxHeightEven);
			Assert.AreEqual(21, result.MaxHeightOdd);
			Assert.AreEqual(6, result.NotMaxHeightEven);
			Assert.AreEqual(10, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void TestWithBase13_10()
		{
			Result result = Program.WithBase(13, 10);
			Assert.AreEqual(3729050610636, result.MaxHeightEven);
		}

		[TestMethod]
		public void TestWithBase10_13()
		{
			Result result = Program.WithBase(10, 13);
			Assert.AreEqual(37959702514, result.MaxHeightEven);
		}
	}
}
