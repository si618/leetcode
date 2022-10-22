namespace LeetCode.CSharp.Benchmarks;

public class UniquePathsBenchmark : Benchmark
{
    [Benchmark]
    public int UniquePaths() => Problem.UniquePaths(10_000, 100);
}