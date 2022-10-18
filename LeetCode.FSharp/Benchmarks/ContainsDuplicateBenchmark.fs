namespace LeetCode.FSharp.Benchmarks

open BenchmarkDotNet.Attributes
open LeetCode.FSharp.Problems

[<Config(typeof<LeetCode.CSharp.BenchmarkConfig>)>]
type ContainsDuplicateBenchmark() =

    let array = seq { 1..100_000 }

    [<Benchmark>]
    member _.ContainsDuplicate() =
        [ ContainsDuplicate.ContainsDuplicate array ]
