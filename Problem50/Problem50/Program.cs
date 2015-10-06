using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem50
{
	class Program
	{
		static void Main(string[] args)
		{
			List<long> primes = ListPrimes(999999);

			long bestSum = 0;
			int bestLength = 0;

			for (int start = 0; start + bestLength < primes.Count; start++)
			{
				long sum = 0;

				for (int length = 1; start + length <= primes.Count; length++)
				{
					sum += primes[start + length - 1];

					if (length > bestLength)
					{
						if (primes.Contains(sum))
						{
							bestSum = sum;
							bestLength = length;
						}
					}
				}
			}

			Console.WriteLine(bestSum);
			Console.Read();
		}

		private static List<long> ListPrimes(long maxValue)
		{
			List<long> primes = new List<long>();
			primes.Add(2);
			primes.Add(3);

			for (int i = 2; ; i++)
			{
				// find the ith prime

				for (long j = primes[i - 1] + 2; j <= maxValue; j++)
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
						primes.Add(j);
						break;
					}
				}

				if (primes.Count == i)
				{
					break;
				}
			}

			return primes;
		}
	}
}
