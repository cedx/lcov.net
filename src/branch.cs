namespace Belin.Lcov;

/// <summary>
/// Provides the coverage data of branches.
/// </summary>
/// <param name="found">The number of branches found.</param>
/// <param name="hit">The number of branches hit.</param>
/// <param name="data">The coverage data.</param>
public sealed class BranchCoverage(int found = 0, int hit = 0, IEnumerable<BranchData>? data = null) {

	/// <summary>
	/// The coverage data.
	/// </summary>
	public IList<BranchData> Data { get; set; } = [.. data ?? []];

	/// <summary>
	/// The number of branches found.
	/// </summary>
	public int Found { get; set; } = found;

	/// <summary>
	/// The number of branches hit.
	/// </summary>
	public int Hit { get; set; } = hit;

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() {
		return string.Join('\n', [
			.. Data.Select(item => item.ToString()),
			$"{Token.BranchesFound}:{Found}",
			$"{Token.BranchesHit}:{Hit}"
		]);
	}
}

/// <summary>
/// Provides details for branch coverage.
/// </summary>
/// <param name="LineNumber">The line number.</param>
/// <param name="BlockNumber">The block number.</param>
/// <param name="BranchNumber">The branch number.</param>
/// <param name="Taken">A number indicating how often this branch was taken.</param>
public sealed record BranchData(int LineNumber = 0, int BlockNumber = 0, int BranchNumber = 0, int Taken = 0) {

	/// <summary>
	/// Returns a string representation of this object.
	/// </summary>
	/// <returns>The string representation of this object.</returns>
	public override string ToString() {
		var value = $"{Token.BranchData}:{LineNumber},{BlockNumber},{BranchNumber}";
		return Taken > 0 ? $"{value},{Taken}" : $"{value},-";
	}
}
