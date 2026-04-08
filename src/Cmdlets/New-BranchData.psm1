using namespace Belin.Lcov
using namespace System.Diagnostics.CodeAnalysis

<#
.SYNOPSIS
	Creates new branch data.
.OUTPUTS
	The newly created branch data.
#>
function New-BranchData {
	[CmdletBinding()]
	[OutputType([Belin.Lcov.BranchData])]
	[SuppressMessage("PSUseShouldProcessForStateChangingFunctions", "")]
	param (
		# The block number.
		[ValidateRange("NonNegative")]
		[int] $BlockNumber,

		# The branch number.
		[ValidateRange("NonNegative")]
		[int] $BranchNumber,

		# The line number.
		[ValidateRange("NonNegative")]
		[int] $LineNumber,

		# A number indicating how often this branch was taken.
		[ValidateRange("NonNegative")]
		[int] $Taken
	)

	[BranchData]@{
		BlockNumber = $BlockNumber
		BranchNumber = $BranchNumber
		LineNumber = $LineNumber
		Taken = $Taken
	}
}
