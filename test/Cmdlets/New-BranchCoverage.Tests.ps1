<#
.SYNOPSIS
	Tests the features of the `New-BranchCoverage` cmdlet.
#>
Describe "New-BranchCoverage" {
	BeforeAll {
		Import-Module "$PSScriptRoot/../../Lcov.psd1"
	}

	It "should return a format like 'BRF:[Found]\nBRH:[Hit]'" {
		$data = New-LcovBranchData -BlockNumber 3 -BranchNumber 2 -LineNumber 127 -Taken 1
		New-LcovBranchCoverage | Should -BeExactly "BRF:0`nBRH:0"
		New-LcovBranchCoverage -Data $data -Found 23 -Hit 11 | Should -BeExactly "$data`nBRF:23`nBRH:11"
	}
}
