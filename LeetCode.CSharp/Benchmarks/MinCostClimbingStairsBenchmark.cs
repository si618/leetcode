namespace LeetCode.CSharp.Benchmarks;

public class MinCostClimbingStairsBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(MinCostClimbingStairs))]
    public void MinCostClimbingStairsSetup() =>
        IntArray1 = [.. Enumerable.Range(1, 1_000_000)
, .. Enumerable.Range(1, 1_000_000)];

    [Benchmark]
    public int MinCostClimbingStairs() => Problem.MinCostClimbingStairs(IntArray1);

    [GlobalCleanup(Target = nameof(MinCostClimbingStairs))]
    public void MinCostClimbingStairsCleanup() => IntArray1 = [];
}
