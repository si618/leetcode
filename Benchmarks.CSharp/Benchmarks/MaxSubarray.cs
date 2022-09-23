namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(MaxSubarray))]
    public void MaxSubarraySetup()
    {
        IntArray1 = Enumerable.Range(1, 10_000_000)
            .Concat(Enumerable.Range(1, 10_000_000))
            .ToArray();
    }

    [Benchmark]
    public int MaxSubarray()
    {
        return Problem.MaxSubarray(IntArray1);
    }

    [GlobalCleanup(Target = nameof(MaxSubarray))]
    public void MaxSubarrayCleanup()
    {
        IntArray1 = Array.Empty<int>();
    }
}
