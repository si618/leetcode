namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void UniquePaths()
    {
        Problem.UniquePaths(7, 3);
        Problem.UniquePaths(3, 2);
        Problem.UniquePaths(10_000, 100);
    }
}