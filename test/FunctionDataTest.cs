namespace Belin.Lcov;

/// <summary>
/// Tests the features of the <see cref="FunctionCoverage"/> class.
/// </summary>
[TestClass]
public sealed class FunctionDataTest {

	[TestMethod("ToString")]
	public void TestToString() {
		var data = new FunctionData { ExecutionCount = 3, FunctionName = "main", LineNumber = 127 };
		AreEqual("FN:0,", new FunctionData().ToString(asDefinition: true));
		AreEqual("FN:127,main", data.ToString(asDefinition: true));
		AreEqual("FNDA:0,", new FunctionData().ToString(asDefinition: false));
		AreEqual("FNDA:3,main", data.ToString(asDefinition: false));
	}
}
