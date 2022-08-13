namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void Subsets()
    {
        Problem.Subsets(new[] { 1, 2, 3 });
        Problem.Subsets(new[] { 0 });
    }
}