using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem80
{
	/// <summary>
	/// https://en.wikipedia.org/wiki/Methods_of_computing_square_roots
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			long sum = 0;

			for (int i = 2; i < 100; i++)
			{
				sum += SumOfDigits(i);
			}

			Console.WriteLine(sum);
			Console.Read();
		}

		static long SumOfDigits(int n)
		{
			long sum = 0;

			BigInteger c = n;
			BigInteger p = 0;
			
			for (int i = 0; i < 100; i++)
			{
				// x(20p+x) <= c
				int x = 0;

				for (int j = 9; j >= 1; j--)
				{
					BigInteger test = j * (20 * p + j);

					if (test <= c)
					{
						x = j;
						break;
					}
				}
				
				BigInteger y = x * (20 * p + x);
				p = p * 10 + x;
				c -= y;

				if (c == 0)
				{
					return 0;
				}

				c *= 100;
				sum += x;
			}

			return sum;
		}
	}
}
