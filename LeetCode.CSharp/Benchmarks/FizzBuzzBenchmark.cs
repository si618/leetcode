namespace LeetCode.CSharp.Benchmarks;

public class FizzBuzzBenchmark : Benchmark
{
    [Benchmark]
    public IList<string> FizzBuzz()
    {
        return Problem.FizzBuzz(1_000);
    }
}
