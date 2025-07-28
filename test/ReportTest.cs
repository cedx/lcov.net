namespace Belin.Lcov;

/// <summary>
/// Tests the features of the <see cref="Report"/> class.
/// </summary>
[TestClass]
public sealed class ReportTest {

	/// <summary>
	/// The test fixture.
	/// </summary>
	private readonly string coverage;

	/// <summary>
	/// Creates a new test.
	/// </summary>
	public ReportTest() =>
		coverage = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../res/Lcov.info"));

	[TestMethod]
	public void Parse() {
		var report = Report.Parse(coverage);
		HasCount(3, report.SourceFiles);
		AreEqual("/home/cedx/lcov.net/fixture.cs", report.SourceFiles[0].Path);
		AreEqual("/home/cedx/lcov.net/func1.cs", report.SourceFiles[1].Path);
		AreEqual("/home/cedx/lcov.net/func2.cs", report.SourceFiles[2].Path);

		var branches = report.SourceFiles[1].Branches!;
		AreEqual(4, branches.Found);
		AreEqual(4, branches.Hit);
		HasCount(4, branches.Data);
		AreEqual(8, branches.Data[0].LineNumber);

		var functions = report.SourceFiles[1].Functions!;
		AreEqual(1, functions.Found);
		AreEqual(1, functions.Hit);
		HasCount(1, functions.Data);
		AreEqual("func1", functions.Data[0].FunctionName);

		var lines = report.SourceFiles[1].Lines!;
		AreEqual(9, lines.Found);
		AreEqual(9, lines.Hit);
		HasCount(9, lines.Data);
		AreEqual("5kX7OTfHFcjnS98fjeVqNA", lines.Data[0].Checksum);

		Throws<FormatException>(() => Report.Parse("TN:Example"));
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
