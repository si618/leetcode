namespace LeetCode.CSharp.Benchmarks;

public class MissingNumberBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(MissingNumber))]
    public void MissingNumberSetup() =>
        IntArray1 = Enumerable.Range(0, 1_000_000).Except(new[] { 100_000 }).ToArray();

    [Benchmark]
    public int MissingNumber() => Problem.MissingNumber(IntArray1);

    [GlobalCleanup(Target = nameof(MissingNumber))]
    public void MissingNumberCleanup() => IntArray1 = Array.Empty<int>();
}