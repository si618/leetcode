namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    [Benchmark]
    public IList<string> FizzBuzz()
    {
        return Problem.FizzBuzz(1_000);
    }
}
