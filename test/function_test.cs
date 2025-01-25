namespace Belin.Lcov;

[TestClass]
public sealed class FunctionCoverageTest {

	[TestMethod]
	public void TestToString() {
		var data = new FunctionData { ExecutionCount = 3, FunctionName = "main", LineNumber = 127 };
		AreEqual("FNF:0\nFNH:0", new FunctionCoverage().ToString());
		AreEqual("FN:127,main\nFNDA:3,main\nFNF:23\nFNH:11", new FunctionCoverage { Data = [data], Found = 23, Hit = 11 }.ToString());
	}
}

[TestClass]
public sealed class FunctionDataTest {

	[TestMethod]
	public void TestToString() {
		var data = new FunctionData { ExecutionCount = 3, FunctionName = "main", LineNumber = 127 };
		AreEqual("FN:0,", new FunctionData().ToString(asDefinition: true));
		AreEqual("FN:127,main", data.ToString(asDefinition: true));
		AreEqual("FNDA:0,", new FunctionData().ToString(asDefinition: false));
		AreEqual("FNDA:3,main", data.ToString(asDefinition: false));
	}
}
