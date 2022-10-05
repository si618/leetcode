namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    [Benchmark]
    public int ClimbStairs()
    {
        return Problem.ClimbStairs(10_000_000);
    }
}
