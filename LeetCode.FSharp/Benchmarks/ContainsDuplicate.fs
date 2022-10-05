namespace LeetCode.FSharp.Benchmarks

open BenchmarkDotNet.Attributes
open LeetCode.FSharp.Problems

[<Config(typeof<LeetCode.CSharp.RuntimeConfig>)>]
type ContainsDuplicate() =

    [<Benchmark>]
    member _.ContainsDuplicate() = [
        ContainsDuplicate.ContainsDuplicate [| 1; 2; 3; 1 |];
        ContainsDuplicate.ContainsDuplicate [| 1; 2; 3; 4 |];
        ContainsDuplicate.ContainsDuplicate [| 1; 1; 1; 3; 3; 4; 3; 2; 4; 2 |] ]
