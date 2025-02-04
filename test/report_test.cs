namespace Belin.Lcov;

[TestClass]
public sealed class ReportTest {

	/// <summary>
	/// The test fixture.
	/// </summary>
	private static string coverage = string.Empty;

	[ClassInitialize]
	public static void ClassInitialize(TestContext _) {
		coverage = File.ReadAllText("../res/lcov.info");
	}

	[TestMethod]
	public void Parse() {
		var report = Report.Parse(coverage);
		AreEqual(3, report.SourceFiles.Count);
		AreEqual("/home/cedx/lcov.cs/fixture.cs", report.SourceFiles[0].Path);
		AreEqual("/home/cedx/lcov.cs/func1.cs", report.SourceFiles[1].Path);
		AreEqual("/home/cedx/lcov.cs/func2.cs", report.SourceFiles[2].Path);

		var branches = report.SourceFiles[1].Branches!;
		AreEqual(4, branches.Found);
		AreEqual(4, branches.Hit);
		AreEqual(4, branches.Data.Count);
		AreEqual(8, branches.Data[0].LineNumber);

		var functions = report.SourceFiles[1].Functions!;
		AreEqual(1, functions.Found);
		AreEqual(1, functions.Hit);
		AreEqual(1, functions.Data.Count);
		AreEqual("func1", functions.Data[0].FunctionName);

		var lines = report.SourceFiles[1].Lines!;
		AreEqual(9, lines.Found);
		AreEqual(9, lines.Hit);
		AreEqual(9, lines.Data.Count);
		AreEqual("5kX7OTfHFcjnS98fjeVqNA", lines.Data[0].Checksum);

		ThrowsException<FormatException>(() => Report.Parse("TN:Example"));
	}

	[TestMethod("ToString")]
	public void TestToString() {
		var sourceFile = new SourceFile(path: string.Empty);
		AreEqual(string.Empty, new Report(string.Empty).ToString());
		AreEqual($"TN:LcovTest\n{sourceFile}", new Report("LcovTest", [sourceFile]).ToString());
	}

	[TestMethod]
	public void TryParse() {
		IsTrue(Report.TryParse(coverage, out var report));
		IsNotNull(report);
		IsFalse(Report.TryParse("TN:Example", out report));
		IsNull(report);
	}
}
