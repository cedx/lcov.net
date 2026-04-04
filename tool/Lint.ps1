"Performing the static analysis of source code..."
Import-Module PSScriptAnalyzer
$PSScriptRoot, "test" | Invoke-ScriptAnalyzer -Recurse
Test-ModuleManifest Lcov.psd1 | Out-Null
