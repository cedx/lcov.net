using namespace Belin.Lcov

<#
.SYNOPSIS
	Creates new line data.
.OUTPUTS
	The newly created line data.
#>
function New-LineData {
	[CmdletBinding()]
	[OutputType([Belin.Lcov.LineData])]
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
