using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace Problem502.UnitTests
{
	[TestClass]
	public class ProgramTest
	{
		/*[TestMethod]
		public void Solve1_1()
		{
			EvenOdd result = Program.Solve(1, 1);
#if MODULUS
			Assert.AreEqual<ulong>(0, result.Even);
			Assert.AreEqual<ulong>(1, result.Odd);
#else
			Assert.AreEqual<BigInteger>(0, result.Even);
			Assert.AreEqual<BigInteger>(1, result.Odd);
#endif
		}
		
		[TestMethod]
		public void SubSolve1_1()
		{
			EvenOdd result = Program.SubSolve(1, 1);
#if MODULUS
			Assert.AreEqual<ulong>(1, result.Even);
			Assert.AreEqual<ulong>(1, result.Odd);
#else
			Assert.AreEqual<BigInteger>(1, result.Even);
			Assert.AreEqual<BigInteger>(1, result.Odd);
#endif
		}

		[TestMethod]
		public void Solve1_2()
		{
			EvenOdd result = Program.Solve(1, 2);
#if MODULUS
			Assert.AreEqual<ulong>(1, result.Even);
			Assert.AreEqual<ulong>(1, result.Odd);
#else
			Assert.AreEqual<BigInteger>(1, result.Even);
			Assert.AreEqual<BigInteger>(1, result.Odd);
#endif
		}
		
		[TestMethod]
		public void SubSolve1_2()
		{
			EvenOdd result = Program.SubSolve(1, 2);
#if MODULUS
			Assert.AreEqual<ulong>(2, result.Even);
			Assert.AreEqual<ulong>(1, result.Odd);
#else
			Assert.AreEqual<BigInteger>(2, result.Even);
			Assert.AreEqual<BigInteger>(1, result.Odd);
#endif
		}

		[TestMethod]
		public void SubSolve1_3()
		{
			EvenOdd result = Program.SubSolve(1, 3);
#if MODULUS
			Assert.AreEqual<ulong>(2, result.Even);
			Assert.AreEqual<ulong>(2, result.Odd);
#else
			Assert.AreEqual<BigInteger>(2, result.Even);
			Assert.AreEqual<BigInteger>(2, result.Odd);
#endif
		}

		[TestMethod]
		public void SubSolve2_1()
		{
			EvenOdd result = Program.SubSolve(2, 1);
#if MODULUS
			Assert.AreEqual<ulong>(1, result.Even);
			Assert.AreEqual<ulong>(3, result.Odd);
#else
			Assert.AreEqual<BigInteger>(1, result.Even);
			Assert.AreEqual<BigInteger>(3, result.Odd);
#endif
		}

		[TestMethod]
		public void SubSolve2_2()
		{
			EvenOdd result = Program.SubSolve(2, 2);
#if MODULUS
			Assert.AreEqual<ulong>(6, result.Even);
			Assert.AreEqual<ulong>(3, result.Odd);
#else
			Assert.AreEqual<BigInteger>(6, result.Even);
			Assert.AreEqual<BigInteger>(3, result.Odd);
#endif
		}
		
		[TestMethod]
		public void SubSolve4_1()
		{
			EvenOdd result = Program.SubSolve(4, 1);
#if MODULUS
			Assert.AreEqual<ulong>(6, result.Even);
			Assert.AreEqual<ulong>(10, result.Odd);
#else
			Assert.AreEqual<BigInteger>(6, result.Even);
			Assert.AreEqual<BigInteger>(10, result.Odd);
#endif
		}
		
		[TestMethod]
		public void Solve4_2()
		{
			EvenOdd result = Program.Solve(4, 2);
#if MODULUS
			Assert.AreEqual<ulong>(10, result.Even);
			Assert.AreEqual<ulong>(6, result.Odd);
#else
			Assert.AreEqual<BigInteger>(10, result.Even);
			Assert.AreEqual<BigInteger>(6, result.Odd);
#endif
		}
		
		[TestMethod]
		public void SubSolve4_2()
		{
			EvenOdd result = Program.SubSolve(4, 2);
#if MODULUS
			Assert.AreEqual<ulong>(50, result.Even);
			Assert.AreEqual<ulong>(31, result.Odd);
#else
			Assert.AreEqual<BigInteger>(50, result.Even);
			Assert.AreEqual<BigInteger>(31, result.Odd);
#endif
		}
		 * */
		/*
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
		*/
		[TestMethod]
		public void F4_2()
		{
			ModulusNumber result = Program.F(4, 2);
			Assert.AreEqual<ulong>(10, result.Value);
		}

		[TestMethod]
		public void F10_3()
		{
			ModulusNumber result = Program.F(10, 3);
			Assert.AreEqual<ulong>(28479, result.Value);
		}

		[TestMethod]
		public void F13_10()
		{
			ModulusNumber result = Program.F(13, 10);
			Assert.AreEqual<ulong>(3729050610636 % ModulusNumber.Mod, result.Value);
		}

		[TestMethod]
		public void F10_13()
		{
			ModulusNumber result = Program.F(10, 13);
			Assert.AreEqual<ulong>(37959702514 % ModulusNumber.Mod, result.Value);
		}

		[TestMethod]
		public void F100_100()
		{
			ModulusNumber result = Program.F(100, 100);
			Assert.AreEqual<ulong>(841913936, result.Value);
		}

		[TestMethod]
		public void F10e12_100()
		{
			ModulusNumber result = Program.F(BigInteger.Pow(10, 12), 100);
			Assert.AreEqual<ulong>(364553235, result.Value);
		}

		[TestMethod]
		public void F100_10e12()
		{
			ModulusNumber result = Program.F(100, BigInteger.Pow(10, 12));
			Assert.AreEqual<ulong>(635147632, result.Value);
		}
	}
}
