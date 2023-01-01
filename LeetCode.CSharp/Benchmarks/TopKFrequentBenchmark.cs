namespace LeetCode.CSharp.Benchmarks;

public class TopKFrequentBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(TopKFrequent))]
    public void TopKFrequentSetup() => IntArray1 = Enumerable.Range(0, 100_000).ToArray();

    [Benchmark]
    public int[] TopKFrequent() => Problem.TopKFrequent(IntArray1, IntArray1.Length);

    [GlobalCleanup(Target = nameof(TopKFrequent))]
    public void TopKFrequentCleanup() => IntArray1 = Array.Empty<int>();
}