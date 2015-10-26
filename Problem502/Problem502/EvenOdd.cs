using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	public struct EvenOdd
	{
		public static readonly EvenOdd OneEven = new EvenOdd(1, 0);
		public static readonly EvenOdd OneOdd = new EvenOdd(0, 1);

		public BigInteger Even;
		public BigInteger Odd;

		public EvenOdd(BigInteger even, BigInteger odd)
		{
			Even = even;
			Odd = odd;
		}

		public static EvenOdd operator +(EvenOdd left, EvenOdd right)
		{
			EvenOdd result;
			result.Even = left.Even + right.Even;
			result.Odd = left.Odd + right.Odd;
			return result;
		}

		public static EvenOdd operator *(EvenOdd left, EvenOdd right)
		{
			EvenOdd result;
			result.Even = (left.Even * right.Even) + (left.Odd * right.Odd);
			result.Odd = (left.Even * right.Odd) + (left.Odd * right.Even);
			return result;
		}

		public EvenOdd Swap
		{
			get
			{
				return new EvenOdd(Odd, Even);
			}
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}", Even, Odd);
		}
	}
}
