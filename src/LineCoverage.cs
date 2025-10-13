namespace Belin.Lcov;

/// <summary>
/// Provides the coverage data of lines.
/// </summary>
public sealed class LineCoverage {

	/// <summary>
	/// The coverage data.
	/// </summary>
	public IList<LineData> Data { get; set; } = [];

	/// <summary>
	/// The number of lines found.
	/// </summary>
	public int Found { get; set; }

	/// <summary>
	/// The number of lines hit.
	/// </summary>
	public int Hit { get; set; }

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

/// <summary>
/// Provides details for line coverage.
/// </summary>
/// <param name="LineNumber">The line number.</param>
/// <param name="ExecutionCount">The execution count.</param>
/// <param name="Checksum">The data checksum.</param>
public sealed record LineData(int LineNumber = 0, int ExecutionCount = 0, string Checksum = "") {

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() {
		var value = $"{Tokens.LineData}:{LineNumber},{ExecutionCount}";
		return string.IsNullOrWhiteSpace(Checksum) ? value : $"{value},{Checksum}";
	}
}
