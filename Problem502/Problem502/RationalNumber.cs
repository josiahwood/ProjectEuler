using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	struct RationalNumber
	{
		public static readonly RationalNumber Zero = new RationalNumber(0, 1);
		public static readonly RationalNumber One = new RationalNumber(1, 1);

		public static RationalNumber[] ZeroArray(int length)
		{
			RationalNumber[] a = new RationalNumber[length];

			for (int i = 0; i < length; i++)
			{
				a[i] = RationalNumber.Zero;
			}

			return a;
		}

		public static RationalNumber[] OneArray(int length)
		{
			RationalNumber[] a = new RationalNumber[length];

			for (int i = 0; i < length; i++)
			{
				a[i] = RationalNumber.One;
			}

			return a;
		}

		public BigInteger Numerator;
		public BigInteger Denominator;

		public RationalNumber(BigInteger numerator, BigInteger denominator){
			Numerator = numerator;
			Denominator = denominator;
			Simplify();
		}

		public override string ToString()
		{
			if (Numerator == 0)
			{
				return "0";
			}
			else if (Denominator == 1)
			{
				return Numerator.ToString();
			}
			else
			{
				return string.Format("{0} / {1}", Numerator, Denominator);
			}
		}

		public static RationalNumber Abs(RationalNumber r)
		{
			RationalNumber a;
			a.Numerator = BigInteger.Abs(r.Numerator);
			a.Denominator = BigInteger.Abs(r.Denominator);
			return a;
		}

		private void Simplify()
		{
			if (Denominator.IsZero)
			{
				throw new Exception("Denominator cannot be zero");
			}
			
			BigInteger gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
			Numerator /= gcd;
			Denominator /= gcd;

			if (Denominator.Sign < 0)
			{
				Denominator = -Denominator;
				Numerator = -Numerator;
			}
		}

		public static bool operator ==(RationalNumber left, RationalNumber right)
		{
			if (left.Denominator < 0 || right.Denominator < 0)
			{
				throw new Exception("Denominator must be positive");
			}

			return left.Numerator * right.Denominator == right.Numerator * left.Denominator;
		}

		public static bool operator !=(RationalNumber left, RationalNumber right)
		{
			if (left.Denominator < 0 || right.Denominator < 0)
			{
				throw new Exception("Denominator must be positive");
			}
			
			return left.Numerator * right.Denominator != right.Numerator * left.Denominator;
		}

		public static bool operator >(RationalNumber left, RationalNumber right)
		{
			if (left.Denominator < 0 || right.Denominator < 0)
			{
				throw new Exception("Denominator must be positive");
			}
			
			return left.Numerator * right.Denominator > right.Numerator * left.Denominator;
		}

		public static bool operator <(RationalNumber left, RationalNumber right)
		{
			if (left.Denominator < 0 || right.Denominator < 0)
			{
				throw new Exception("Denominator must be positive");
			}
			
			return left.Numerator * right.Denominator < right.Numerator * left.Denominator;
		}
		
		public static RationalNumber operator +(RationalNumber left, RationalNumber right)
		{
			RationalNumber result;
			result.Numerator = left.Numerator * right.Denominator + right.Numerator * left.Denominator;
			result.Denominator = left.Denominator * right.Denominator;
			result.Simplify();
			return result;
		}

		public static RationalNumber operator -(RationalNumber left, RationalNumber right)
		{
			RationalNumber result;
			result.Numerator = left.Numerator * right.Denominator - right.Numerator * left.Denominator;
			result.Denominator = left.Denominator * right.Denominator;
			result.Simplify();
			return result;
		}

		public static RationalNumber operator *(RationalNumber left, RationalNumber right)
		{
			RationalNumber result;
			result.Numerator = left.Numerator * right.Numerator;
			result.Denominator = left.Denominator * right.Denominator;
			result.Simplify();
			return result;
		}

		public static RationalNumber operator /(RationalNumber left, RationalNumber right)
		{
			RationalNumber result;
			result.Numerator = left.Numerator * right.Denominator;
			result.Denominator = left.Denominator * right.Numerator;
			result.Simplify();
			return result;
		}
	}
}
