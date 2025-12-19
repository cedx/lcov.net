<#
.SYNOPSIS
	Tests the features of the `New-FunctionCoverage` cmdlet.
#>
Describe "New-FunctionCoverage" {
	BeforeAll {
		Import-Module "$PSScriptRoot/../../Lcov.psd1"
	}

	It "should return a format like 'FNF:[Found]\nFNH:[Hit]'" {
		$data = New-LcovFunctionData -ExecutionCount 3 -FunctionName "main" -LineNumber 127
		New-LcovFunctionCoverage | Should -BeExactly "FNF:0`nFNH:0"
		New-LcovFunctionCoverage -Data @($data) -Found 23 -Hit 11 | Should -BeExactly "FN:127,main`nFNDA:3,main`nFNF:23`nFNH:11"
	}
}
