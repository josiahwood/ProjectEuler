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
			ModulusMatrix matrix = new ModulusMatrix(2, 2);

			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					matrix[i, j] = new ModulusNumber((ulong)(i * 2 + j));
				}
			}

			ModulusMatrix manualMatrix = matrix * matrix * matrix;
			ModulusMatrix powerMatrix = ModulusMatrix.Power(matrix, 3);

			Assert.IsTrue(manualMatrix == powerMatrix);
		}
	}
}
