namespace LeetCode.CSharp.Benchmarks;

public class LastStoneWeightBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(LastStoneWeight))]
    public void LastStoneWeightSetup()
    {
        IntArray1 = Enumerable.Range(1, 1_000_000).ToArray();
    }

    [Benchmark]
    public int LastStoneWeight()
    {
        return Problem.LastStoneWeight(IntArray1);
    }

    [GlobalCleanup(Target = nameof(LastStoneWeight))]
    public void LastStoneWeightCleanup()
    {
        IntArray1 = Array.Empty<int>();
    }
}