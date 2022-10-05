namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    private Problem.KthLargest _kthLargest = null!;

    [GlobalSetup(Target = nameof(KthLargest))]
    public void KthLargestSetup()
    {
        IntArray1 = Enumerable.Range(1, 100_000_000).ToArray();
        _kthLargest = new Problem.KthLargest(50_000_000, IntArray1);
    }

    [Benchmark]
    public int KthLargest()
    {
        return _kthLargest.Add(75_000_000);
    }

    [GlobalCleanup(Target = nameof(KthLargest))]
    public void KthLargestCleanup()
    {
        IntArray1 = Array.Empty<int>();
        _kthLargest = null!;
    }
}