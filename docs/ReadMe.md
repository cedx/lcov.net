# LCOV Reports for .NET
Parse and format [LCOV](https://github.com/linux-test-project/lcov) coverage reports,
in [C#](https://learn.microsoft.com/en-us/dotnet/csharp) and [PowerShell](https://learn.microsoft.com/en-us/powershell).
	
## Quick start
Install the latest version of **LCOV Reports for .NET** with your package manager:

```shell
# .NET with NuGet
dotnet add package Belin.Lcov

# PowerShell with PSResourceGet
Install-PSResource Lcov
```

For detailed instructions, see the [installation guide](Installation.md).

## Usage
This library provides a set of [C#](https://learn.microsoft.com/en-us/dotnet/csharp) classes representing a [LCOV](https://github.com/linux-test-project/lcov) coverage report and its data.  
The `Report` class, the main one, provides the parsing and formatting features.  

This library also provides a set of cmdlets for accessing these features via [PowerShell](https://learn.microsoft.com/en-us/powershell).  
For more details, please refer to the following pages:

- [Parse coverage data from a LCOV file](LcovParsing.md)
- [Format coverage data to the LCOV format](LcovFormatting.md)
