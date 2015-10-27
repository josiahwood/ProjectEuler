using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	struct ModulusEvenOdd
	{
		public static readonly ModulusEvenOdd OneEven = new ModulusEvenOdd(ModulusNumber.One, ModulusNumber.Zero);
		public static readonly ModulusEvenOdd OneOdd = new ModulusEvenOdd(ModulusNumber.Zero, ModulusNumber.One);

		public ModulusNumber Even;
		public ModulusNumber Odd;

		public ModulusEvenOdd(ModulusNumber even, ModulusNumber odd)
		{
			Even = even;
			Odd = odd;
		}

		public static ModulusEvenOdd operator +(ModulusEvenOdd left, ModulusEvenOdd right)
		{
			ModulusEvenOdd result;
			result.Even = left.Even + right.Even;
			result.Odd = left.Odd + right.Odd;
			return result;
		}

		public static ModulusEvenOdd operator *(ModulusEvenOdd left, ModulusEvenOdd right)
		{
			ModulusEvenOdd result;
			result.Even = (left.Even * right.Even) + (left.Odd * right.Odd);
			result.Odd = (left.Even * right.Odd) + (left.Odd * right.Even);
			return result;
		}

		public ModulusEvenOdd Swap
		{
			get
			{
				return new ModulusEvenOdd(Odd, Even);
			}
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}", Even, Odd);
		}
	}
}
