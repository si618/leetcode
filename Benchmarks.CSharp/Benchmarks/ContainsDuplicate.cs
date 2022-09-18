namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(ContainsDuplicate))]
    public void ContainsDuplicateSetup()
    {
        _intArray1 = Enumerable.Range(0, 1_000_000).ToArray();
    }

    [Benchmark]
    public bool ContainsDuplicate()
    {
        return Problem.ContainsDuplicate(_intArray1);
    }
}