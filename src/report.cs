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
				case Token.TestName: if (string.IsNullOrWhiteSpace(report.TestName)) report.TestName = data[0]; break;
				case Token.EndOfRecord: report.SourceFiles.Add(sourceFile); break;

				case Token.BranchData:
					if (data.Length < 4) throw new FormatException($"Invalid branch data at line #{offset}.");
					sourceFile.Branches?.Data.Add(new BranchData {
						BlockNumber = int.Parse(data[1]),
						BranchNumber = int.Parse(data[2]),
						LineNumber = int.Parse(data[0]),
						Taken = data[3] == "-" ? 0 : int.Parse(data[3])
					});
					break;

				case Token.FunctionData:
					if (data.Length < 2) throw new FormatException($"Invalid function data at line #{offset}.");
					if (sourceFile.Functions is not null) {
						var items = sourceFile.Functions.Data;
						for (var i = 0; i < items.Count; i++) items[i] = items[i] with { ExecutionCount = int.Parse(data[0]) };
					}
					break;

				case Token.FunctionName:
					if (data.Length < 2) throw new FormatException($"Invalid function name at line #{offset}.");
					sourceFile.Functions?.Data.Add(new FunctionData { FunctionName = data[1], LineNumber = int.Parse(data[0]) });
					break;

				case Token.LineData:
					if (data.Length < 2) throw new FormatException($"Invalid line data at line #{offset}.");
					sourceFile.Lines?.Data.Add(new LineData {
						Checksum = data.Length >= 3 ? data[2] : "",
						ExecutionCount = int.Parse(data[1]),
						LineNumber = int.Parse(data[0])
					});
					break;

				case Token.SourceFile:
					sourceFile = new SourceFile(data[0]) {
						Branches = new BranchCoverage(),
						Functions = new FunctionCoverage(),
						Lines = new LineCoverage()
					};
					break;

				case Token.BranchesFound: if (sourceFile.Branches is not null) sourceFile.Branches.Found = int.Parse(data[0]); break;
				case Token.BranchesHit: if (sourceFile.Branches is not null) sourceFile.Branches.Hit = int.Parse(data[0]); break;
				case Token.FunctionsFound: if (sourceFile.Functions is not null) sourceFile.Functions.Found = int.Parse(data[0]); break;
				case Token.FunctionsHit: if (sourceFile.Functions is not null) sourceFile.Functions.Hit = int.Parse(data[0]); break;
				case Token.LinesFound: if (sourceFile.Lines is not null) sourceFile.Lines.Found = int.Parse(data[0]); break;
				case Token.LinesHit: if (sourceFile.Lines is not null) sourceFile.Lines.Hit = int.Parse(data[0]); break;
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
			.. string.IsNullOrWhiteSpace(TestName) ? Array.Empty<string>() : [$"{Token.TestName}:{TestName}"],
			.. SourceFiles.Select(item => item.ToString())
		]);
	}
}
