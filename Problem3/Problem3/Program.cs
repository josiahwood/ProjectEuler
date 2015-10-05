using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
	class Program
	{
		static void Main(string[] args)
		{
			long n = 600851475143;

			long factor = LargestPrimeFactor(n);

			Console.WriteLine(factor);
			Console.Read();
		}

		static private long LargestPrimeFactor(long n)
		{
			long i = (long)Math.Sqrt((double)n);

			if (i % 2 == 0)
			{
				i--;
			}

			while (n % i != 0)
			{
				i -= 2;

				if (i <= 2)
				{
					return n;
				}
			}

			long factor1 = i;
			long factor2 = n / i;

			long largestPrimeFactor1 = LargestPrimeFactor(factor1);
			long largestPrimeFactor2 = LargestPrimeFactor(factor2);

			return Math.Max(largestPrimeFactor1, largestPrimeFactor2);
		}
	}
}
