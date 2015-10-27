using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	class SquareBound1
	{
		public static ModulusNumber F(int w, int h)
		{
			if (w == 0 || h == 0)
			{
				return ModulusNumber.One;
			}

			ModulusEvenOdd[] previous = new ModulusEvenOdd[w];
			ModulusEvenOdd[] current = new ModulusEvenOdd[w];

			for (int i = 0; i < w; i++)
			{
				current[i] = ModulusEvenOdd.OneEven;
			}

			for (int i = 1; i < h; i++)
			{
				if (i % 10 == 0)
				{
					Console.WriteLine(i);
				}

				ModulusEvenOdd[] temp = previous;
				previous = current;
				current = temp;

				for (int j = 1; j <= w; j++)
				{
					ModulusEvenOdd result = Get(current, j - 1) + Get(previous, j).Swap;

					for (int k = 1; k < j; k++)
					{
						ModulusEvenOdd subResult0 = Get(previous, k).Swap;
						ModulusEvenOdd subResult1 = Get(current, j - k - 1);
						ModulusEvenOdd total = subResult0 * subResult1;
						result += total;
					}

					Set(current, j, result);
				}
			}

			return current[w - 1].Odd - previous[w - 1].Odd;
		}
		
		static void Set(ModulusEvenOdd[] values, int w, ModulusEvenOdd value)
		{
			values[w - 1] = value;
		}

		static ModulusEvenOdd Get(ModulusEvenOdd[] values, int w)
		{
			if (w == 0)
			{
				return ModulusEvenOdd.OneEven;
			}

			return values[w - 1];
		}
	}
}
