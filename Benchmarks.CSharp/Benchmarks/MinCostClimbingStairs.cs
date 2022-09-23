namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(MinCostClimbingStairs))]
    public void MinCostClimbingStairsSetup()
    {
        IntArray1 = Enumerable.Range(1, 1_000_000)
            .Concat(Enumerable.Range(1, 1_000_000))
            .ToArray();
    }

    [Benchmark]
    public int MinCostClimbingStairs()
    {
        return Problem.MinCostClimbingStairs(IntArray1);
    }

    [GlobalCleanup(Target = nameof(MinCostClimbingStairs))]
    public void MinCostClimbingStairsCleanup()
    {
        IntArray1 = Array.Empty<int>();
    }
}
