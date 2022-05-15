// ReSharper disable once CheckNamespace
namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MaxProfit()
    {
        Submission.MaxProfit(new[] { 7, 1, 5, 3, 6, 4 });
        Submission.MaxProfit(new[] { 7, 6, 4, 3, 1 });
    }
}