# CleanAndTest_FixTestHost.ps1
# Script om ProactiView-project schoon te maken, te herstellen, Newtonsoft.Json toe te voegen en tests uit te voeren.

Write-Host "🔹 Cleaning solution..."
dotnet clean

Write-Host "🔹 Restoring packages..."
dotnet restore

# 1️⃣ Ensure Newtonsoft.Json is installed in main project
if (Test-Path ".\ProactiView\ProactiView.csproj") {
    Write-Host "🔹 Adding/updating Newtonsoft.Json for .NET 8..."
    dotnet add .\ProactiView\ProactiView.csproj package Newtonsoft.Json --version 13.0.3
}

# 2️⃣ Ensure test project has latest xUnit & test SDK
if (Test-Path ".\ProactiView.Tests\ProactiView.Tests.csproj") {
    Write-Host "🔹 Ensuring test project packages are up to date..."
    dotnet add .\ProactiView.Tests\ProactiView.Tests.csproj package Microsoft.NET.Test.Sdk --version 17.10.0
    dotnet add .\ProactiView.Tests\ProactiView.Tests.csproj package xunit.runner.visualstudio --version 3.1.5
    dotnet add .\ProactiView.Tests\ProactiView.Tests.csproj package coverlet.collector --version 6.0.4
}

# 3️⃣ Restore again after any new packages
Write-Host "🔹 Restoring after package changes..."
dotnet restore

# 4️⃣ Run tests with detailed logger
Write-Host "🔹 Running tests..."
dotnet test --logger "console;verbosity=detailed"

Write-Host "✅ Done."

