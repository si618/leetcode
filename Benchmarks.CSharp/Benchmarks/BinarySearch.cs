namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void BinarySearch()
    {
        var nums = new[] { -1, 0, 3, 5, 9, 12 };
        Problem.BinarySearch(nums, 9);
        Problem.BinarySearch(nums, 2);
    }
}