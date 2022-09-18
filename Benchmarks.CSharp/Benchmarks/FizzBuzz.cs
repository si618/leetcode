namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public IList<string> FizzBuzz()
    {
        return Problem.FizzBuzz(1_000);
    }
}
