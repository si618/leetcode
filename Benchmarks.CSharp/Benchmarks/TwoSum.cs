namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void TwoSum()
    {
        var ex1 = new[] { 2, 7, 11, 15 };
        var ex2 = new[] { 3, 2, 4 };
        var ex3 = new[] { 3, 3 };
        Challenge.TwoSum(ex1, 9);
        Challenge.TwoSum(ex2, 6);
        Challenge.TwoSum(ex3, 6);
    }
}