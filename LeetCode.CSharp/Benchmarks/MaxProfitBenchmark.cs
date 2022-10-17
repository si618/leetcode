namespace LeetCode.CSharp.Benchmarks;

public class MaxProfitBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(MaxProfit))]
    public void MaxProfitSetup()
    {
        IntArray1 = Enumerable.Range(1, 10_000_000).ToArray();
    }

    [Benchmark]
    public int MaxProfit() => Problem.MaxProfit(IntArray1);

    [GlobalCleanup(Target = nameof(MaxProfit))]
    public void MaxProfitCleanup()
    {
        IntArray1 = Array.Empty<int>();
    }
}