using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem20
{
	class Program
	{
		static void Main(string[] args)
		{
			BigInteger f = 1;

			for (ulong i = 2; i <= 100; i++)
			{
				f *= i;
			}

			string str = f.ToString();
			long sum = 0;

			for (int i = 0; i < str.Length; i++)
			{
				sum += long.Parse(str[i].ToString());
			}

			Console.WriteLine(sum);
			Console.Read();
		}
	}
}
