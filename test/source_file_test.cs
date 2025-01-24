namespace belin.lcov;

[TestClass]
public sealed class SourceFileTest {

	[TestMethod]
	public void TestToString() {
		var sourceFile = new SourceFile(path: "");
		AreEqual("SF:\nend_of_record", sourceFile.ToString());

		sourceFile = new SourceFile("/home/cedx/lcov.js") { Branches = new BranchCoverage(), Functions = new FunctionCoverage(), Lines = new LineCoverage() };
		AreEqual($"SF:/home/cedx/lcov.js\n{sourceFile.Functions}\n{sourceFile.Branches}\n{sourceFile.Lines}\nend_of_record", sourceFile.ToString());
	}
}
