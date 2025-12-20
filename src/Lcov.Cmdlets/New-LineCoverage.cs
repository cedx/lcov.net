namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Creates a new line coverage.
/// </summary>
[Cmdlet(VerbsCommon.New, "LineCoverage"), OutputType(typeof(LineCoverage))]
public class NewLineCoverageCommand: Cmdlet {

	/// <summary>
	/// The coverage data.
	/// </summary>
	[Parameter]
	public LineData[] Data { get; set; } = [];

	/// <summary>
	/// The number of lines found.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Found { get; set; }

	/// <summary>
	/// The number of lines hit.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Hit { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new LineCoverage {
		Data = Data,
		Found = Found,
		Hit = Hit
	});
}
