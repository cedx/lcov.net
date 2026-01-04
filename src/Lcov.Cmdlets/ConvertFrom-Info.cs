namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Converts the contents of a LCOV info file into a <see cref="Report"/> object.
/// </summary>
[Cmdlet(VerbsData.ConvertFrom, "Info", DefaultParameterSetName = nameof(Path)), OutputType(typeof(Report))]
public class ConvertFromInfoCommand: PSCmdlet {

	/// <summary>
	/// A pattern used to filter the list of files to be processed.
	/// </summary>
	[Parameter]
	public string Filter { get; set; } = "";

	/// <summary>
	/// The path to the LCOV file to convert.
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = nameof(LiteralPath))]
	public required string[] LiteralPath { get; set; }

	/// <summary>
	/// The path to the LCOV file to convert.
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = nameof(Path), Position = 0, ValueFromPipeline = true), SupportsWildcards]
	public required string[] Path { get; set; }

	/// <summary>
	/// Value indicating whether to process the input path recursively.
	/// </summary>
	[Parameter]
	public SwitchParameter Recurse { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() {
		using var script = PowerShell.Create(RunspaceMode.CurrentRunspace).AddCommand("Get-ChildItem");
		if (ParameterSetName == nameof(LiteralPath)) script.AddParameter(nameof(LiteralPath), LiteralPath);
		else script.AddParameter(nameof(Path), Path);

		script.AddParameter("File");
		if (Filter.Length > 0) script.AddParameter(nameof(Filter), Filter);
		if (Recurse) script.AddParameter(nameof(Recurse));

		var files = script.Invoke<FileInfo>();
		if (script.HadErrors) {
			ThrowTerminatingError(script.Streams.Error.First());
			return;
		}

		foreach (var file in files) {
			try { WriteObject(Report.Parse(File.ReadAllText(file.FullName))); }
			catch (FormatException e) {
				WriteError(new ErrorRecord(e, "ConvertFrom-Info:FormatException", ErrorCategory.InvalidData, null));
				WriteObject(null);
			}
		}
	}
}
