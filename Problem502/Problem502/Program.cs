using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Problem502
{
	public class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			//BigInteger result0 = F(BigInteger.Pow(10, 12), 100);
			//Console.WriteLine(result0.MaxHeightEven);

			//BigInteger result1 = F(10000, 10000);
			//Console.WriteLine(result1);

			ModulusNumber result;

			//result = WidthBound(10, 13);
			//Console.WriteLine(result);

			//result = WidthBound(100, 100);
			//Console.WriteLine(result);

			//result = WidthBound(10000, 10000);
			//Console.WriteLine(result);

#if MODULUS
			result = F(100, BigInteger.Pow(10, 12));
			Console.WriteLine(result);
#endif

			Console.Read();
		}

		//static void Help()
		//{
		//	int h = 4;

		//	for (int w = 2; w <= 20; w++)
		//	{
		//		BigInteger n = Solve(w, h).Even - Solve(w, h - 1).Even;
		//		BigInteger d = Solve(w - 1, h).Even - Solve(w - 1, h - 1).Even;
		//		RationalNumber r = new RationalNumber(n, d);
		//		RationalNumber r2 = r - new RationalNumber(h, 1);

		//		Console.Write(n);
		//		Console.Write(" -> ");
		//		Console.Write(r);
		//		Console.Write(" = {0} + ", h);
		//		Console.WriteLine(r2);
		//	}

		//	int matrixSize = 11;

		//	for (int i = 1; i <= 10; i++)
		//	{
		//		Console.WriteLine("Width = {0}", i);
		//		Console.WriteLine("  Odd Heights");
		//		Console.Write("    ");
		//		HelpIteration(matrixSize, i, false);
		//		Console.WriteLine("  Even Heights");
		//		Console.Write("    ");
		//		HelpIteration(matrixSize, i, true);
		//	}

		//	//HelpIteration(101, 100, true);

		//	return;
		//}

		//static void HelpIteration(int matrixSize, BigInteger width, bool evenHeights)
		//{
		//	RationalMatrix a = new RationalMatrix(matrixSize, matrixSize);
		//	RationalMatrix b = new RationalMatrix(matrixSize, 1);

		//	for (int i = 0; i < matrixSize; i++)
		//	{
		//		long x = (i + 2) * 2;

		//		if (!evenHeights)
		//		{
		//			x--;
		//		}

		//		EvenOdd result0 = Solve(width, x);
		//		EvenOdd result1 = Solve(width, x - 1);
		//		ModulusNumber y = result0.Even - result1.Even;

		//		BigInteger xe = 1;

		//		for (int j = 0; j < matrixSize; j++)
		//		{
		//			a[i, j] = new RationalNumber(xe, 1);
		//			xe *= x;
		//		}

		//		b[i, 0] = new RationalNumber(y, 1);
		//	}

		//	RationalMatrix c = RationalMatrix.GaussianElimination(a, b);
		//	RationalNumber[] coefficients = c.Column(0);

		//	bool printed = false;

		//	for (int i = matrixSize - 1; i >= 0; i--)
		//	{
		//		if (coefficients[i] > RationalNumber.Zero)
		//		{
		//			if (printed && coefficients[i] > RationalNumber.Zero)
		//			{
		//				Console.Write("+");
		//			}

		//			printed = true;
		//		}

		//		if (coefficients[i] != RationalNumber.Zero)
		//		{
		//			Console.Write(coefficients[i]);

		//			if (i == 0)
		//			{

		//			}
		//			else if (i == 1)
		//			{
		//				Console.Write("*h");
		//			}
		//			else
		//			{
		//				Console.Write("*h^");
		//				Console.Write(i);
		//			}
		//		}
		//	}

		//	Console.WriteLine();
		//}

#if MODULUS
		public static ModulusNumber F(BigInteger w, BigInteger h)
#else
		public static BigInteger F(BigInteger w, BigInteger h)
#endif
		{
#if MODULUS
			//if (w < h)
			//{
				return WidthBound((int)w, h);
			//}
			//else
			//{
#endif
				//Result result0 = Solve(w, h);
				//Result result1 = Solve(w, h - 1);

				//return result0.Even - result1.Even;
				//return ModulusNumber.Zero;

#if MODULUS
			//}
#endif
		}

#if MODULUS

		public static ModulusNumber WidthBound(int w, BigInteger h)
		{
			if (w == 0 || h == 0)
			{
				return ModulusNumber.One;
			}

			EvenOdd[] previous = new EvenOdd[w];
			EvenOdd[] current = new EvenOdd[w];

			for (int i = 0; i < w; i++)
			{
				current[i] = EvenOdd.OneEven;
			}

			for (BigInteger i = 1; i < h; i++)
			{
				EvenOdd[] temp = previous;
				previous = current;
				current = temp;

				for (int j = 1; j <= w; j++)
				{
					EvenOdd result = Get(current, j - 1) + Get(previous, j).Swap;

					for (int k = 1; k < j; k++)
					{
						EvenOdd subResult0 = Get(previous, k).Swap;
						EvenOdd subResult1 = Get(current, j - k - 1);
						EvenOdd total = subResult0 * subResult1;
						result += total;
					}

					Set(current, j, result);
				}
			}

			return new ModulusNumber((ulong)(current[w - 1].Odd - previous[w - 1].Odd));
		}

		static void Set(EvenOdd[] values, int w, EvenOdd value)
		{
			values[w - 1] = value;
		}

		static EvenOdd Get(EvenOdd[] values, int w)
		{
			if (w == 0)
			{
				return EvenOdd.OneEven;
			}

			return values[w - 1];
		}

#endif
	}
}