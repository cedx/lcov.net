# LCOV Parsing

## .NET/C#
The `Report.Parse()` static method parses a [LCOV](https://github.com/linux-test-project/lcov) coverage report provided as string,
and creates a `Report` instance giving detailed information about this coverage report:

```cs
using Belin.Lcov;
using System;
using System.IO;
using System.Text.Json;

try {
  var report = Report.Parse(File.ReadAllText("/path/to/lcov.info"));
  Console.WriteLine($"The coverage report contains {report.SourceFiles.Count} source files:");
  Console.WriteLine(JsonSerializer.Serialize(report, new JsonSerializerOptions {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
  }));
}
catch (FormatException e) {
  Console.Error.WriteLine(e.Message);
}
```

> [!NOTE]
> A `FormatException` is thrown if any error occurred while parsing the coverage report.  
> You can also use the convenient `Report.TryParse()` method to avoid the exception handling.

## PowerShell
The `ConvertFrom-LcovInfo` cmdlet parses a [LCOV](https://github.com/linux-test-project/lcov) info file,
and creates a `Report` instance giving detailed information about this coverage report:

```pwsh
Import-Module Lcov

$report = ConvertFrom-LcovInfo "/path/to/lcov.info"
Write-Output "The coverage report contains $($report.SourceFiles.Count) source files:"
Write-Output (ConvertTo-Json $report -Depth 5)
```

> [!NOTE]
> A non-terminating error is triggered if any error occurred while parsing the coverage report.  
> The cmdlet supports the [-ErrorAction](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_commonparameters#-erroraction) common parameter.

## Output
Converting the `Report` instance to [JSON](https://www.json.org) format will return a structure like this:

```json
{
  "testName": "Example",
  "sourceFiles": [
    {
      "path": "/home/cedx/lcov.net/fixture.cs",
      "branches": {
        "found": 0,
        "hit": 0,
        "data": []
      },
      "functions": {
        "found": 1,
        "hit": 1,
        "data": [
          {"functionName": "main", "lineNumber": 4, "executionCount": 2}
        ]
      },
      "lines": {
        "found": 2,
        "hit": 2,
        "data": [
          {"lineNumber": 6, "executionCount": 2, "checksum": "PF4Rz2r7RTliO9u6bZ7h6g"},
          {"lineNumber": 9, "executionCount": 2, "checksum": "y7GE3Y4FyXCeXcrtqgSVzw"}
        ]
      }
    }
  ]
}
```
