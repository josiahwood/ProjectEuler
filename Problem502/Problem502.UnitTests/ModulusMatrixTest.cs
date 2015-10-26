using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace Problem502.UnitTests
{
	/// <summary>
	/// Summary description for RationalMatrixTest
	/// </summary>
	[TestClass]
	public class ModulusMatrixTest
	{
		[TestMethod]
		public void PowerTest()
		{
			ModulusMatrix matrix = new ModulusMatrix(10, 10);
			ModulusMatrix powerMatrix = ModulusMatrix.Power(matrix, BigInteger.Pow(10, 12));
		}
	}
}
