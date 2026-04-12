using namespace Belin.Lcov
using namespace System.Diagnostics.CodeAnalysis

<#
.SYNOPSIS
	Creates a new function coverage.
.OUTPUTS
	The newly created function coverage.
#>
function New-FunctionCoverage {
	[CmdletBinding()]
	[OutputType([Belin.Lcov.FunctionCoverage])]
	[SuppressMessage("PSUseOutputTypeCorrectly", "")]
	param (
		# The coverage data.
		[ValidateNotNull()]
		[FunctionData[]] $Data = @(),

		# The number of functions found.
		[ValidateRange("NonNegative")]
		[int] $Found,

		# The number of functions hit.
		[ValidateRange("NonNegative")]
		[int] $Hit
	)

	[FunctionCoverage]@{
		Data = $Data
		Found = $Found
		Hit = $Hit
	}
}
