var debug = Argument("configuration", "Debug");
var task = Argument("task", "default");

// Builds the project.
Task("build").Does(() => {
	DotNetBuild("lcov.sln", new DotNetBuildSettings { Configuration = configuration });
});

// Deletes all generated files.

// Run the requested task.
RunTarget(task);
