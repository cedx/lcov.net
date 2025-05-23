namespace Belin.Lcov;

/// <summary>
/// Provides the coverage data of lines.
/// </summary>
/// <param name="found">The number of lines found.</param>
/// <param name="hit">The number of lines hit.</param>
/// <param name="data">The coverage data.</param>
public sealed class LineCoverage(int found = 0, int hit = 0, IEnumerable<LineData>? data = null) {

	/// <summary>
	/// The coverage data.
	/// </summary>
	public IList<LineData> Data { get; set; } = [.. data ?? []];

	/// <summary>
	/// The number of lines found.
	/// </summary>
	public int Found { get; set; } = found;

	/// <summary>
	/// The number of lines hit.
	/// </summary>
	public int Hit { get; set; } = hit;

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() => string.Join('\n', [
		.. Data.Select(item => item.ToString()),
		$"{Tokens.LinesFound}:{Found}",
		$"{Tokens.LinesHit}:{Hit}"
	]);
}
