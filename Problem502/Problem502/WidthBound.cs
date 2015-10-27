using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	class WidthBound
	{
		public static ModulusNumber F(int w, BigInteger h)
		{
			if (w == 0 || h == 0)
			{
				return ModulusNumber.One;
			}

			EvenOdd[] previous = new EvenOdd[w];
			EvenOdd[] current = new EvenOdd[w];

			for (int i = 0; i < w; i++)
			{
				current[i] = EvenOdd.OneEven;
			}

			RationalMatrix aEven = new RationalMatrix(w + 1, w + 1);
			RationalMatrix bEven = new RationalMatrix(w + 1, 1);
			RationalMatrix aOdd = new RationalMatrix(w + 1, w + 1);
			RationalMatrix bOdd = new RationalMatrix(w + 1, 1);

			for (int i = 1; i <= (w + 1) * 2; i++)
			{
				EvenOdd[] temp = previous;
				previous = current;
				current = temp;

				for (int j = 1; j <= w; j++)
				{
					EvenOdd result = Get(current, j - 1) + Get(previous, j).Swap;

					for (int k = 1; k < j; k++)
					{
						EvenOdd subResult0 = Get(previous, k).Swap;
						EvenOdd subResult1 = Get(current, j - k - 1);
						EvenOdd total = subResult0 * subResult1;
						result += total;
					}

					Set(current, j, result);
				}

				if (i % 2 == 0)
				{
					long x = i;
					BigInteger y = previous[w - 1].Odd;
					BigInteger xe = 1;

					for (int j = 0; j < w + 1; j++)
					{
						aEven[(i - 1) / 2, j] = new RationalNumber(xe, 1);
						xe *= x;
					}

					bEven[(i - 1) / 2, 0] = new RationalNumber(y, 1);
				}
				else
				{
					long x = i;
					BigInteger y = previous[w - 1].Odd;
					BigInteger xe = 1;

					for (int j = 0; j < w + 1; j++)
					{
						aOdd[(i - 1) / 2, j] = new RationalNumber(xe, 1);
						xe *= x;
					}

					bOdd[(i - 1) / 2, 0] = new RationalNumber(y, 1);
				}
			}

			RationalMatrix cEven = RationalMatrix.GaussianElimination(aEven, bEven);
			RationalNumber[] coefficientsEven = cEven.GetColumn(0);
			RationalMatrix cOdd = RationalMatrix.GaussianElimination(aOdd, bOdd);
			RationalNumber[] coefficientsOdd = cOdd.GetColumn(0);

			RationalNumber[] highCoefficients;
			RationalNumber[] lowCoefficients;

			if (h % 2 == 0)
			{
				highCoefficients = coefficientsEven;
				lowCoefficients = coefficientsOdd;
			}
			else
			{
				highCoefficients = coefficientsOdd;
				lowCoefficients = coefficientsEven;
			}

			RationalNumber sum = RationalNumber.Zero;

			RationalNumber power = RationalNumber.One;

			for (int i = 0; i < w + 1; i++)
			{
				RationalNumber rationalValue = highCoefficients[i] * power;
				sum += rationalValue;
				power *= new RationalNumber(h, 1);
			}

			if (sum.Denominator != 1)
			{
				throw new Exception();
			}

			if (h > 2)
			{
				power = RationalNumber.One;

				for (int i = 0; i < w + 1; i++)
				{
					RationalNumber rationalValue = lowCoefficients[i] * power;
					sum -= rationalValue;
					power *= new RationalNumber(h - 1, 1);
				}
			}

			return new ModulusNumber((uint)(sum.Numerator % ModulusNumber.Mod));
		}

		static void Set(EvenOdd[] values, int w, EvenOdd value)
		{
			values[w - 1] = value;
		}

		static EvenOdd Get(EvenOdd[] values, int w)
		{
			if (w == 0)
			{
				return EvenOdd.OneEven;
			}

			return values[w - 1];
		}
	}
}
