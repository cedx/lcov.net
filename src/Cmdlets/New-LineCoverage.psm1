using namespace Belin.Lcov
using namespace System.Diagnostics.CodeAnalysis

<#
.SYNOPSIS
	Creates a new line coverage.
.OUTPUTS
	The newly created line coverage.
#>
function New-LineCoverage {
	[CmdletBinding()]
	[OutputType([Belin.Lcov.LineCoverage])]
	[SuppressMessage("PSUseOutputTypeCorrectly", "")]
	param (
		# The coverage data.
		[ValidateNotNull()]
		[LineData[]] $Data = @(),

		# The number of lines found.
		[ValidateRange("NonNegative")]
		[int] $Found,

		# The number of lines hit.
		[ValidateRange("NonNegative")]
		[int] $Hit
	)

	[LineCoverage]@{
		Data = $Data
		Found = $Found
		Hit = $Hit
	}
}
