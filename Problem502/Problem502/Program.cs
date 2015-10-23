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
		public static readonly Result OneEven = new Result(1, 0);
		public static readonly Result OneOdd = new Result(0, 1);

#if MODULUS
		public ulong Even;
		public ulong Odd;
#else
		public BigInteger Even;
		public BigInteger Odd;
#endif

#if MODULUS
		public Result(ulong even, ulong odd)
		{
			Even = even;
			Odd = odd;
		}
#else
        public Result(BigInteger even, BigInteger odd)
		{
			Even = even;
			Odd = odd;
		}
#endif

		public static Result operator +(Result left, Result right)
		{
			Result result;
			result.Even = Program.Add(left.Even, right.Even);
			result.Odd = Program.Add(left.Odd, right.Odd);
			return result;
		}

		public static Result operator *(Result left, Result right)
		{
			Result result;
			result.Even = Program.Multiply(left.Even, right.Even) + Program.Multiply(left.Odd, right.Odd);
			result.Odd = Program.Multiply(left.Even, right.Odd) + Program.Multiply(left.Odd, right.Even);
			return result;
		}

		public Result Swap
		{
			get
			{
				return new Result(Odd, Even);
			}
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}", Even, Odd);
		}
	}

	public class Program
	{
		static SplayTree<Request, Result> _results = new SplayTree<Request, Result>();

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

		public static ulong Subtract(ulong a, ulong b)
		{
			return (Mod + (a % Mod) - (b % Mod)) % Mod;
		}

		public static long Subtract(long a, long b)
		{
			return ((long)Mod + (a % (long)Mod) - (b % (long)Mod)) % (long)Mod;
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

		public static BigInteger Subtract(BigInteger a, BigInteger b)
		{
			return a - b;
		}

		public static BigInteger Multiply(BigInteger a, BigInteger b)
		{
			return a * b;
		}
#endif

		[STAThread]
		static void Main(string[] args)
		{
			Help();

			//BigInteger result0 = F(BigInteger.Pow(10, 12), 100);
			//Console.WriteLine(result0.MaxHeightEven);

			//BigInteger result1 = F(10000, 10000);
			//Console.WriteLine(result1);

			ulong result;

			//result = WidthBound(10, 13);
			//Console.WriteLine(result);

			//result = WidthBound(100, 100);
			//Console.WriteLine(result);

			//result = WidthBound(10000, 10000);
			//Console.WriteLine(result);

			Console.Read();
		}

		static void Help()
		{
			int matrixSize = 11;

			for (int i = 1; i <= 10; i++)
			{
				Console.WriteLine("Width = {0}", i);
				Console.WriteLine("  Odd Heights");
				Console.Write("    ");
				HelpIteration(matrixSize, i, false);
				Console.WriteLine("  Even Heights");
				Console.Write("    ");
				HelpIteration(matrixSize, i, true);
			}
			return;
		}

		static void HelpIteration(int matrixSize, BigInteger width, bool evenHeights)
		{
			RationalMatrix a = new RationalMatrix(matrixSize, matrixSize);
			RationalMatrix b = new RationalMatrix(matrixSize, 1);

			for (int i = 0; i < matrixSize; i++)
			{
				long x = (i + 1) * 2;

				if (!evenHeights)
				{
					x--;
				}

				Result result = Solve(width, x);
				long y = (long)result.Odd;

				long xe = 1;

				for (int j = 0; j < matrixSize; j++)
				{
					a[i, j] = new RationalNumber(xe, 1);
					xe *= x;
				}

				b[i, 0] = new RationalNumber(y, 1);
			}

			RationalMatrix c = RationalMatrix.GaussianElimination(a, b);
			RationalNumber[] coefficients = c.Column(0);

			bool printed = false;

			for (int i = matrixSize - 1; i >= 0; i--)
			{
				if (coefficients[i] > RationalNumber.Zero)
				{
					if (printed && coefficients[i] > RationalNumber.Zero)
					{
						Console.Write("+");
					}

					printed = true;
				}

				if (coefficients[i] != RationalNumber.Zero)
				{
					Console.Write(coefficients[i]);

					if (i == 0)
					{

					}
					else if (i == 1)
					{
						Console.Write("*h");
					}
					else
					{
						Console.Write("*h^");
						Console.Write(i);
					}
				}
			}

			Console.WriteLine();
		}

#if MODULUS
		public static ulong F(BigInteger w, BigInteger h)
#else
		public static BigInteger F(BigInteger w, BigInteger h)
#endif
		{
#if MODULUS
			if (w < h)
			{
				return WidthBound((int)w, h);
			}
			else
			{
#endif
				Result result0 = Solve(w, h);
				Result result1 = Solve(w, h - 1);

				return Subtract(result0.Even, result1.Even);

#if MODULUS
			}
#endif
		}

		public static Result Solve(BigInteger w, BigInteger h)
		{
			return SubSolve(w, h - 1).Swap;
		}

		public static Result SubSolve(BigInteger w, BigInteger h)
		{
			if (w == 0 || h == 0)
			{
				return Result.OneEven;
			}

			Request request;
			request.Width = w;
			request.Height = h;

			Result result;

			if (_results.TryGetValue(request, out result))
			{
				return result;
			}

			result = SubSolve(w - 1, h) + SubSolve(w, h - 1).Swap;

			for (BigInteger i = 1; i < w; i++)
			{
				Result subResult0 = SubSolve(i, h - 1).Swap;
				Result subResult1 = SubSolve(w - i - 1, h);
				Result total = subResult0 * subResult1;
				result += total;
			}

			_results.Add(request, result);
			return result;
		}

#if MODULUS
		public static ulong WidthBound(int w, BigInteger h)
		{
			if (w == 0 || h == 0)
			{
				return 1;
			}

			Result[] previous = new Result[w];
			Result[] current = new Result[w];

			for (int i = 0; i < w; i++)
			{
				current[i] = Result.OneEven;
			}

			for (BigInteger i = 1; i < h; i++)
			{
				if (i % 10 == 0)
				{
					Console.WriteLine(i);
				}
				
				Result[] temp = previous;
				previous = current;
				current = temp;

				for (int j = 1; j <= w; j++)
				{
					Result result = Get(current, j - 1) + Get(previous, j).Swap;

					for (int k = 1; k < j; k++)
					{
						Result subResult0 = Get(previous, k).Swap;
						Result subResult1 = Get(current, j - k - 1);
						Result total = subResult0 * subResult1;
						result += total;
					}

					Set(current, j, result);
				}
			}

			return (Mod + (current[w - 1].Odd % Mod) - (previous[w - 1].Odd % Mod)) % Mod;
		}
#endif

		static void Set(Result[] values, int w, Result value)
		{
			values[w - 1] = value;
		}

		static Result Get(Result[] values, int w)
		{
			if (w == 0)
			{
				return Result.OneEven;
			}

			return values[w - 1];
		}
	}
}