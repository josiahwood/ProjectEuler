using System;

namespace Problem1
{
	public class Program
	{
		static void Main(string[] args)
		{
			int result = Solve(1000);
			Console.WriteLine(result);
		}

		public static int Solve(int limit)
		{
			return Sum(limit, 3) + Sum(limit, 5) - Sum(limit, 15);
		}

		static int Sum(int limit, int increment)
		{
			int n = (limit - 1) / increment;
			return increment * n * (n + 1) / 2;
		}
	}
}
