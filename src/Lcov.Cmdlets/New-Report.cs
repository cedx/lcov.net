namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Creates a new report.
/// </summary>
[Cmdlet(VerbsCommon.New, "Report"), OutputType(typeof(Report))]
public class NewReportCommand: Cmdlet {

	/// <summary>
	/// The test name.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0)]
	public required string TestName { get; set; }

	/// <summary>
	/// The source file list.
	/// </summary>
	[Parameter(Position = 1)]
	public SourceFile[] SourceFiles { get; set; } = [];

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new Report(TestName, SourceFiles));
}
