namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [Benchmark]
    public IList<string> FizzBuzz()
    {
        return Problem.FizzBuzz(1_000);
    }
}
