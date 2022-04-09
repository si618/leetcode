open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

[<SimpleJob>]
type FizzBuzz() =

    [<Benchmark>]
    let ex1 = LeetCode.Submission.FizzBuzz 3 
    let ex2 = LeetCode.Submission.FizzBuzz 5 
    let ex3 = LeetCode.Submission.FizzBuzz 15 

// TODO: Work out reflection check to warn of missing benchmarks?

module Program =

    [<EntryPoint>]
    BenchmarkRunner.Run<FizzBuzz>() |> ignore
