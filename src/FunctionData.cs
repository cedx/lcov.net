namespace Belin.Lcov;

/// <summary>
/// Provides details for function coverage.
/// </summary>
/// <param name="FunctionName">The function name.</param>
/// <param name="LineNumber">The line number of the function start.</param>
/// <param name="ExecutionCount">The execution count.</param>
public sealed record FunctionData(string FunctionName = "", int LineNumber = 0, int ExecutionCount = 0) {

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <param name="asDefinition">Whether to return the function definition instead of its data.</param>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() => ToString(false);

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <param name="asDefinition">Whether to return the function definition instead of its data.</param>
	/// <returns>The string representation of this object.</returns>
	public string ToString(bool asDefinition) {
		var token = asDefinition ? Tokens.FunctionName : Tokens.FunctionData;
		var count = asDefinition ? LineNumber : ExecutionCount;
		return $"{token}:{count},{FunctionName}";
	}
}
