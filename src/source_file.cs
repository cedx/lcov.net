namespace belin.lcov;

/// <summary>
/// Provides the coverage data of a source file.
/// </summary>
/// <param name="path">The path to the source file.</param>
/// <param name="functions">The function coverage.</param>
/// <param name="branches">The branch coverage.</param>
/// <param name="lines">The line coverage.</param>
public class SourceFile(string path = "", FunctionCoverage? functions = null, BranchCoverage? branches = null, LineCoverage? lines = null) {

	/// <summary>
	/// The branch coverage.
	/// </summary>
	BranchCoverage? Branches { get; set; } = branches;

	/// <summary>
	/// The function coverage.
	/// </summary>
	FunctionCoverage? Functions { get; set; } = functions;

	/// <summary>
	/// The line coverage.
	/// </summary>
	LineCoverage? Lines { get; set; } = lines;

	/// <summary>
	/// The path to the source file.
	/// </summary>
	string Path { get; set; } = path;

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() {
		List<string> output = [$"{Token.SourceFile}:{Path}"];
		if (Functions is not null) output.Add(Functions.ToString());
		if (Branches is not null) output.Add(Branches.ToString());
		if (Lines is not null) output.Add(Lines.ToString());
		output.Add(Token.EndOfRecord);
		return string.Join('\n', output);
	}
}
