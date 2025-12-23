using namespace System.Diagnostics.CodeAnalysis

<#
.SYNOPSIS
	Tests the features of the `ConvertFrom-Info` cmdlet.
#>
Describe "ConvertFrom-Info" {
	BeforeAll {
		Import-Module "$PSScriptRoot/../../Lcov.psd1"
		[SuppressMessage("PSUseDeclaredVarsMoreThanAssignments", "")]
		$report = ConvertFrom-LcovInfo "$PSScriptRoot/../../res/*.info"
	}

	It "should have a test name" {
		$report.TestName | Should -BeExactly "Example"
	}

	It "should contain three source files" {
		$report.SourceFiles | Should -HaveCount 3
		$report.SourceFiles[0].Path | Should -BeExactly "/home/cedx/lcov.net/fixture.cs"
		$report.SourceFiles[1].Path | Should -BeExactly "/home/cedx/lcov.net/func1.cs"
		$report.SourceFiles[2].Path | Should -BeExactly "/home/cedx/lcov.net/func2.cs"
	}

	It "should have detailed branch coverage" {
		$branches = $report.SourceFiles[1].Branches
		$branches.Found | Should -Be 4
		$branches.Hit | Should -Be 4
		$branches.Data | Should -HaveCount 4
		$branches.Data[0].LineNumber | Should -Be 8
	}

	It "should have detailed function coverage" {
		$functions = $report.SourceFiles[1].Functions
		$functions.Found | Should -Be 1
		$functions.Hit | Should -Be 1
		$functions.Data | Should -HaveCount 1
		$functions.Data[0].FunctionName | Should -BeExactly "func1"
	}

	It "should have detailed line coverage" {
		$lines = $report.SourceFiles[1].Lines
		$lines.Found | Should -Be 9
		$lines.Hit | Should -Be 9
		$lines.Data | Should -HaveCount 9
		$lines.Data[0].Checksum | Should -BeExactly "5kX7OTfHFcjnS98fjeVqNA"
	}
}
