namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Creates new function data.
/// </summary>
[Cmdlet(VerbsCommon.New, "FunctionData"), OutputType(typeof(FunctionData))]
public class NewFunctionDataCommand: Cmdlet {
		
	/// <summary>
	/// The execution count.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int ExecutionCount { get; set; }

	/// <summary>
	/// The function name.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0)]
	public required string FunctionName { get; set; } 

	/// <summary>
	/// The line number of the function start.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int LineNumber { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new FunctionData {
		ExecutionCount = ExecutionCount,
		FunctionName = FunctionName,
		LineNumber = LineNumber
	});
}
