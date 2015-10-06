using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem40
{
	class Program
	{
		static void Main(string[] args)
		{
			long product = 1;
			int digitIndex = 0;
			long n = 1;
			int target = 1;

			while (digitIndex < 1000000)
			{
				string str = n.ToString();
				digitIndex += str.Length;
				n++;

				if (target <= digitIndex)
				{
					int digit = int.Parse(str[str.Length - 1 - (digitIndex - target)].ToString());
					product *= digit;
					target *= 10;
				}
			}

			Console.WriteLine(product);
			Console.Read();
		}
	}
}
