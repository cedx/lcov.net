namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Creates new branch data.
/// </summary>
[Cmdlet(VerbsCommon.New, "BranchData"), OutputType(typeof(BranchData))]
public class NewBranchDataCommand: Cmdlet {

	/// <summary>
	/// The block number.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int BlockNumber { get; set; }

	/// <summary>
	/// The branch number.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int BranchNumber { get; set; }

	/// <summary>
	/// The line number.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int LineNumber { get; set; }

	/// <summary>
	/// A number indicating how often this branch was taken.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public int Taken { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new BranchData {
		BlockNumber = BlockNumber,
		BranchNumber = BranchNumber,
		LineNumber = LineNumber,
		Taken = Taken
	});
}
