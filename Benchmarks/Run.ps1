dotnet build --configuration Release
dotnet run --configuration Release --filter LeetCode* --memory --exporters json --warmupCount 3 --minIterationCount 6 --maxIterationCount 9