using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem1.UnitTests
{
	[TestClass]
	public class Problem1Test
	{
		[TestMethod]
		public void StatementExample()
		{
			int result = Program.Solve(10);
			Assert.AreEqual(23, result);
		}
	}
}
