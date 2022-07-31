namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MaxProfit()
    {
        Challenge.MaxProfit(new[] { 7, 1, 5, 3, 6, 4 });
        Challenge.MaxProfit(new[] { 7, 6, 4, 3, 1 });
    }
}