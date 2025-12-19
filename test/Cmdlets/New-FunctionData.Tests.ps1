<#
.SYNOPSIS
	Tests the features of the `New-FunctionData` cmdlet.
#>
Describe "New-FunctionData" {
	BeforeAll {
		Import-Module "$PSScriptRoot/../../Lcov.psd1"
	}

	It "should return a format like 'FN:[LineNumber],[FunctionName]' when used as definition" {
		$data = New-LcovFunctionData -ExecutionCount 3 -FunctionName "main" -LineNumber 127
		$data.ToString($true) | Should -BeExactly "FN:127,main"
	}

	It "should return a format like 'FNDA:[ExecutionCount],[FunctionName]' when used as data" {
		$data = New-LcovFunctionData -ExecutionCount 3 -FunctionName "main" -LineNumber 127
		$data.ToString($false) | Should -BeExactly "FNDA:3,main"
	}
}
