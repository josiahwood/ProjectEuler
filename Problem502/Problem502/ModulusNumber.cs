using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	public struct ModulusNumber
	{
		public const ulong Mod = 1000000007;
		
		public static readonly ModulusNumber Zero = new ModulusNumber(0);
		public static readonly ModulusNumber One = new ModulusNumber(1);

		public ulong Value;

		public ModulusNumber(ulong value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public static bool operator ==(ModulusNumber left, ModulusNumber right)
		{
			return left.Value == right.Value;
		}

		public static bool operator !=(ModulusNumber left, ModulusNumber right)
		{
			return left.Value != right.Value;
		}

		public static bool operator >(ModulusNumber left, ModulusNumber right)
		{
			return left.Value > right.Value;
		}

		public static bool operator <(ModulusNumber left, ModulusNumber right)
		{
			return left.Value < right.Value;
		}

		public static ModulusNumber operator +(ModulusNumber left, ModulusNumber right)
		{
			ulong value = (left.Value + right.Value) % Mod;
			return new ModulusNumber(value);
		}

		public static ModulusNumber operator -(ModulusNumber left, ModulusNumber right)
		{
			ulong value = (Mod + left.Value - right.Value) % Mod;
			return new ModulusNumber(value);
		}

		public static ModulusNumber operator *(ModulusNumber left, ModulusNumber right)
		{
			ulong value = (left.Value * right.Value) % Mod;
			return new ModulusNumber(value);
		}
	}
}
