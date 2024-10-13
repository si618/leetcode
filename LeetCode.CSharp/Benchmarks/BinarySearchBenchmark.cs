namespace LeetCode.CSharp.Benchmarks;

public class BinarySearchBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(BinarySearch))]
    public void BinarySearchSetup() => IntArray1 = Enumerable.Range(0, 1_000_000).ToArray();

    [Benchmark]
    public int BinarySearch() => Problem.BinarySearch(IntArray1, 1_000);

    [GlobalCleanup(Target = nameof(BinarySearch))]
    public void BinarySearchCleanup() => IntArray1 = [];
}