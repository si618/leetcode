namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void BinarySearch()
    {
        var nums = new[] { -1, 0, 3, 5, 9, 12 };
        Challenge.BinarySearch(nums, 9);
        Challenge.BinarySearch(nums, 2);
    }
}