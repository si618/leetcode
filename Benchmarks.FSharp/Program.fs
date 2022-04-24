open BenchmarkDotNet.Running
open LeetCode

// TODO: Work out reflection check to warn of missing benchmarks as per C#

[<EntryPoint>]
let main _ =
    BenchmarkRunner.Run<Benchmarks>() |> ignore
    0
