namespace belin.lcov;

using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

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
	/// Parses the specified coverage data in LCOV format.
	/// </summary>
	/// <param name="coverage">The coverage data.</param>
	/// <returns>The resulting coverage report.</returns>
	/// <exception cref="FormatException">A parsing error occurred.</exception>
	public static Report Parse(string coverage) {
		var offset = 0;
		var report = new Report(string.Empty);
		var sourceFile = new SourceFile(path: "");

		foreach (var line in new Regex(@"\r?\n").Split(coverage)) {
			offset++;
			if (string.IsNullOrWhiteSpace(line)) continue;

			var parts = line.Trim().Split(':');
			if (parts.Length < 2 && parts[0] != Token.EndOfRecord) throw new FormatException($"Invalid token format at line {offset}.");

			var data = string.Join(':', parts[1..]).Split(',');
			var token = parts[0];
			switch (token) {
				case var _ when token == Token.TestName: if (report.TestName.Length == 0) report.TestName = data[0]; break;
				case var _ when token == Token.EndOfRecord: report.SourceFiles.Add(sourceFile); break;

				default: throw new FormatException($"Unknown token at line {offset}.");
			}
		}

		return report.SourceFiles.Count > 0 ? report : throw new FormatException("The coverage data is empty or invalid.");
	}

	/// <summary>
	/// Parses the specified coverage data in LCOV format.
	/// </summary>
	/// <param name="coverage">The coverage data.</param>
	/// <param name="report">The resulting coverage report, or `null` if an error occurred.</param>
	/// <returns>Value indicating whether the parsing was successfull.</returns>
	public static bool TryParse(string coverage, [NotNullWhen(true)] out Report? report) {
		try {
			report = Parse(coverage);
			return true;
		}
		catch {
			report = null;
			return false;
		}
	}

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
