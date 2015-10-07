using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem60
{
	class Program
	{
		static long[] _primes = new long[1000];
		static int _primeCount = 0;
		static List<long> _pairCount = new List<long>();
		const int _size = 4;
		
		static void Main(string[] args)
		{
			DateTime start = DateTime.Now;

			AddPrime(2);
			AddPrime(3);

			EnsureMinimumPrime(100);

			// prime indexes
			int[] p = new int[2];

			for (int i = 0; i < p.Length; i++)
			{
				p[i] = i;
			}

			List<int> candidatePrimeIndices = new List<int>();
			int[] cpi = new int[_size];

			while (true)
			{
				bool test = Test(p[0], p[1]);

				if (test)
				{
					_pairCount[p[0]]++;
					_pairCount[p[1]]++;
					int candidatesAdded = 0;

					if (_pairCount[p[0]] == _size - 1)
					{
						candidatePrimeIndices.Add(p[0]);
						candidatesAdded++;
					}

					if (_pairCount[p[1]] == _size - 1)
					{
						candidatePrimeIndices.Add(p[1]);
						candidatesAdded++;
					}

					// clique problem

					if (candidatesAdded > 0 && candidatePrimeIndices.Count >= _size)
					{
						for (int i = 0; i < _size; i++)
						{
							cpi[i] = candidatePrimeIndices.Count - _size + i;
						}

						int min = candidatePrimeIndices.Count - candidatesAdded;

						while (cpi[_size - 1] >= min)
						{
							//test these indices to see if they are all connected

							bool connected = true;

							for (int i = 1; i < _size; i++)
							{
								for (int j = 0; j < i; j++)
								{
									int pi1 = candidatePrimeIndices[cpi[i]];
									int pi2 = candidatePrimeIndices[cpi[j]];

									if (!Test(pi1, pi2))
									{
										connected = false;
										break;
									}
								}

								if (!connected)
								{
									break;
								}
							}

							if (connected)
							{
								long sum = 0;
								long[] resultPrimes = new long[_size];

								for (int i = 0; i < _size; i++)
								{
									resultPrimes[i] = _primes[candidatePrimeIndices[cpi[i]]];
									Console.WriteLine(resultPrimes[i]);
									sum += resultPrimes[i];
								}

								Console.WriteLine("SUM: {0}", sum);
								Console.WriteLine(DateTime.Now - start);
								Console.Read();
								return;
							}

							Decrement(cpi);
						}
					}
				}

				Increment(p);
			}
		}

		private static bool Test(int index1, int index2)
		{
			long p1 = _primes[index1];
			long p2 = _primes[index2];
			long test = Concat(p1, p2);
			
			if (IsPrime(test))
			{
				test = Concat(p2, p1);
				return IsPrime(test);
			}
			else
			{
				return false;
			}
		}

		private static long Concat(long i1, long i2)
		{
			long t2 = i2;

			while (t2 > 0)
			{
				i1 *= 10;
				t2 /= 10;
			}

			long t = i1 + i2;

			return t;
		}

		private static void Increment(int[] p)
		{
			p[0]++;

			for (int i = 1; i < p.Length; i++)
			{
				if (p[i] == p[i - 1])
				{
					p[i]++;

					for (int j = 0; j < i; j++)
					{
						p[j] = j;
					}
				}
			}
		}

		private static void Decrement(int[] p)
		{
			p[0]--;

			for (int i = 0; i < p.Length - 1; i++)
			{
				if (p[i] < i)
				{
					p[i + 1]--;
					
					for (int j = i; j >= 0; j--)
					{
						p[j] = p[j + 1] - 1;
					}
				}
			}
		}

		private static bool IsPrime(long n)
		{
			EnsureMinimumPrime(n);

			int min = 0;
			int max = _primeCount - 1;

			while (min <= max)
			{
				int test = (max + min) >> 1;
				long value = _primes[test];

				if (value == n)
				{
					return true;
				}
				else if (value < n)
				{
					min = test + 1;
				}
				else
				{
					max = test - 1;
				}
			}

			return false;
		}

		private static void EnsureMinimumPrime(long n)
		{
			while (_primes[_primeCount - 1] < n)
			{
				AddNextPrime();
			}
		}

		private static void AddNextPrime()
		{
			int i = _primeCount;
			
			// find the ith prime

			for (long j = _primes[i - 1] + 2; ; j += 2)
			{
				// is j the ith prime?

				long sqrt = (long)Math.Sqrt(j);

				bool factorfound = false;

				for (int k = 1; k < i; k++)
				{
					long p = _primes[k];
					
					if (p > sqrt)
					{
						break;
					}

					if (j % p == 0)
					{
						factorfound = true;
						break;
					}
				}

				if (!factorfound)
				{
					AddPrime(j);
					return;
				}
			}
		}

		private static void AddPrime(long n)
		{
			if (_primeCount == _primes.Length)
			{
				long[] newPrimes = new long[_primes.Length + 1000];
				Array.Copy(_primes, newPrimes, _primeCount);
				_primes = newPrimes;
			}

			_primes[_primeCount] = n;
			_pairCount.Add(0);
			_primeCount++;
		}
	}
}
