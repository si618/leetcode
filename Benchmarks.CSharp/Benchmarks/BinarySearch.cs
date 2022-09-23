namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(BinarySearch))]
    public void BinarySearchSetup()
    {
        IntArray1 = Enumerable.Range(0, 1_000_000).ToArray();
    }

    [Benchmark]
    public int BinarySearch()
    {
        return Problem.BinarySearch(IntArray1, 1_000);
    }
}