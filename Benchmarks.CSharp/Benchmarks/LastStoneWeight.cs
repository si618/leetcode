namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void LastStoneWeight()
    {
        Challenge.LastStoneWeight(new[] { 2,7,4,1,8,1 });
        Challenge.LastStoneWeight(new[] { 1 });
    }
}