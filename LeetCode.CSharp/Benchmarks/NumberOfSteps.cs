namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    [Benchmark]
    public int NumberOfSteps()
    {
        return Problem.NumberOfSteps(1_000_000_000);
    }
}