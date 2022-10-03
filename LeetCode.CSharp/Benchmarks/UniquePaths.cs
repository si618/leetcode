namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [Benchmark]
    public int UniquePaths()
    {
        return Problem.UniquePaths(10_000, 100);
    }
}