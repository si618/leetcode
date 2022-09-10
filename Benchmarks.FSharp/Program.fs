open BenchmarkDotNet.Running
open LeetCode

// TODO: Work out reflection to display problems and warn of missing benchmarks as per C#
// TODO: Consider https://github.com/commandlineparser/commandline#f-examples

[<EntryPoint>]
let main args =
    BenchmarkRunner.Run<FSharpBenchmarks>(null, args) |> ignore
    0
