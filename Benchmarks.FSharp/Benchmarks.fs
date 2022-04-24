﻿namespace LeetCode

open BenchmarkDotNet.Attributes

// TODO: Types in F# can't be partial so need to find another way to split benchmarks up

type FSharpBenchmarks() =

    [<Benchmark>]
    member _.ContainsDuplicate() = [
        LeetCode.Submission.ContainsDuplicate [| 1; 2; 3; 1 |]; 
        LeetCode.Submission.ContainsDuplicate [| 1; 2; 3; 4 |]; 
        LeetCode.Submission.ContainsDuplicate [| 1; 1; 1; 3; 3; 4; 3; 2; 4; 2 |] ]

    [<Benchmark>]
    member _.FizzBuzz() = [ 
        LeetCode.Submission.FizzBuzz 3;
        LeetCode.Submission.FizzBuzz 5; 
        LeetCode.Submission.FizzBuzz 15 ]
