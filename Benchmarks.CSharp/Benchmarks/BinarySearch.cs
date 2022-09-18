namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(BinarySearch))]
    public void BinarySearchSetup()
    {
        _intArray1 = Enumerable.Range(0, 1_000_000).ToArray();
    }

    [Benchmark]
    public int BinarySearch()
    {
        return Problem.BinarySearch(_intArray1, 1_000);
    }
}