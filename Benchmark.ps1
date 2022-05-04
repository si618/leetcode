dotnet run --project Benchmarks.CSharp/Benchmarks.CSharp.csproj --configuration Release `
    --filter LeetCode.CSharpBenchmarks* --memory --exporters json `
    --warmupCount 3 --minIterationCount 6 --maxIterationCount 9
dotnet run --project Benchmarks.FSharp/Benchmarks.FSharp.fsproj --configuration Release `
    --filter LeetCode.FSharpBenchmarks* --memory --exporters json `
    --warmupCount 3 --minIterationCount 6 --maxIterationCount 9
