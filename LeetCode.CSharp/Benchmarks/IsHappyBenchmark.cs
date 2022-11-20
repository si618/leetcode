namespace LeetCode.CSharp.Benchmarks;

public class IsHappyBenchmark : Benchmark
{
    [Benchmark]
    public bool IsHappy() => Problem.IsHappy(int.MaxValue);
}
