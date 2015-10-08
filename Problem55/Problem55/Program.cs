using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem55
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 0;

			for (int i = 1; i < 10000; i++)
			{
				BigInteger test = i;
				BigInteger reverse = Reverse(test);

				for (int j = 0; j < 50; j++)
				{
					test += reverse;
					reverse = Reverse(test);
					
					if (test == reverse)
					{
						count++;
						break;
					}

					if (j == 49)
					{
						break;
					}
				}
			}

			Console.WriteLine(9999 - count);
			Console.Read();
		}

		static BigInteger Reverse(BigInteger n)
		{
			BigInteger r = 0;

			while (n > 0)
			{
				r *= 10;
				r += n % 10;
				n /= 10;
			}

			return r;
		}
	}
}
