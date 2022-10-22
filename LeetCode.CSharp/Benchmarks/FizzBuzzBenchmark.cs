namespace LeetCode.CSharp.Benchmarks;

public class FizzBuzzBenchmark : Benchmark
{
    [Benchmark]
    public IList<string> FizzBuzz() => Problem.FizzBuzz(1_000);
}
