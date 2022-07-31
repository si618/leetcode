namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void Subsets()
    {
        Challenge.Subsets(new[] { 1, 2, 3 });
        Challenge.Subsets(new[] { 0 });
    }
}