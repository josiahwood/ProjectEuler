using System;
using System.Diagnostics;

namespace Problem2
{
	public class Program
	{
		static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();

			sw.Start();
			for (int i = 0; i < 1000000; i++)
			{
				SolveA();
			}
			sw.Stop();
			Console.WriteLine(sw.ElapsedTicks);

			sw.Reset();
			sw.Start();
			for (int i = 0; i < 1000000; i++)
			{
				SolveB();
			}
			sw.Stop();
			Console.WriteLine(sw.ElapsedTicks);

			sw.Reset();
			sw.Start();
			for (int i = 0; i < 1000000; i++)
			{
				SolveC();
			}
			sw.Stop();
			Console.WriteLine(sw.ElapsedTicks);
			
			Console.Read();
		}

		/// <summary>
		/// Only remembers every 3rd Fibonacci number
		/// </summary>
		/// <returns></returns>
		public static long SolveA()
		{
			long n1 = 1;
			long n2 = 2;
			long total = 0;

			while (n2 <= 4000000)
			{
				total += n2;

				long n3 = n1 + n2;
				long n4 = n2 + n3;
				long n5 = n3 + n4;

				n1 = n4;
				n2 = n5;
			}

			return total;
		}
		
		// f(n) = f(n-1) + f(n-2)
		// f(n) = f(n-2) + f(n-3) + f(n-2)
		// f(n) = 2*f(n-2) + f(n-3)
		// f(n) = 2*(f(n-3) + f(n-4)) + f(n-3)
		// f(n) = 2*f(n-4) + 3*f(n-3)
		// f(n) = f(n-4)+f(n-5)+f(n-6) + 3*f(n-3)
		// f(n) = f(n-3)+f(n-6) + 3*f(n-3)
		// f(n) = f(n-6) + 4*f(n-3)
		// f(n) = 4*f(n-3) + f(n-6)
		
		// 1, 1, 2, 3, 5, 8, 13, 21, 34, 55
		// 2, 8, 34

		/// <summary>
		/// Only generates every 3rd Fibonacci number
		/// </summary>
		/// <returns></returns>
		public static long SolveB()
		{
			long n1 = 2;
			long n2 = 8;
			long n3 = 34;
			long total = 10;

			while (n3 <= 4000000)
			{
				total += n3;
				n1 = n2;
				n2 = n3;
				n3 = (n2 << 2) + n1;
			}

			return total;
		}

		// F(n) = 4*F(n-3) + F(n-6)
		// F(n+6) = 4*F(n+3) + F(n)
		// F(n) = F(n+6) - 4*F(n+3)

		// F(n)   = F(n+6) - 4*F(n+3)
		// F(n-3) =            F(n+3) - 4*F(n)
		// F(n-6) =                       F(n)   - 4*F(n-3)
		// F(n-9) =                                  F(n-3) - 4*F(n-6)
		// .        .        .
		// .        .        .
		// .        .        .
		// F(12)  =                                                        F(18)  - 4*F(15)
		// F(9)   =                                                                   F(15)  - 4*F(12)
		// F(6)   =                                                                              F(12)  - 4*F(9)
		// F(3)   =                                                                                         F(9)   - 4*F(6)
		// F(0)   =                                                                                                    F(6)   - 4*F(3)
		// S(n)   = F(n+6) - 3*F(n+3) - 3*F(n)   - 3*F(n-3)           ...         - 3*F(15)  - 3*F(12)  - 3*F(9)   - 3*F(6)   - 4*F(3)
		// S(n)   = F(n+6) - 3*F(n+3) - 3*S(n)                                                                                  - F(3)
		// 4*S(n) = F(n+6) - 3*F(n+3) - F(3)
		// S(n)   = (F(n+6) - 3*F(n+3) - F(3)) / 4

		/// <summary>
		/// Doesn't have to keep a running total
		/// </summary>
		/// <returns></returns>
		public static long SolveC()
		{
			long n1 = 2;
			long n2 = 8;
			long n3 = 34;

			while (n3 <= 4000000)
			{
				n1 = n2;
				n2 = n3;
				n3 = (n2 << 2) + n1;
			}

			n1 = (n3 << 2) + n2;

			long total = (n1 - 3 * n3 - 2) >> 2;

			return total;
		}
    }
}
