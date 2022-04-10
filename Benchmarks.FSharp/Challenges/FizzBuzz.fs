namespace LeetCode

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Engines

[<MemoryDiagnoser>]
type Benchmark() =
    let ex1 = LeetCode.Submission.FizzBuzz 3

    [<Benchmark>]
    member _.FizzBuzz() = ex1.Consume