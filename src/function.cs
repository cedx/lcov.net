namespace belin.lcov;

/// <summary>
/// Provides the coverage data of functions.
/// </summary>
/// <param name="found">The number of functions found.</param>
/// <param name="hit">The number of functions hit.</param>
/// <param name="data">The coverage data.</param>
public class FunctionCoverage(int found = 0, int hit = 0, IEnumerable<FunctionData>? data = null) {

	/// <summary>
	/// The coverage data.
	/// </summary>
	public IList<FunctionData> Data { get; set; } = [.. data ?? []];

	/// <summary>
	/// The number of functions found.
	/// </summary>
	public int Found { get; set; } = found;

	/// <summary>
	/// The number of functions hit.
	/// </summary>
	public int Hit { get; set; } = hit;
}

/// <summary>
/// Provides details for function coverage.
/// </summary>
/// <param name="FunctionName">The function name.</param>
/// <param name="LineNumber">The line number of the function start.</param>
/// <param name="ExecutionCount">The execution count.</param>
public record struct FunctionData(string FunctionName = "", int LineNumber = 0, int ExecutionCount = 0) {

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <param name="asDefinition">Whether to return the function definition instead of its data.</param>
	/// <returns>The string representation of this object.</returns>
	public override readonly string ToString() => ToString(false);

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <param name="asDefinition">Whether to return the function definition instead of its data.</param>
	/// <returns>The string representation of this object.</returns>
	public readonly string ToString(bool asDefinition) {
		var token = asDefinition ? Token.FunctionName : Token.FunctionData;
		var count = asDefinition ? LineNumber : ExecutionCount;
		return $"{token}:{count},{FunctionName}";
	}
}
