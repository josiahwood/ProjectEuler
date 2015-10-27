using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Problem502
{
	public class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			//ModulusNumber result1 = F(BigInteger.Pow(10, 12), 100);
			//Console.WriteLine(result1);

			ModulusNumber result2 = F(10000, 10000);
			Console.WriteLine(result2);

			//ModulusNumber result3 = F(100, BigInteger.Pow(10, 12));
			//Console.WriteLine(result3);

			//Console.WriteLine(result1 + result2 + result3);

			Console.Read();
		}

		public static ModulusNumber F(BigInteger w, BigInteger h)
		{
			if (w < h)
			{
				return WidthBound.F((int)w, h);
			}
			else
			{
				return HeightBound.F(w, (int)h);
			}
		}
	}
}