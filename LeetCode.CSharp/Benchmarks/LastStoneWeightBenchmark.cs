namespace LeetCode.CSharp.Benchmarks;

public class LastStoneWeightBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(LastStoneWeight))]
    public void LastStoneWeightSetup() => IntArray1 = [.. Enumerable.Range(1, 1_000_000)];

    [Benchmark]
    public int LastStoneWeight() => Problem.LastStoneWeight(IntArray1);

    [GlobalCleanup(Target = nameof(LastStoneWeight))]
    public void LastStoneWeightCleanup() => IntArray1 = [];
}