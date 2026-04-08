using namespace Belin.Lcov
using namespace System.Diagnostics.CodeAnalysis

<#
.SYNOPSIS
	Creates new line data.
.OUTPUTS
	The newly created line data.
#>
function New-LineData {
	[CmdletBinding()]
	[OutputType([Belin.Lcov.LineData])]
	[SuppressMessage("PSUseShouldProcessForStateChangingFunctions", "")]
	param (
		# The data checksum.
		[ValidateNotNull()]
		[string] $Checksum = "",

		# The execution count.
		[ValidateRange("NonNegative")]
		[int] $ExecutionCount,

		# The line number.
		[ValidateRange("NonNegative")]
		[int] $LineNumber
	)

	[LineData]@{
		Checksum = $Checksum
		ExecutionCount = $ExecutionCount
		LineNumber = $LineNumber
	}
}
