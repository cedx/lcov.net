using namespace Belin.Lcov

<#
.SYNOPSIS
	Creates a new report.
.OUTPUTS
	The newly created report.
#>
function New-Report {
	[CmdletBinding()]
	[OutputType([Belin.Lcov.Report])]
	param (
		# The test name.
		[Parameter(Mandatory, Position = 0)]
		[string] $TestName,

		# The source file list.
		[Parameter(Position = 1)]
		[ValidateNotNull()]
		[SourceFile[]] $SourceFiles = @()
	)

	[Report]::new($TestName, $SourceFiles)
}
