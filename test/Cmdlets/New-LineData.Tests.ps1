<#
.SYNOPSIS
	Tests the features of the `New-LineData` cmdlet.
#>
Describe "New-LineData" {
	BeforeAll {
		Import-Module "$PSScriptRoot/../../Lcov.psd1"
	}

	It "should return a format like 'DA:[LineNumber],[ExecutionCount],[Checksum]'" {
		New-LcovLineData | Should -BeExactly "DA:0,0"
		New-LcovLineData -Checksum "ed076287532e86365e841e92bfc50d8c" -ExecutionCount 3 -LineNumber 127 | Should -BeExactly "DA:127,3,ed076287532e86365e841e92bfc50d8c"
	}
}
