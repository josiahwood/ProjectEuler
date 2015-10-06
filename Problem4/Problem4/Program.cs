using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
	class Program
	{
		static void Main(string[] args)
		{
			long l = 0;

			for (int i = 999; i >= 100; i--)
			{
				for (int j = i - 1; j >= 100; j--)
				{
					long n = i * j;

					if (n > l && IsPalindrome(n))
					{
						l = n;
					}
				}
			}

			Console.WriteLine(l);
			Console.Read();
		}

		static private bool IsPalindrome(long n)
		{
			string s = n.ToString();

			for (int i = 0; i < s.Length / 2; i++)
			{
				if (s[i] != s[s.Length - 1 - i])
				{
					return false;
				}
			}

			return true;
		}
	}
}
