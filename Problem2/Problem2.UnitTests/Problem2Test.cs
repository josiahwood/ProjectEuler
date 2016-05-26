using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem2.UnitTests
{
	[TestClass]
	public class Problem2Test
	{
		[TestMethod]
		public void SolveATest()
		{
			long result = Program.SolveA();
			Assert.AreEqual(4613732, result);
		}

		[TestMethod]
		public void SolveBTest()
		{
			long result = Program.SolveB();
			Assert.AreEqual(4613732, result);
		}

		[TestMethod]
		public void SolveCTest()
		{
			long result = Program.SolveC();
			Assert.AreEqual(4613732, result);
		}
	}
}
