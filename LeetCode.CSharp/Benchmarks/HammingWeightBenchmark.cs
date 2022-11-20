namespace LeetCode.CSharp.Benchmarks;

public class HammingWeightBenchmark : Benchmark
{
    [Benchmark]
    public int HammingWeight() => Problem.HammingWeight(uint.MaxValue);
}
