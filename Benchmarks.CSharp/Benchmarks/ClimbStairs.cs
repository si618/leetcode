namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void ClimbStairs()
    {
        Problem.ClimbStairs(2);
        Problem.ClimbStairs(3);
    }
}
