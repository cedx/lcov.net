<#
.SYNOPSIS
	Parses a LCOV report to coverage data.
#>
Import-Module Lcov

$report = ConvertFrom-LcovInfo "/path/to/lcov.info"
Write-Output "The coverage report contains $($report.SourceFiles.Count) source files:"
Write-Output (ConvertTo-Json $report -Depth 5)
