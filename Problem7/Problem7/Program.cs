using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
	class Program
	{
		static void Main(string[] args)
		{
			long t = 10001;
			long[] primes = new long[t];
			primes[0] = 2;
			primes[1] = 3;

			for (int i = 2; i < t; i++)
			{
				// find the ith prime

				for (long j = primes[i - 1] + 2; ; j++)
				{
					// is j the ith prime?

					bool factorfound = false;

					for (int k = 0; k < i; k++)
					{
						if (j % primes[k] == 0)
						{
							factorfound = true;
							break;
						}
					}

					if (!factorfound)
					{
						primes[i] = j;
						break;
					}
				}
			}

			Console.WriteLine(primes[t - 1]);
			Console.Read();
		}
	}
}
