namespace LeetCode.CSharp.Benchmarks;

public class UniquePathsBenchmark : Benchmark
{
    [Benchmark]
    public int UniquePaths()
    {
        return Problem.UniquePaths(10_000, 100);
    }
}