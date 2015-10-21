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
		public ulong MaxHeightOdd;
		public ulong MaxHeightEven;
		public ulong NotMaxHeightOdd;
		public ulong NotMaxHeightEven;
#else
		public BigInteger Even;
		public BigInteger Odd;
#endif

		public Result(BigInteger even, BigInteger odd)
		{
			Even = even;
			Odd = odd;
		}

		public static Result operator +(Result left, Result right)
		{
			Result result;
			result.Even = Program.Add(left.Even, right.Even);
			result.Odd = Program.Add(left.Odd, right.Odd);
			return result;
		}

		public static Result operator *(Result left, Result right)
		{
			Result result = new Result();

			result.Even += Program.Multiply(left.Even, right.Even);
			result.Odd += Program.Multiply(left.Even, right.Odd);
			result.Odd += Program.Multiply(left.Odd, right.Even);
			result.Even += Program.Multiply(left.Odd, right.Odd);

			return result;
		}

		public Result Swap
		{
			get
			{
				return new Result(Odd, Even);
			}
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
			Help();
			
			//BigInteger result0 = F(BigInteger.Pow(10, 12), 100);
			//Console.WriteLine(result0.MaxHeightEven);

			BigInteger result1 = F(10000, 10000);
			Console.WriteLine(result1);
			
			Console.Read();
		}

		static void Help()
		{
			const int size = 10;
			Matrix<double> a = CreateMatrix.Dense<double>(size, size);
			Matrix<double> b = CreateMatrix.Dense<double>(size, 1);

			for (int i = 0; i < size; i++)
			{
				long x = i + 1;
				Result result = Solve(8, x * 2);
				long y = (long)(result.Even - result.Odd);

				long xe = 1;

				for (int j = 0; j < size; j++)
				{
					a[i, j] = xe;
					xe *= x;
				}

				b[i, 0] = y;
			}

			Matrix<double> c = a.Inverse() * b;
			double[] coefficients = c.Column(0).ToArray();
			return;
		}

#if MODULUS
		public static ulong F(BigInteger w, BigInteger h)
#else
		public static BigInteger F(BigInteger w, BigInteger h)
#endif
		{
			Result result0 = Solve(w, h);
			Result result1 = Solve(w, h - 1);

			return result0.Even - result1.Even;
		}

		public static Result Solve(BigInteger w, BigInteger h)
		{
			return SubSolve(w, h - 1).Swap;
		}

		public static Result SubSolve(BigInteger w, BigInteger h)
		{
			if (w <= 0 || h == 0)
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

			result = SubSolve(w - 1, h);

			for (BigInteger i = 1; i <= w; i++)
			{
				Result subResult0 = SubSolve(i, h - 1).Swap;
				Result subResult1 = SubSolve(w - i - 1, h);
				Result total = subResult0 * subResult1;
				result += total;
			}

			_results.Add(request, result);
			return result;
		}
	}
}
