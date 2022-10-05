namespace LeetCode.FSharp.Benchmarks

open BenchmarkDotNet.Attributes
open LeetCode.FSharp.Problems

[<Config(typeof<LeetCode.CSharp.RuntimeConfig>)>]
type FizzBuzz() =

    [<Benchmark>]
    member _.FizzBuzz() = [
        FizzBuzz.FizzBuzz 1_000 ];
