using Belin.Lcov;
using System;
using System.IO;
using System.Text.Json;

// Parses a LCOV report to coverage data.
try {
	var report = Report.Parse(File.ReadAllText("/path/to/lcov.info"));
	Console.WriteLine($"The coverage report contains {report.SourceFiles.Count} source files:");

	var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
	Console.WriteLine(JsonSerializer.Serialize(report, options));
}
catch (FormatException error) {
	Console.WriteLine(error.Message);
}
