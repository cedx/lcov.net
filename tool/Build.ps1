Write-Host "Building the project..."
$configuration = $release ? "Release" : "Debug"
dotnet build Lcov.slnx --configuration=$configuration
