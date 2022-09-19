namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(LastStoneWeight))]
    public void LastStoneWeightSetup()
    {
        _intArray1 = Enumerable.Range(1, 1_000_000).ToArray();
    }

    [Benchmark]
    public int LastStoneWeight()
    {
        return Problem.LastStoneWeight(_intArray1);
    }
}