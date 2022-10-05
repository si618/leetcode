namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    [Benchmark]
    public int UniquePaths()
    {
        return Problem.UniquePaths(10_000, 100);
    }
}