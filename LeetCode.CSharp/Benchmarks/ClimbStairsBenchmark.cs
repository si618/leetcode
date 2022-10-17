namespace LeetCode.CSharp.Benchmarks;

public class ClimbStairsBenchmark : Benchmark
{
    [Benchmark]
    public int ClimbStairs()
    {
        return Problem.ClimbStairs(10_000_000);
    }
}
