namespace LeetCode.CSharp.Benchmarks;

public class CountBitsBenchmark : Benchmark
{
    [Benchmark]
    public int[] CountBits() => Problem.CountBits(10_000);
}