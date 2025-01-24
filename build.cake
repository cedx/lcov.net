var release = HasArgument("r") || HasArgument("release");
var target = Argument<string>("t", null) ?? Argument("target", "default");
var version = "1.0.0";

Task("build")
	.Description("Builds the project.")
	.Does(() => DotNetBuild("lcov.sln", new DotNetBuildSettings { Configuration = release ? "Release" : "Debug" }));

Task("clean")
	.Description("Deletes all generated files.")
	.Does(() => EnsureDirectoryDoesNotExist("bin"))
	.DoesForEach(GetDirectories("src/**/obj"), dir => EnsureDirectoryDoesNotExist(dir, new DeleteDirectorySettings { Recursive = true }))
	.Does(() => CleanDirectory("var", fileSystemInfo => fileSystemInfo.Path.Segments[^1] != ".gitkeep"));

Task("format")
	.Description("Formats the source code.")
	.Does(() => DotNetFormat("lcov.sln"));

Task("publish")
	.Description("Publishes the package.")
	.WithCriteria(release)
	.IsDependentOn("default")
	.DoesForEach(["tag", "push origin"], action => StartProcess("git", $"{action} v{version}"));

Task("default")
	.Description("The default task.")
	.IsDependentOn("clean")
	.IsDependentOn("build");

RunTarget(target);
