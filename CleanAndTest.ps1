# CleanAndTestNet8.ps1
Write-Host "🚀 Starting clean & test process for .NET 8..."

# 1️⃣ Clear NuGet caches
Write-Host "🔹 Clearing NuGet caches..."
dotnet nuget locals all --clear

# 2️⃣ Remove bin and obj folders
Write-Host "🔹 Removing bin and obj folders..."
Get-ChildItem -Path . -Include bin,obj -Recurse -Force | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue

# 3️⃣ Ensure Microsoft.NET.Test.Sdk 17.14.1 (latest stable) in Tests project
Write-Host "🔹 Updating Microsoft.NET.Test.Sdk to latest compatible version..."
dotnet add .\ProactiView.Tests\ProactiView.Tests.csproj package Microsoft.NET.Test.Sdk --version 17.14.1

# 4️⃣ Optional: force reinstall Newtonsoft.Json in main project to match .NET 8
if (Test-Path ".\ProactiView\ProactiView.csproj") {
    Write-Host "🔹 Adding/updating Newtonsoft.Json for .NET 8..."
    dotnet add .\ProactiView\ProactiView.csproj package Newtonsoft.Json --version 13.0.3
}

# 5️⃣ Restore packages
Write-Host "🔹 Restoring NuGet packages..."
dotnet restore

# 6️⃣ Build solution targeting .NET 8
Write-Host "🔹 Building solution..."
dotnet build -f net8.0

# 7️⃣ Run tests targeting .NET 8 and skip testhost version conflicts
Write-Host "🔹 Running tests targeting .NET 8..."
dotnet test .\ProactiView.Tests\ProactiView.Tests.csproj -f net8.0 --no-build --logger "console;verbosity=detailed"

Write-Host "✅ Clean & test process for .NET 8 complete."
