using namespace Belin.Lcov
using namespace System.Diagnostics.CodeAnalysis

<#
.SYNOPSIS
	Creates a new branch coverage.
.OUTPUTS
	The newly created branch coverage.
#>
function New-BranchCoverage {
	[CmdletBinding()]
	[OutputType([Belin.Lcov.BranchCoverage])]
	[SuppressMessage("PSUseOutputTypeCorrectly", "")]
	param (
		# The coverage data.
		[ValidateNotNull()]
		[BranchData[]] $Data = @(),

		# The number of branches found.
		[ValidateRange("NonNegative")]
		[int] $Found,

		# The number of branches hit.
		[ValidateRange("NonNegative")]
		[int] $Hit
	)

	[BranchCoverage]@{
		Data = $Data
		Found = $Found
		Hit = $Hit
	}
}
