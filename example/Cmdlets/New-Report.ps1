<#
.SYNOPSIS
	Formats coverage data as LCOV report.
#>
Import-Module Lcov

$functionCoverage = New-LcovFunctionCoverage -Found 1 -Hit 1
$lineCoverage = New-LcovLineCoverage -Found 2 -Hit 1 -Data @(
	New-LcovLineData -LineNumber 6 -ExecutionCount 2 -Checksum "PF4Rz2r7RTliO9u6bZ7h6g"
	New-LcovLineData -LineNumber 7 -ExecutionCount 2 -Checksum "yGMB6FhEEAd8OyASe3Ni1w"
)

$sourceFile = New-LcovSourceFile "/home/cedx/lcov.net/fixture.cs" -Functions $functionCoverage -Lines $lineCoverage
$report = New-LcovReport -TestName "Example" -SourceFiles $sourceFile
Write-Output $report.ToString()
