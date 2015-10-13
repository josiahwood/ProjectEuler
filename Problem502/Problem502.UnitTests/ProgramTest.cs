using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace Problem502.UnitTests
{
	[TestClass]
	public class ProgramTest
	{
		[TestMethod]
		public void WithBase1_1()
		{
			Result result = Program.WithBase(1, 1);
			Assert.AreEqual(0, result.MaxHeightEven);
			Assert.AreEqual(1, result.MaxHeightOdd);
			Assert.AreEqual(0, result.NotMaxHeightEven);
			Assert.AreEqual(0, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithoutBase1_1()
		{
			Result result = Program.WithoutBase(1, 1);
			Assert.AreEqual(0, result.MaxHeightEven);
			Assert.AreEqual(1, result.MaxHeightOdd);
			Assert.AreEqual(1, result.NotMaxHeightEven);
			Assert.AreEqual(0, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithBase1_2()
		{
			Result result = Program.WithBase(1, 2);
			Assert.AreEqual(1, result.MaxHeightEven);
			Assert.AreEqual(0, result.MaxHeightOdd);
			Assert.AreEqual(0, result.NotMaxHeightEven);
			Assert.AreEqual(1, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithoutBase1_2()
		{
			Result result = Program.WithoutBase(1, 2);
			Assert.AreEqual(1, result.MaxHeightEven);
			Assert.AreEqual(0, result.MaxHeightOdd);
			Assert.AreEqual(1, result.NotMaxHeightEven);
			Assert.AreEqual(1, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase1_3()
		{
			Result result = Program.WithoutBase(1, 3);
			Assert.AreEqual(0, result.MaxHeightEven);
			Assert.AreEqual(1, result.MaxHeightOdd);
			Assert.AreEqual(2, result.NotMaxHeightEven);
			Assert.AreEqual(1, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase2_1()
		{
			Result result = Program.WithoutBase(2, 1);
			Assert.AreEqual(0, result.MaxHeightEven);
			Assert.AreEqual(3, result.MaxHeightOdd);
			Assert.AreEqual(1, result.NotMaxHeightEven);
			Assert.AreEqual(0, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase2_2()
		{
			Result result = Program.WithoutBase(2, 2);
			Assert.AreEqual(5, result.MaxHeightEven);
			Assert.AreEqual(0, result.MaxHeightOdd);
			Assert.AreEqual(1, result.NotMaxHeightEven);
			Assert.AreEqual(3, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithoutBase4_1()
		{
			Result result = Program.WithoutBase(4, 1);
			Assert.AreEqual(5, result.MaxHeightEven);
			Assert.AreEqual(10, result.MaxHeightOdd);
			Assert.AreEqual(1, result.NotMaxHeightEven);
			Assert.AreEqual(0, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithBase4_2()
		{
			Result result = Program.WithBase(4, 2);
			Assert.AreEqual(10, result.MaxHeightEven);
			Assert.AreEqual(5, result.MaxHeightOdd);
			Assert.AreEqual(0, result.NotMaxHeightEven);
			Assert.AreEqual(1, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase4_2()
		{
			Result result = Program.WithoutBase(4, 2);
			Assert.AreEqual(44, result.MaxHeightEven);
			Assert.AreEqual(21, result.MaxHeightOdd);
			Assert.AreEqual(6, result.NotMaxHeightEven);
			Assert.AreEqual(10, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithBase4_3()
		{
			Result result = Program.WithBase(4, 3);
			Assert.AreEqual(21, result.MaxHeightEven);
			Assert.AreEqual(44, result.MaxHeightOdd);
			Assert.AreEqual(10, result.NotMaxHeightEven);
			Assert.AreEqual(6, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase4_3()
		{
			Result result = Program.WithoutBase(4, 3);
			// not verified
			Assert.AreEqual(58, result.MaxHeightEven);
			Assert.AreEqual(117, result.MaxHeightOdd);
			Assert.AreEqual(50, result.NotMaxHeightEven);
			Assert.AreEqual(31, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase5_1()
		{
			Result result = Program.WithoutBase(5, 1);
			Assert.AreEqual(15, result.MaxHeightEven);
			Assert.AreEqual(16, result.MaxHeightOdd);
			Assert.AreEqual(1, result.NotMaxHeightEven);
			Assert.AreEqual(0, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithoutBase5_2()
		{
			Result result = Program.WithoutBase(5, 2);
			// not verified
			Assert.AreEqual(122, result.MaxHeightEven);
			Assert.AreEqual(89, result.MaxHeightOdd);
			Assert.AreEqual(16, result.NotMaxHeightEven);
			Assert.AreEqual(16, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase6_1()
		{
			Result result = Program.WithoutBase(6, 1);
			Assert.AreEqual(35, result.MaxHeightEven);
			Assert.AreEqual(28, result.MaxHeightOdd);
			Assert.AreEqual(1, result.NotMaxHeightEven);
			Assert.AreEqual(0, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase7_1()
		{
			Result result = Program.WithoutBase(7, 1);
			Assert.AreEqual(71, result.MaxHeightEven);
			Assert.AreEqual(56, result.MaxHeightOdd);
			Assert.AreEqual(1, result.NotMaxHeightEven);
			Assert.AreEqual(0, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithBase13_10()
		{
			Result result = Program.WithBase(13, 10);
			Assert.AreEqual(3729050610636, result.MaxHeightEven);
		}

		[TestMethod]
		public void WithBase10_13()
		{
			Result result = Program.WithBase(10, 13);
			Assert.AreEqual(37959702514, result.MaxHeightEven);
		}

		[TestMethod]
		public void WithBase100_100()
		{
			Result result = Program.WithBase(100, 100);
			BigInteger actual = result.MaxHeightEven % 1000000007;
			Assert.AreEqual(841913936, actual);
		}
	}
}
