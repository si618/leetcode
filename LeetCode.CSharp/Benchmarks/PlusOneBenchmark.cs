namespace LeetCode.CSharp.Benchmarks;

public class PlusOneBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(PlusOne))]
    public void PlusOneSetup() =>
        IntArray1 = [.. Enumerable.Range(1, 1_000_000)
, .. Enumerable.Range(1, 1_000_000)];

    [Benchmark]
    public int[] PlusOne() => Problem.PlusOne(IntArray1);

    [GlobalCleanup(Target = nameof(PlusOne))]
    public void PlusOneCleanup() => IntArray1 = [];
}
