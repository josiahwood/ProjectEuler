using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
	class Program
	{
		static void Main(string[] args)
		{
			long n1 = 1;
			long n2 = 2;
			long total = 0;

			while(n2 <= 4000000)
			{
				total += n2;
				
				long n3 = n1 + n2;
				long n4 = n2 + n3;
				long n5 = n3 + n4;

				n1 = n4;
				n2 = n5;
			}

			Console.WriteLine(total);
			Console.Read();
		}
	}
}
