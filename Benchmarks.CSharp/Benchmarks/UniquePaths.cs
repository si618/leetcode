namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public int UniquePaths()
    {
        return Problem.UniquePaths(10_000, 100);
    }
}