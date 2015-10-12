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
		/// <summary>
		/// number = 2 * index + 3
		/// </summary>
		const int _maxNumber = 100000000;
		static BitArray _isPrime = new BitArray((_maxNumber - 3) / 2, true);
		
		static List<long> _pairCount = new List<long>();
		
		static void Main(string[] args)
		{
			DateTime start = DateTime.Now;

			PopulateIsPrime();

			long lowestSum = long.MaxValue;

			long max = (long)Math.Sqrt(_maxNumber);

			for (int p0 = 4; p0 < max; p0++)
			{
				if (IsPrime(p0))
				{
					for (int p1 = p0 - 1; p1 >= 0; p1--)
					{
						if (IsPrime(p1) && Test(p1, p0))
						{
							for (int p2 = p1 - 1; p2 >= 0; p2--)
							{
								if (IsPrime(p2) && Test(p2, p0) && Test(p2, p1))
								{
									for (int p3 = p2 - 1; p3 >= 0; p3--)
									{
										if (IsPrime(p3) && Test(p3, p0) && Test(p3, p1) && Test(p3, p2))
										{
											for (int p4 = p3 - 1; p4 >= 0; p4--)
											{
												if (IsPrime(p4) && Test(p4, p0) && Test(p4, p1) && Test(p4, p2) && Test(p4, p3))
												{
													long sum = p0 + p1 + p2 + p3 + p4;

													if (sum < lowestSum)
													{
														lowestSum = sum;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}

			Console.WriteLine(lowestSum);
			Console.Read();
		}

		private static bool Test(int prime1, int prime2)
		{
			int test = Concat(prime1, prime2);
			
			if (IsPrime(test))
			{
				test = Concat(prime2, prime1);
				return IsPrime(test);
			}
			else
			{
				return false;
			}
		}

		private static int Concat(int i1, int i2)
		{
			int t2 = i2;

			while (t2 > 0)
			{
				i1 *= 10;
				t2 /= 10;
			}

			int t = i1 + i2;

			return t;
		}

		private static bool IsPrime(int n)
		{
			if (n < 2)
			{
				return false;
			}
			else if (n == 2)
			{
				return true;
			}
			else if (n % 2 == 0)
			{
				return false;
			}
			else
			{
				return _isPrime[(n - 3) / 2];
			}
		}

		static void PopulateIsPrime()
		{
			int maxValue = 2 * (_isPrime.Length - 1) + 3;

			for (int i = 0; i < _isPrime.Length; i++)
			{
				if (_isPrime[i])
				{
					int n = 2 * i + 3;
					int inc = 2 * n;

					for (int j = n + inc; j <= maxValue; j += inc)
					{
						_isPrime[(j - 3) / 2] = false;
					}
				}
			}
		}
	}
}
