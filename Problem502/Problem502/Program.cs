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
			ModulusNumber result;

			result = F(100, BigInteger.Pow(10, 12));
			Console.WriteLine(result);

			Console.Read();
		}

		public static ModulusNumber F(BigInteger w, BigInteger h)
		{
			return WidthBound.F((int)w, h);
		}
	}
}