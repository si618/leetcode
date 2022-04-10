namespace LeetCode

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Engines

[<MemoryDiagnoser>]
type Benchmark() =
    let ex1 = LeetCode.Submission.FizzBuzz 3
    let ex2 = LeetCode.Submission.FizzBuzz 5
    let ex3 = LeetCode.Submission.FizzBuzz 15

    [<Benchmark>]
    member _.FizzBuzz() = ex1.Consume
