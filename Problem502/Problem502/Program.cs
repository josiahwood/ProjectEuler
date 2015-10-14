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
	struct Request : IComparable<Request>
	{
		public BigInteger Width;
		public BigInteger Height;

		public int CompareTo(Request other)
		{
			int c = Width.CompareTo(other.Width);

			if (c == 0)
			{
				return Height.CompareTo(other.Height);
			}
			else
			{
				return c;
			}
		}
	}
	
	public struct Result
	{
#if MODULUS
		public ulong MaxHeightOdd;
		public ulong MaxHeightEven;
		public ulong NotMaxHeightOdd;
		public ulong NotMaxHeightEven;
#else
		public BigInteger MaxHeightOdd;
		public BigInteger MaxHeightEven;
		public BigInteger NotMaxHeightOdd;
		public BigInteger NotMaxHeightEven;
#endif

		public static Result operator +(Result left, Result right)
		{
			Result result;
			result.MaxHeightEven = Program.Add(left.MaxHeightEven, right.MaxHeightEven);
			result.MaxHeightOdd = Program.Add(left.MaxHeightOdd, right.MaxHeightOdd);
			result.NotMaxHeightEven = Program.Add(left.NotMaxHeightEven, right.NotMaxHeightEven);
			result.NotMaxHeightOdd = Program.Add(left.NotMaxHeightOdd, right.NotMaxHeightOdd);
			return result;
		}

		public static Result operator *(Result left, Result right)
		{
			Result result = new Result();

			result.MaxHeightEven += Program.Multiply(left.MaxHeightEven, right.MaxHeightEven);
			result.MaxHeightOdd += Program.Multiply(left.MaxHeightEven, right.MaxHeightOdd);
			result.MaxHeightEven += Program.Multiply(left.MaxHeightEven, right.NotMaxHeightEven);
			result.MaxHeightOdd += Program.Multiply(left.MaxHeightEven, right.NotMaxHeightOdd);

			result.MaxHeightOdd += Program.Multiply(left.MaxHeightOdd, right.MaxHeightEven);
			result.MaxHeightEven += Program.Multiply(left.MaxHeightOdd, right.MaxHeightOdd);
			result.MaxHeightOdd += Program.Multiply(left.MaxHeightOdd, right.NotMaxHeightEven);
			result.MaxHeightEven += Program.Multiply(left.MaxHeightOdd, right.NotMaxHeightOdd);

			result.MaxHeightEven += Program.Multiply(left.NotMaxHeightEven, right.MaxHeightEven);
			result.MaxHeightOdd += Program.Multiply(left.NotMaxHeightEven, right.MaxHeightOdd);
			result.NotMaxHeightEven += Program.Multiply(left.NotMaxHeightEven, right.NotMaxHeightEven);
			result.NotMaxHeightOdd += Program.Multiply(left.NotMaxHeightEven, right.NotMaxHeightOdd);

			result.MaxHeightOdd += Program.Multiply(left.NotMaxHeightOdd, right.MaxHeightEven);
			result.MaxHeightEven += Program.Multiply(left.NotMaxHeightOdd, right.MaxHeightOdd);
			result.NotMaxHeightOdd += Program.Multiply(left.NotMaxHeightOdd, right.NotMaxHeightEven);
			result.NotMaxHeightEven += Program.Multiply(left.NotMaxHeightOdd, right.NotMaxHeightOdd);

			return result;
		}
	}

	public class Program
	{
		static SplayTree<Request, Result> _withoutBaseResults = new SplayTree<Request, Result>();

#if MODULUS
		public const ulong Mod = 1000000007;

		public static ulong Add(ulong a, ulong b)
		{
			return (a + b) % Mod;
		}

		public static long Add(long a, long b)
		{
			return (a + b) % (long)Mod;
		}
		
		public static ulong Multiply(ulong a, ulong b)
		{
			return (a * b) % Mod;
		}

		public static long Multiply(long a, long b)
		{
			return (a * b) % (long)Mod;
		}
#else
		public static BigInteger Add(BigInteger a, BigInteger b)
		{
			return a + b;
		}

		public static BigInteger Multiply(BigInteger a, BigInteger b)
		{
			return a * b;
		}
#endif
		
		[STAThread]
		static void Main(string[] args)
		{
			//Result result0 = WithBase(BigInteger.Pow(10, 12), 100);
			//Console.WriteLine(result0.MaxHeightEven);

			double[] coefficients = Coefficients();

			//StringBuilder s = new StringBuilder();

			//for (int w = 1; w <= 10; w++)
			//{
			//	for (int h = 1; h <= 10; h++)
			//	{
			//		Result result = WithBase(w, h);
			//		BigInteger a = 0;
			//		//a += result.MaxHeightEven;
			//		//a += result.MaxHeightOdd;
			//		a += result.NotMaxHeightEven;
			//		a += result.NotMaxHeightOdd;
			//		s.Append(a + "\t");
			//	}

			//	s.AppendLine();
			//}

			//Clipboard.SetText(s.ToString());

			//Result result1 = WithBase(10000, 10000);
			//Console.WriteLine(result1.MaxHeightEven);
			
			Console.Read();
		}

		public static ulong F(BigInteger w, BigInteger h)
		{
			// Total(w, h) = h ^ w
			// NotMaxHeight(w, h) = (h - 1) ^ w
			// MaxHeight(w, h) = Total(w, h) - NotMaxHeight(w, h)
			// Odd(w, h) = 2 ^ (w - 1) * (h / 2) ^ w - (w - 1) * (h / 2) ^ (w - 1)
			// Odd(w, h) = (h ^ w) / 2 - (w - 1) * (h / 2) ^ (w - 1)
			// Odd(w, h) = Total(w, h) / 2 - (w - 1) * (h / 2) ^ (w - 1)
			// Even(w, h) = Total(w, h) / 2 + (w - 1) * (h / 2) ^ (w - 1)
			// Even(w, h) = (h ^ w) / 2 + (w - 1) * (h / 2) ^ (w - 1)
			// NotMaxHeightEven(w, h) = ((h - 1) ^ w) / 2 + (w - 1) * (h / 2) ^ (w - 1)

			return 0;
		}

		static double[] Coefficients()
		{
			const int size = 10;
			Matrix<double> a = CreateMatrix.Dense<double>(size, size);
			Matrix<double> b = CreateMatrix.Dense<double>(size, 1);
			
			for (int i = 0; i < size; i++)
			{
				long x = i + 1;
				Result result = WithBase(8, x * 2);
				long y = (long)(result.MaxHeightOdd + result.NotMaxHeightOdd);

				long xe = 1;

				for (int j = 0; j < size; j++)
				{
					a[i, j] = xe;
					xe *= x;
				}

				b[i, 0] = y;
			}

			Matrix<double> c = a.Inverse() * b;
			return c.Column(0).ToArray();
		}

		//static bool Evaluate(long[] coefficients)
		//{
		//	int maxE = (int)Math.Sqrt(coefficients.Length);
			
		//	for (int w = 10; w <= 100; w++)
		//	{
		//		for (int h = 10; h <= 100; h++)
		//		{
		//			Result result = WithBase(w, h);
		//			ulong expected = result.MaxHeightEven;
		//			long actual = 0;
		//			ulong wc = 1;

		//			for (int we = 0; we < maxE; we++)
		//			{
		//				ulong hc = 1;

		//				for (int he = 0; he < maxE; he++)
		//				{
		//					actual += ModMultiply(coefficients[we * maxE + he], (long)ModMultiply(wc, hc));

		//					hc *= (ulong)h;
		//				}

		//				wc *= (ulong)w;
		//			}

		//			if (actual != (long)expected)
		//			{
		//				return false;
		//			}
		//		}
		//	}

		//	return true;
		//}

		public static Result WithBase(BigInteger w, BigInteger h)
		{
			Result result;
			
			if (w == 0)
			{
				result.MaxHeightEven = 0;
				result.MaxHeightOdd = 0;
				result.NotMaxHeightEven = 1;
				result.NotMaxHeightOdd = 0;
				
				return result;
			}
			else if (h == 1)
			{
				result.MaxHeightEven = 0;
				result.MaxHeightOdd = 1;
				result.NotMaxHeightEven = 0;
				result.NotMaxHeightOdd = 0;

				return result;
			}
			else if (w == 1)
			{
#if MODULUS
				result.MaxHeightEven = (ulong)(1 - h % 2);
				result.MaxHeightOdd = (ulong)(h % 2);
				result.NotMaxHeightEven = (ulong)((((h + 1) >> 1) - 1) % Mod);
				result.NotMaxHeightOdd = (ulong)((h >> 1) % Mod);
#else
				result.MaxHeightEven = 1 - h % 2;
				result.MaxHeightOdd = h % 2;
				result.NotMaxHeightEven = ((h + 1) >> 1) - 1;
				result.NotMaxHeightOdd = h >> 1;
#endif

				return result;
			}
			
			Result subResult = WithoutBase(w, h - 1);

			result.MaxHeightEven = subResult.MaxHeightOdd;
			result.MaxHeightOdd = subResult.MaxHeightEven;
			result.NotMaxHeightEven = subResult.NotMaxHeightOdd;
			result.NotMaxHeightOdd = subResult.NotMaxHeightEven;

			return result;
		}

		public static Result WithoutBase(BigInteger w, BigInteger h)
		{
			Result result;
			
			if (w == 0)
			{
				result.MaxHeightEven = 0;
				result.MaxHeightOdd = 0;
				result.NotMaxHeightEven = 1;
				result.NotMaxHeightOdd = 0;

				return result;
			}
			else if (w == 1)
			{
#if MODULUS
				result.MaxHeightEven = (ulong)(1 - h % 2);
				result.MaxHeightOdd = (ulong)(h % 2);
				result.NotMaxHeightEven = (ulong)(((h + 1) >> 1) % Mod);
				result.NotMaxHeightOdd = (ulong)((h >> 1) % Mod);
#else
				result.MaxHeightEven = 1 - h % 2;
				result.MaxHeightOdd = h % 2;
				result.NotMaxHeightEven = (h + 1) >> 1;
				result.NotMaxHeightOdd = h >> 1;
#endif

				return result;
			}
			
			Request request;
			request.Width = w;
			request.Height = h;

			if (_withoutBaseResults.TryGetValue(request, out result))
			{
				return result;
			}
			
			result = WithBase(w, h);

			for (BigInteger i = 0; i < w; i++)
			{
				Result withResult = WithBase(i, h);
				Result withoutResult = WithoutBase(w - i - 1, h);
				Result total = withResult * withoutResult;
				result += total;
			}

			_withoutBaseResults.Add(request, result);
			return result;
		}
	}
}
