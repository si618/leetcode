namespace LeetCode;

public partial class CSharpBenchmarks
{
    private Problem.KthLargest _kthLargest = null!;

    [GlobalSetup(Target = nameof(KthLargest))]
    public void KthLargestSetup()
    {
        var values = Enumerable.Range(1, 100_000_000).ToArray();
        _kthLargest = new Problem.KthLargest(50_000_000, values);
    }

    [Benchmark]
    public int KthLargest()
    {
        return _kthLargest.Add(75_000_000);
    }
}