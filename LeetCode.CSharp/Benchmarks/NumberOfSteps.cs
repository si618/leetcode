namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [Benchmark]
    public int NumberOfSteps()
    {
        return Problem.NumberOfSteps(1_000_000_000);
    }
}