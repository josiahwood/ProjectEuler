using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
	class Program
	{
		static void Main(string[] args)
		{
			long n = SquareOfSums(100) - SumOfSquares(100);

			Console.WriteLine(n);
			Console.Read();
		}

		static private long SumOfSquares(long n)
		{
			long s = 0;

			for (int i = 0; i <= n; i++)
			{
				s += i * i;
			}

			return s;
		}

		static private long SquareOfSums(long n)
		{
			long s = 0;

			for (long i = 0; i <= n; i++)
			{
				s += i;
			}

			return s * s;
		}
	}
}
