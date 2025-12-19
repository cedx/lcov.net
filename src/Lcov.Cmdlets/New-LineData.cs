namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Creates new line data.
/// </summary>
[Cmdlet(VerbsCommon.New, "LineData"), OutputType(typeof(LineData))]
public class NewLineDataCommand: Cmdlet {

	/// <summary>
	/// The data checksum.
	/// </summary>
	[Parameter]
	public string Checksum { get; set; } = "";
		
	/// <summary>
	/// The execution count.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int ExecutionCount { get; set; }

	/// <summary>
	/// The line number.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int LineNumber { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new LineData {
		Checksum = Checksum,
		ExecutionCount = ExecutionCount,
		LineNumber = LineNumber
	});
}
