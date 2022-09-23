namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(ContainsDuplicate))]
    public void ContainsDuplicateSetup()
    {
        IntArray1 = Enumerable.Range(0, 1_000_000).ToArray();
    }

    [Benchmark]
    public bool ContainsDuplicate()
    {
        return Problem.ContainsDuplicate(IntArray1);
    }
}