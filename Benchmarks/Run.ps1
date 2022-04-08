dotnet build --configuration Release
dotnet run --configuration Release --filter LeetCode.Benchmark* --memory --exporters json --warmupCount 3 --minIterationCount 6 --maxIterationCount 9