namespace belin.lcov;

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
	public override string ToString(bool asDefinition = false) {
		var token = asDefinition ? Token.FunctionName : Token.FunctionData;
		var count = asDefinition ? LineNumber : ExecutionCount;
		return $"{token}:{count},{FunctionName}";
	}
}
