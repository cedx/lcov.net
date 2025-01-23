namespace belin.lcov;

/// <summary>
/// Provides the list of tokens supported by the parser.
/// </summary>
public static class Token {

	/// <summary>
	/// The coverage data of a branch.
	/// </summary>
	public static readonly string BranchData = "BRDA";

	/// <summary>
	/// The number of branches found.
	/// </summary>
	public static readonly string BranchesFound = "BRF";

	/// <summary>
	/// The number of branches hit.
	/// </summary>
	public static readonly string BranchesHit = "BRH";

	/// <summary>
	/// The end of a section.
	/// </summary>
	public static readonly string EndOfRecord = "end_of_record";

	/// <summary>
	/// The coverage data of a function.
	/// </summary>
	public static readonly string FunctionData = "FNDA";

	/// <summary>
	/// A function name.
	/// </summary>
	public static readonly string FunctionName = "FN";

	/// <summary>
	/// The number of functions found.
	/// </summary>
	public static readonly string FunctionsFound = "FNF";

	/// <summary>
	/// The number of functions hit.
	/// </summary>
	public static readonly string FunctionsHit = "FNH";

	/// <summary>
	/// The coverage data of a line.
	/// </summary>
	public static readonly string LineData = "DA";

	/// <summary>
	/// The number of lines found.
	/// </summary>
	public static readonly string LinesFound = "LF";

	/// <summary>
	/// The number of lines hit.
	/// </summary>
	public static readonly string LinesHit = "LH";

	/// <summary>
	/// The path to a source file.
	/// </summary>
	public static readonly string SourceFile = "SF";

	/// <summary>
	/// A test name.
	/// </summary>
	public static readonly string TestName = "TN";
}
