namespace LeetCode.CSharp.Benchmarks;

public class SingleNumberBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(SingleNumber))]
    public void SingleNumberSetup() =>
        IntArray1 = [.. Enumerable.Range(1, 1_000_000)
, .. Enumerable.Range(1, 1_000_001)];

    [Benchmark]
    public int SingleNumber() => Problem.SingleNumber(IntArray1);

    [GlobalCleanup(Target = nameof(SingleNumber))]
    public void SingleNumberCleanup() => IntArray1 = [];
}
