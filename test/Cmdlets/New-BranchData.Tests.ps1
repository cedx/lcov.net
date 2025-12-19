<#
.SYNOPSIS
	Tests the features of the `New-BranchData` cmdlet.
#>
Describe "New-BranchData" {
	BeforeAll {
		Import-Module "$PSScriptRoot/../../Lcov.psd1"
	}

	It "should return a format like 'BRDA:[LineNumber],[BlockNumber],[BranchNumber],[Taken]'" {
		New-LcovBranchData | Should -BeExactly "BRDA:0,0,0,-"
		New-LcovBranchData -BlockNumber 3 -BranchNumber 2 -LineNumber 127 -Taken 1 | Should -BeExactly "BRDA:127,3,2,1"
	}
}
