namespace LeetCode.FSharp.Benchmarks

open BenchmarkDotNet.Attributes
open LeetCode.FSharp.Problems

[<Config(typeof<LeetCode.CSharp.RuntimeConfig>)>]
type FizzBuzzBenchmark() =

    [<Benchmark>]
    member _.FizzBuzz() = [ FizzBuzz.FizzBuzz 1_000 ]
