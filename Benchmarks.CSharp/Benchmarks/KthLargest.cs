namespace LeetCode;

public partial class CSharpBenchmarks
{
    private Problem.KthLargest _kthLargest = null!;

    [GlobalSetup(Target = nameof(KthLargest))]
    public void KthLargestSetup()
    {
        var values = Enumerable.Range(1, 1_000_000_000).ToArray();
        _kthLargest = new Problem.KthLargest(500_000_000, values);
    }

    [Benchmark]
    public int KthLargest()
    {
        return _kthLargest.Add(750_000_000);
    }
}