using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	class HeightBound
	{
		public static ModulusNumber F(BigInteger w, int h)
		{
			ModulusNumber result1 = Solve(w, h);
			ModulusNumber result2 = Solve(w, h - 1);
			return result1 - result2;
		}

		private static ModulusNumber Solve(BigInteger w, int h)
		{
			int size = h * 2;
			ModulusMatrix matrix = new ModulusMatrix(size, size);
			ModulusMatrix initial = new ModulusMatrix(size, 1);
			ModulusMatrix temp = new ModulusMatrix(size, 1);

			// matrix loop
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (j == i)
					{
						initial[j, 0] = ModulusNumber.One;
					}
					else
					{
						initial[j, 0] = ModulusNumber.Zero;
					}

					temp[j, 0] = ModulusNumber.Zero;
				}

				// temp loop
				for (int j = 0; j < h; j++)
				{
					ModulusEvenOdd total = new ModulusEvenOdd();

					// initial loop
					for (int k = 0; k < h; k++)
					{
						ModulusEvenOdd value = Get(initial, k);

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

					Set(temp, j, total);
				}

				matrix.SetColumn(i, temp.GetColumn(0));
			}

			for (int i = 0; i < h; i++)
			{
				if (i % 2 == 0)
				{
					Set(initial, i, ModulusEvenOdd.OneEven);
				}
				else
				{
					Set(initial, i, ModulusEvenOdd.OneOdd);
				}
			}

			ModulusMatrix powerMatrix = ModulusMatrix.Power(matrix, w - 1);
			ModulusMatrix result = powerMatrix * initial;

			ModulusNumber sum = ModulusNumber.Zero;

			for (int i = 0; i < h; i++)
			{
				sum += result[i * 2 + 1, 0];
			}

			return sum;
		}

		private static ModulusEvenOdd Get(ModulusMatrix values, int index)
		{
			ModulusEvenOdd result = new ModulusEvenOdd(values[index * 2, 0], values[index * 2 + 1, 0]);
			return result;
		}

		private static void Set(ModulusMatrix values, int index, ModulusEvenOdd value)
		{
			values[index * 2, 0] = value.Even;
			values[index * 2 + 1, 0] = value.Odd;
		}
	}
}
