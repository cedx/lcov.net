using namespace Belin.Lcov
using namespace System.Diagnostics.CodeAnalysis

<#
.SYNOPSIS
	Creates new function data.
.OUTPUTS
	The newly created function data.
#>
function New-FunctionData {
	[CmdletBinding()]
	[OutputType([Belin.Lcov.FunctionData])]
	[SuppressMessage("PSUseShouldProcessForStateChangingFunctions", "")]
	param (
		# The function name.
		[Parameter(Mandatory, Position = 0)]
		[string] $FunctionName,

		# The execution count.
		[ValidateRange("NonNegative")]
		[int] $ExecutionCount,

		# The line number of the function start.
		[ValidateRange("NonNegative")]
		[int] $LineNumber
	)

	[FunctionData]@{
		ExecutionCount = $ExecutionCount
		FunctionName = $FunctionName
		LineNumber = $LineNumber
	}
}
