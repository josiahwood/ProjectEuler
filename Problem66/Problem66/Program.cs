using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem66
{
	class Program
	{
		static void Main(string[] args)
		{
			// 741 is incorrect
			long result = Solve(1000);
			Console.WriteLine(result);
			Console.Read();
		}

		static long Solve(long maxD)
		{
			long maxDSquared = maxD * maxD;
			
			List<long> squares = new List<long>();

			for (long s = 1; s <= maxDSquared; s++)
			{
				squares.Add(s * s);
			}
			
			long maxX = 0;
			long bestD = 0;

			for (long d = 2; d <= maxD; d++)
			{
				if (!squares.Contains(d))
				{
					for (long x = 1; x <= maxDSquared * maxDSquared; x++)
					{
						// x^2 - Dy^2 = 1
						// -Dy^2 = 1 - x^2
						// y^2 = (x^2 - 1)/D

						if (((x * x) - 1) % d == 0)
						{
							long ySquared = ((x * x) - 1) / d;

							if (squares.Contains(ySquared))
							{
								if (x >= maxX)
								{
									maxX = x;
									bestD = d;
								}

								break;
							}
						}
					}
				}
			}

			return bestD;
		}
	}
}
