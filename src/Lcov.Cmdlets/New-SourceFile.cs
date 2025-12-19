namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Creates a new source file.
/// </summary>
[Cmdlet(VerbsCommon.New, "SourceFile"), OutputType(typeof(SourceFile))]
public class NewSourceFileCommand: Cmdlet {

	/// <summary>
	/// The branch coverage.
	/// </summary>
	[Parameter]
	public BranchCoverage? Branches { get; set; }
	
	/// <summary>
	/// The function coverage.
	/// </summary>
	[Parameter]
	public FunctionCoverage? Functions { get; set; }

	/// <summary>
	/// The line coverage.
	/// </summary>
	[Parameter]
	public LineCoverage? Lines { get; set; }

	/// <summary>
	/// The path to the source file.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0)]
	public required string Path { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new SourceFile(Path) {
		Branches = Branches,
		Functions = Functions,
		Lines = Lines
	});
}
