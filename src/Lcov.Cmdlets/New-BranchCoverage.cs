namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Creates a new branch coverage.
/// </summary>
[Cmdlet(VerbsCommon.New, "BranchCoverage"), OutputType(typeof(BranchCoverage))]
public class NewBranchCoverageCommand: Cmdlet {
	
	/// <summary>
	/// The coverage data.
	/// </summary>
	[Parameter]
	public BranchData[] Data { get; set; } = [];

	/// <summary>
	/// The number of branches found.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Found { get; set; }

	/// <summary>
	/// The number of branches hit.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Hit { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new BranchCoverage {
		Data = Data,
		Found = Found,
		Hit = Hit
	});
}
