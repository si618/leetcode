dotnet build --configuration Release
dotnet run --configuration Release --filter Leetcode.Benchmarks* --memory --exporters json --warmupCount 2 --minIterationCount 4 --maxIterationCount 8