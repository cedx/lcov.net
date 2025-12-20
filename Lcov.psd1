@{
	DefaultCommandPrefix = "Lcov"
	ModuleVersion = "2.1.0"
	PowerShellVersion = "7.5"
	RootModule = "bin/Belin.Lcov.Cmdlets.dll"

	Author = "Cédric Belin <cedx@outlook.com>"
	CompanyName = "Cedric-Belin.fr"
	Copyright = "© Cédric Belin"
	Description = "Parse and format to LCOV your code coverage reports."
	GUID = "158416ed-ea32-4bcf-ac5d-8c555ad917e5"

	AliasesToExport = @()
	FunctionsToExport = @()
	VariablesToExport = @()

	CmdletsToExport = @(
		"ConvertFrom-Info"
		"New-BranchCoverage"
		"New-BranchData"
		"New-FunctionCoverage"
		"New-FunctionData"
		"New-LineCoverage"
		"New-LineData"
		"New-Report"
		"New-SourceFile"
	)

	RequiredAssemblies = @(
		"bin/Belin.Lcov.dll"
	)

	PrivateData = @{
		PSData = @{
			LicenseUri = "https://github.com/cedx/lcov.net/blob/main/License.md"
			ProjectUri = "https://github.com/cedx/lcov.net"
			ReleaseNotes = "https://github.com/cedx/lcov.net/releases"
			Tags = "coverage", "formatter", "lcov", "parser", "test", "writer"
		}
	}
}
