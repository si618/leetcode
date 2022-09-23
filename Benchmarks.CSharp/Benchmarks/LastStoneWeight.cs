namespace LeetCode;

public partial class CSharpBenchmarks
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
}