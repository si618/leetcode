namespace LeetCode

open BenchmarkDotNet.Attributes

// TODO: Types in F# can't be partial so need to find another way to split benchmarks up

type FSharpBenchmarks() =

    [<Benchmark>]
    member _.ContainsDuplicate() = [
        Challenge.ContainsDuplicate [| 1; 2; 3; 1 |];
        Challenge.ContainsDuplicate [| 1; 2; 3; 4 |];
        Challenge.ContainsDuplicate [| 1; 1; 1; 3; 3; 4; 3; 2; 4; 2 |] ]

    [<Benchmark>]
    member _.FizzBuzz() = [
        Challenge.FizzBuzz 3;
        Challenge.FizzBuzz 5;
        Challenge.FizzBuzz 15 ]
