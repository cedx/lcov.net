namespace Belin.Lcov;

/// <summary>
/// Tests the features of the <see cref="FunctionCoverage"/> class.
/// </summary>
[TestClass]
public sealed class FunctionCoverageTest {

	[TestMethod("ToString")]
	public void TestToString() {
		var data = new FunctionData { ExecutionCount = 3, FunctionName = "main", LineNumber = 127 };
		AreEqual("FNF:0\nFNH:0", new FunctionCoverage().ToString());
		AreEqual("FN:127,main\nFNDA:3,main\nFNF:23\nFNH:11", new FunctionCoverage { Data = [data], Found = 23, Hit = 11 }.ToString());
	}
}
