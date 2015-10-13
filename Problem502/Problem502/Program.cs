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
			
			Request request = new Request();
			request.Width = w;
			request.Height = h;
			
			if (_withBaseResults.TryGetValue(request, out result))
			{
				return result;
			}

			if (h == 2)
			{
				// Change to ModPow later
				BigInteger count = BigInteger.Pow(2, (int)w) - 1;
				
				BigInteger evenCount = 0;

				//optimize
				for (BigInteger i = 1; i <= w; i++)
				{
					evenCount += i;
				}
				
				BigInteger oddCount = count - evenCount;

				result.MaxHeightEven = evenCount;
				result.MaxHeightOdd = oddCount;
				result.NotMaxHeightEven = 0;
				result.NotMaxHeightOdd = 1;

				_withBaseResults.Add(request, result);
				return result;
			}
			else
			{
				Result subResult = WithoutBase(w, h - 1);

				result.MaxHeightEven = subResult.MaxHeightOdd;
				result.MaxHeightOdd = subResult.MaxHeightEven;
				result.NotMaxHeightEven = subResult.NotMaxHeightOdd;
				result.NotMaxHeightOdd = subResult.NotMaxHeightEven;

				_withBaseResults.Add(request, result);
				return result;
			}
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
			
			Request request = new Request();
			request.Width = w;
			request.Height = h;

			if (_withoutBaseResults.TryGetValue(request, out result))
			{
				return result;
			}
			
			if (h == 1)
			{
				// Change to ModPow later
				BigInteger count = BigInteger.Pow(2, (int)w) - 1;

				BigInteger oddCount = 0;

				//optimize
				for (BigInteger i = 1; i <= w; i++)
				{
					oddCount += i;
				}

				BigInteger evenCount = count - oddCount;

				result.MaxHeightEven = evenCount;
				result.MaxHeightOdd = oddCount;
				result.NotMaxHeightEven = 1;
				result.NotMaxHeightOdd = 0;

				_withoutBaseResults.Add(request, result);
				return result;
			}
			else
			{
				result = WithBase(w, h);

				for (BigInteger i = 0; i < w; i++)
				{
					Result withResult = WithBase(i, h);
					Result withoutResult = WithoutBase(w - i - 1, h);

					result.MaxHeightEven += withResult.MaxHeightEven * withoutResult.MaxHeightEven;
					result.MaxHeightOdd += withResult.MaxHeightEven * withoutResult.MaxHeightOdd;
					result.MaxHeightEven += withResult.MaxHeightEven * withoutResult.NotMaxHeightEven;
					result.MaxHeightOdd += withResult.MaxHeightEven * withoutResult.NotMaxHeightOdd;

					result.MaxHeightOdd += withResult.MaxHeightOdd * withoutResult.MaxHeightEven;
					result.MaxHeightEven += withResult.MaxHeightOdd * withoutResult.MaxHeightOdd;
					result.MaxHeightOdd += withResult.MaxHeightOdd * withoutResult.NotMaxHeightEven;
					result.MaxHeightEven += withResult.MaxHeightOdd * withoutResult.NotMaxHeightOdd;

					result.MaxHeightEven += withResult.NotMaxHeightEven * withoutResult.MaxHeightEven;
					result.MaxHeightOdd += withResult.NotMaxHeightEven * withoutResult.MaxHeightOdd;
					result.NotMaxHeightEven += withResult.NotMaxHeightEven * withoutResult.NotMaxHeightEven;
					result.NotMaxHeightOdd += withResult.NotMaxHeightEven * withoutResult.NotMaxHeightOdd;

					result.MaxHeightOdd += withResult.NotMaxHeightOdd * withoutResult.MaxHeightEven;
					result.MaxHeightEven += withResult.NotMaxHeightOdd * withoutResult.MaxHeightOdd;
					result.NotMaxHeightOdd += withResult.NotMaxHeightOdd * withoutResult.NotMaxHeightEven;
					result.NotMaxHeightEven += withResult.NotMaxHeightOdd * withoutResult.NotMaxHeightOdd;
				}

				_withoutBaseResults.Add(request, result);
				return result;
			}
		}

		static BigInteger ChooseConsecutive(BigInteger n, BigInteger k)
		{
			BigInteger a = 1;
			BigInteger e = 0;
			
			for (BigInteger i = 0; i < (n - k); i++)
			{
				a = a * 2 + e;

				if (i == 0)
				{
					e = 1;
				}
				else
				{
					e += e;
				}
			}

			return a;
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
