namespace Belin.Lcov;

/// <summary>
/// Provides the coverage data of functions.
/// </summary>
/// <param name="found">The number of functions found.</param>
/// <param name="hit">The number of functions hit.</param>
/// <param name="data">The coverage data.</param>
public sealed class FunctionCoverage(int found = 0, int hit = 0, IEnumerable<FunctionData>? data = null) {

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

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() => string.Join('\n', [
		.. Data.Select(item => item.ToString(asDefinition: true)),
		.. Data.Select(item => item.ToString(asDefinition: false)),
		$"{Token.FunctionsFound}:{Found}",
		$"{Token.FunctionsHit}:{Hit}"
	]);
}
