namespace LeetCode.FSharp

open BenchmarkDotNet.Attributes
open LeetCode.FSharp.Problems

// TODO: Types in F# can't be partial so need to find another way to split benchmarks up

[<Config(typeof<LeetCode.CSharp.RuntimeConfig>)>]
type Benchmarks() =

    [<Benchmark>]
    member _.ContainsDuplicate() = [
        ContainsDuplicate.ContainsDuplicate [| 1; 2; 3; 1 |];
        ContainsDuplicate.ContainsDuplicate [| 1; 2; 3; 4 |];
        ContainsDuplicate.ContainsDuplicate [| 1; 1; 1; 3; 3; 4; 3; 2; 4; 2 |] ]

    [<Benchmark>]
    member _.FizzBuzz() = [
        FizzBuzz.FizzBuzz 1_000 ];
