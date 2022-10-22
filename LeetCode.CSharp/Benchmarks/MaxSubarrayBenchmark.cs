namespace LeetCode.CSharp.Benchmarks;

public class MaxSubarrayBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(MaxSubarray))]
    public void MaxSubarraySetup()
    {
        IntArray1 = Enumerable.Range(1, 1_000_000)
            .Concat(Enumerable.Range(1, 1_000_000))
            .ToArray();
    }

    [Benchmark]
    public int MaxSubarray() => Problem.MaxSubarray(IntArray1);

    [GlobalCleanup(Target = nameof(MaxSubarray))]
    public void MaxSubarrayCleanup()
    {
        IntArray1 = Array.Empty<int>();
    }
}
