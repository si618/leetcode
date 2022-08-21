namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MinCostClimbingStairs()
    {
        Problem.MinCostClimbingStairs(new[] { 10, 15, 20 });
        Problem.MinCostClimbingStairs(new [] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1});
    }
}
