namespace Belin.Lcov;

using System.ComponentModel;

/// <summary>
/// Tests the features of the <see cref="FunctionCoverage"/> class.
/// </summary>
[TestClass]
public sealed class FunctionCoverageTests {

	[TestMethod, DisplayName("ToString")]
	public void TestToString() {
		var data = new FunctionData { ExecutionCount = 3, FunctionName = "main", LineNumber = 127 };
		AreEqual("FNF:0\nFNH:0", new FunctionCoverage().ToString());
		AreEqual("FN:127,main\nFNDA:3,main\nFNF:23\nFNH:11", new FunctionCoverage { Data = [data], Found = 23, Hit = 11 }.ToString());
	}
}

/// <summary>
/// Tests the features of the <see cref="FunctionData"/> class.
/// </summary>
[TestClass]
public sealed class FunctionDataTests {

	[TestMethod, DisplayName("ToString")]
	public void TestToString() {
		var data = new FunctionData { ExecutionCount = 3, FunctionName = "main", LineNumber = 127 };
		AreEqual("FN:0,", new FunctionData().ToString(asDefinition: true));
		AreEqual("FN:127,main", data.ToString(asDefinition: true));
		AreEqual("FNDA:0,", new FunctionData().ToString(asDefinition: false));
		AreEqual("FNDA:3,main", data.ToString(asDefinition: false));
	}
}
