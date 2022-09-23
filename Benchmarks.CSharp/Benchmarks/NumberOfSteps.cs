namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public int NumberOfSteps()
    {
        return Problem.NumberOfSteps(1_000_000_000);
    }
}