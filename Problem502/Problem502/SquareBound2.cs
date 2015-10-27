using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	class SquareBound2
	{
		public static ModulusNumber F(int w, int h)
		{
			ModulusNumber result1 = Solve(w, h);
			ModulusNumber result2 = Solve(w, h - 1);
			return result1 - result2;
		}

		private static ModulusNumber Solve(int w, int h)
		{
			ModulusEvenOdd[] previous = new ModulusEvenOdd[h];
			ModulusEvenOdd[] current = new ModulusEvenOdd[h];
			
			for (int i = 0; i < h; i++)
			{
				if (i % 2 == 0)
				{
					current[i] = ModulusEvenOdd.OneEven;
				}
				else
				{
					current[i] = ModulusEvenOdd.OneOdd;
				}
			}

			for (int i = 1; i < w; i++)
			{
				Console.WriteLine(i);

				ModulusEvenOdd[] temp = previous;
				previous = current;
				current = temp;

				for (int j = 0; j < h; j++)
				{
					ModulusEvenOdd total = new ModulusEvenOdd();

					for (int k = 0; k < h; k++)
					{
						ModulusEvenOdd value = previous[k];

						if (k >= j)
						{
							total += value;
						}
						else
						{
							if (((j - k) % 2) == 1)
							{
								total += value.Swap;
							}
							else
							{
								total += value;
							}
						}
					}

					current[j] = total;
				}
			}
			
			ModulusNumber sum = ModulusNumber.Zero;

			for (int i = 0; i < h; i++)
			{
				sum += current[i].Odd;
			}

			return sum;
		}
	}
}
