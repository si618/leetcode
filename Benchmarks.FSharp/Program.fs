open BenchmarkDotNet.Running
open LeetCode

// TODO: Work out reflection check to warn of missing benchmarks as per C#

[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<Benchmark>() |> ignore
    0