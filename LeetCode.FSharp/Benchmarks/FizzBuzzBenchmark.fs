namespace LeetCode.FSharp.Benchmarks

open BenchmarkDotNet.Attributes
open LeetCode.FSharp.Problems

[<Config(typeof<LeetCode.CSharp.BenchmarkConfig>)>]
type FizzBuzzBenchmark() =

    [<Benchmark>]
    member _.FizzBuzz() = [ FizzBuzz.FizzBuzz 1_000 ]
