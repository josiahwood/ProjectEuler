using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	struct Request
	{
		public BigInteger Width;
		public BigInteger Height;
	}
	
	public struct Result
	{
		public BigInteger MaxHeightOdd;
		public BigInteger MaxHeightEven;
		public BigInteger NotMaxHeightOdd;
		public BigInteger NotMaxHeightEven;

		public static Result operator +(Result left, Result right)
		{
			Result result;
			result.MaxHeightEven = left.MaxHeightEven + right.MaxHeightEven;
			result.MaxHeightOdd = left.MaxHeightOdd + right.MaxHeightOdd;
			result.NotMaxHeightEven = left.NotMaxHeightEven + right.NotMaxHeightEven;
			result.NotMaxHeightOdd = left.NotMaxHeightOdd + right.NotMaxHeightOdd;
			return result;
		}

		public static Result operator *(Result left, Result right)
		{
			Result result = new Result();

			result.MaxHeightEven += left.MaxHeightEven * right.MaxHeightEven;
			result.MaxHeightOdd += left.MaxHeightEven * right.MaxHeightOdd;
			result.MaxHeightEven += left.MaxHeightEven * right.NotMaxHeightEven;
			result.MaxHeightOdd += left.MaxHeightEven * right.NotMaxHeightOdd;

			result.MaxHeightOdd += left.MaxHeightOdd * right.MaxHeightEven;
			result.MaxHeightEven += left.MaxHeightOdd * right.MaxHeightOdd;
			result.MaxHeightOdd += left.MaxHeightOdd * right.NotMaxHeightEven;
			result.MaxHeightEven += left.MaxHeightOdd * right.NotMaxHeightOdd;

			result.MaxHeightEven += left.NotMaxHeightEven * right.MaxHeightEven;
			result.MaxHeightOdd += left.NotMaxHeightEven * right.MaxHeightOdd;
			result.NotMaxHeightEven += left.NotMaxHeightEven * right.NotMaxHeightEven;
			result.NotMaxHeightOdd += left.NotMaxHeightEven * right.NotMaxHeightOdd;

			result.MaxHeightOdd += left.NotMaxHeightOdd * right.MaxHeightEven;
			result.MaxHeightEven += left.NotMaxHeightOdd * right.MaxHeightOdd;
			result.NotMaxHeightOdd += left.NotMaxHeightOdd * right.NotMaxHeightEven;
			result.NotMaxHeightEven += left.NotMaxHeightOdd * right.NotMaxHeightOdd;

			return result;
		}
	}
	
	public class Program
	{
		static Dictionary<Request, Result> _withBaseResults = new Dictionary<Request, Result>();
		static Dictionary<Request, Result> _withoutBaseResults = new Dictionary<Request, Result>();
		
		static void Main(string[] args)
		{
			Result result = WithBase(4, 2);
			Console.WriteLine(result.MaxHeightEven);

			result = WithBase(13, 10);
			Console.WriteLine(result.MaxHeightEven);
			
			Console.Read();
		}

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
				result.MaxHeightEven = 1 - h % 2;
				result.MaxHeightOdd = h % 2;
				result.NotMaxHeightEven = (h + 1) / 2 - 1;
				result.NotMaxHeightOdd = h / 2;

				return result;
			}
			
			Request request = new Request();
			request.Width = w;
			request.Height = h;
			
			if (_withBaseResults.TryGetValue(request, out result))
			{
				return result;
			}

			Result subResult = WithoutBase(w, h - 1);

			result.MaxHeightEven = subResult.MaxHeightOdd;
			result.MaxHeightOdd = subResult.MaxHeightEven;
			result.NotMaxHeightEven = subResult.NotMaxHeightOdd;
			result.NotMaxHeightOdd = subResult.NotMaxHeightEven;

			_withBaseResults.Add(request, result);
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
				result.MaxHeightEven = 1 - h % 2;
				result.MaxHeightOdd = h % 2;
				result.NotMaxHeightEven = (h + 1) / 2;
				result.NotMaxHeightOdd = h / 2;

				return result;
			}
			
			Request request = new Request();
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

		/// <summary>
		/// Choose k from n
		/// </summary>
		/// <param name="n"></param>
		/// <param name="k"></param>
		/// <returns></returns>
		static BigInteger PascalsTriangle(BigInteger n, BigInteger k)
		{
			return Factorial(n) / (Factorial(k) * (Factorial(n - k)));
		}

		static BigInteger Factorial(BigInteger n)
		{
			BigInteger a = 1;

			for (BigInteger i = 2; i <= n; i++)
			{
				a *= i;
			}

			return a;
		}
	}
}
