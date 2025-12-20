namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Creates a new function coverage.
/// </summary>
[Cmdlet(VerbsCommon.New, "FunctionCoverage"), OutputType(typeof(FunctionCoverage))]
public class NewFunctionCoverageCommand: Cmdlet {

	/// <summary>
	/// The coverage data.
	/// </summary>
	[Parameter]
	public FunctionData[] Data { get; set; } = [];

	/// <summary>
	/// The number of functions found.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Found { get; set; }

	/// <summary>
	/// The number of functions hit.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Hit { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new FunctionCoverage {
		Data = Data,
		Found = Found,
		Hit = Hit
	});
}
