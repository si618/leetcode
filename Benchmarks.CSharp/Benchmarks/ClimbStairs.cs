namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public int ClimbStairs()
    {
        return Problem.ClimbStairs(10_000_000);
    }
}
