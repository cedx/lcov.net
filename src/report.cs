namespace belin.lcov;

/// <summary>
/// Represents a trace file, that is a coverage report.
/// </summary>
/// <param name="testName">The test name.</param>
/// <param name="sourceFiles">The source file list.</param>
public class Report(string testName, IEnumerable<SourceFile>? sourceFiles = null) {

	/// <summary>
	/// The source file list.
	/// </summary>
	public IList<SourceFile> SourceFiles { get; set; } = [.. sourceFiles ?? []];

	/// <summary>
	/// The test name.
	/// </summary>
	public string TestName { get; set; } = testName;

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() {
		return string.Join('\n', [
			..TestName.Length > 0 ? [$"{Token.TestName}:{TestName}"] : Array.Empty<string>(),
			..SourceFiles.Select(item => item.ToString())
		]);
	}
}
