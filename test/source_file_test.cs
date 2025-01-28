namespace Belin.Lcov;

[TestClass]
public sealed class SourceFileTest {

	[TestMethod("ToString")]
	public void TestToString() {
		var sourceFile = new SourceFile(path: string.Empty);
		AreEqual("SF:\nend_of_record", sourceFile.ToString());

		sourceFile = new SourceFile("/home/cedx/lcov.cs") { Branches = new(), Functions = new(), Lines = new() };
		AreEqual($"SF:/home/cedx/lcov.cs\n{sourceFile.Functions}\n{sourceFile.Branches}\n{sourceFile.Lines}\nend_of_record", sourceFile.ToString());
	}
}
