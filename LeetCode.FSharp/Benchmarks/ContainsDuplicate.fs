namespace LeetCode.FSharp.Benchmarks

open BenchmarkDotNet.Attributes
open LeetCode.FSharp.Problems

[<Config(typeof<LeetCode.CSharp.RuntimeConfig>)>]
type ContainsDuplicate() =

    let array = seq { 1..1_000_000 }

    [<Benchmark>]
    member _.ContainsDuplicate() =
        [ ContainsDuplicate.ContainsDuplicate array ]
