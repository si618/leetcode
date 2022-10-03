namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [Benchmark]
    public int ClimbStairs()
    {
        return Problem.ClimbStairs(10_000_000);
    }
}
