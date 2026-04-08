using namespace Belin.Lcov

<#
.SYNOPSIS
	Creates a new function coverage.
.OUTPUTS
	The newly created function coverage.
#>
function New-FunctionCoverage {
	[CmdletBinding()]
	[OutputType([Belin.Lcov.FunctionCoverage])]
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
