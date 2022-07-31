namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void LastStoneWeight()
    {
        Submission.LastStoneWeight(new[] { 2,7,4,1,8,1 });
        Submission.LastStoneWeight(new[] { 1 });
    }
}