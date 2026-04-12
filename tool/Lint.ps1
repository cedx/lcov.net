"Performing the static analysis of source code..."
Import-Module PSScriptAnalyzer
$PSScriptRoot, "src", "test" | Invoke-ScriptAnalyzer -ExcludeRule PSUseShouldProcessForStateChangingFunctions -Recurse
Test-ModuleManifest Lcov.psd1 | Out-Null
