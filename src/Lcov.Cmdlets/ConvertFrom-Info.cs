namespace Belin.Lcov.Cmdlets;

/// <summary>
/// Converts the contents of a LCOV info file into a <see cref="Report"/> object.
/// </summary>
[Cmdlet(VerbsData.ConvertFrom, "Info", DefaultParameterSetName = nameof(Path)), OutputType(typeof(Report))]
public class ConvertFromInfoCommand: PSCmdlet {

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
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() {
		var paths = ParameterSetName == nameof(LiteralPath)
			? LiteralPath.Select(GetUnresolvedProviderPathFromPSPath)
			: Path.SelectMany(path => GetResolvedProviderPathFromPSPath(path, out _));

		foreach (var path in paths)
			try { WriteObject(File.ReadAllText(path)); }
			catch (FormatException e) {
				WriteError(new ErrorRecord(e, "ConvertFromInfo:FormatException", ErrorCategory.InvalidData, null));
				WriteObject(null);
			}
	}
}
