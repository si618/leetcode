namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [GlobalSetup(Target = nameof(TwoSum))]
    public void TwoSumSetup()
    {
        IntArray1 = Enumerable.Range(1, 10_000).ToArray();
        // Force full iteration by making target last two items in array
        Int1 = IntArray1[^1] + IntArray1[^2];
    }

    [Benchmark]
    public int[] TwoSum()
    {
        return Problem.TwoSum(IntArray1, Int1);
    }

    [GlobalCleanup(Target = nameof(TwoSum))]
    public void TwoSumCleanup()
    {
        IntArray1 = Array.Empty<int>();
        Int1 = 0;
    }
}