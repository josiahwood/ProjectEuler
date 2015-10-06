using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem30
{
	class Program
	{
		static void Main(string[] args)
		{
			long powerSum = 0;

			for (int i = 10; i < 9999999; i++)
			{
				string s = i.ToString();

				long sum = 0;

				for (int j = 0; j < s.Length; j++)
				{
					int digit = int.Parse(s[j].ToString());
					sum += digit * digit * digit * digit * digit;
				}

				if (sum == i)
				{
					powerSum += sum;
					Console.WriteLine(sum);
				}
			}

			Console.WriteLine("Sum: {0}", powerSum);
			Console.Read();
		}
	}
}
