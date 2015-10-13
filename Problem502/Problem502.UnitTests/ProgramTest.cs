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
			Assert.AreEqual<ulong>(0, result.MaxHeightEven);
			Assert.AreEqual<ulong>(1, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithoutBase1_1()
		{
			Result result = Program.WithoutBase(1, 1);
			Assert.AreEqual<ulong>(0, result.MaxHeightEven);
			Assert.AreEqual<ulong>(1, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithBase1_2()
		{
			Result result = Program.WithBase(1, 2);
			Assert.AreEqual<ulong>(1, result.MaxHeightEven);
			Assert.AreEqual<ulong>(0, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithoutBase1_2()
		{
			Result result = Program.WithoutBase(1, 2);
			Assert.AreEqual<ulong>(1, result.MaxHeightEven);
			Assert.AreEqual<ulong>(0, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase1_3()
		{
			Result result = Program.WithoutBase(1, 3);
			Assert.AreEqual<ulong>(0, result.MaxHeightEven);
			Assert.AreEqual<ulong>(1, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(2, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase2_1()
		{
			Result result = Program.WithoutBase(2, 1);
			Assert.AreEqual<ulong>(0, result.MaxHeightEven);
			Assert.AreEqual<ulong>(3, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase2_2()
		{
			Result result = Program.WithoutBase(2, 2);
			Assert.AreEqual<ulong>(5, result.MaxHeightEven);
			Assert.AreEqual<ulong>(0, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(3, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithoutBase4_1()
		{
			Result result = Program.WithoutBase(4, 1);
			Assert.AreEqual<ulong>(5, result.MaxHeightEven);
			Assert.AreEqual<ulong>(10, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithBase4_2()
		{
			Result result = Program.WithBase(4, 2);
			Assert.AreEqual<ulong>(10, result.MaxHeightEven);
			Assert.AreEqual<ulong>(5, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase4_2()
		{
			Result result = Program.WithoutBase(4, 2);
			Assert.AreEqual<ulong>(44, result.MaxHeightEven);
			Assert.AreEqual<ulong>(21, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(6, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(10, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithBase4_3()
		{
			Result result = Program.WithBase(4, 3);
			Assert.AreEqual<ulong>(21, result.MaxHeightEven);
			Assert.AreEqual<ulong>(44, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(10, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(6, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase4_3()
		{
			Result result = Program.WithoutBase(4, 3);
			// not verified
			Assert.AreEqual<ulong>(58, result.MaxHeightEven);
			Assert.AreEqual<ulong>(117, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(50, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(31, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase5_1()
		{
			Result result = Program.WithoutBase(5, 1);
			Assert.AreEqual<ulong>(15, result.MaxHeightEven);
			Assert.AreEqual<ulong>(16, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightOdd);
		}
		
		[TestMethod]
		public void WithoutBase5_2()
		{
			Result result = Program.WithoutBase(5, 2);
			// not verified
			Assert.AreEqual<ulong>(122, result.MaxHeightEven);
			Assert.AreEqual<ulong>(89, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(16, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(16, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase6_1()
		{
			Result result = Program.WithoutBase(6, 1);
			Assert.AreEqual<ulong>(35, result.MaxHeightEven);
			Assert.AreEqual<ulong>(28, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithoutBase7_1()
		{
			Result result = Program.WithoutBase(7, 1);
			Assert.AreEqual<ulong>(71, result.MaxHeightEven);
			Assert.AreEqual<ulong>(56, result.MaxHeightOdd);
			Assert.AreEqual<ulong>(1, result.NotMaxHeightEven);
			Assert.AreEqual<ulong>(0, result.NotMaxHeightOdd);
		}

		[TestMethod]
		public void WithBase13_10()
		{
			Result result = Program.WithBase(13, 10);
			Assert.AreEqual<ulong>(3729050610636 % Program.Mod, result.MaxHeightEven);
		}

		[TestMethod]
		public void WithBase10_13()
		{
			Result result = Program.WithBase(10, 13);
			Assert.AreEqual<ulong>(37959702514 % Program.Mod, result.MaxHeightEven);
		}

		[TestMethod]
		public void WithBase100_100()
		{
			Result result = Program.WithBase(100, 100);
			Assert.AreEqual<ulong>(841913936, result.MaxHeightEven);
		}
	}
}
