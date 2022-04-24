open BenchmarkDotNet.Running
open LeetCode

// TODO: Work out reflection to display solutions and warn of missing benchmarks as per C#

[<EntryPoint>]
let main args =
    BenchmarkRunner.Run<FSharpBenchmarks>(null, args) |> ignore
    0
