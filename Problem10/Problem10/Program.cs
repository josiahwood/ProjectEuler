using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10
{
	class Program
	{
		static void Main(string[] args)
		{
			List<long> primes = new List<long>();
			primes.Add(2);
			primes.Add(3);

			for (int i = 2; ; i++)
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
						primes.Add(j);
						break;
					}
				}

				if (primes[i] > 2000000)
				{
					break;
				}
			}

			long s = 0;

			for (int i = 0; i < primes.Count - 1; i++)
			{
				s += primes[i];
			}

			Console.WriteLine(primes[primes.Count - 1]);
			Console.WriteLine(s);
			Console.Read();
		}
	}
}
