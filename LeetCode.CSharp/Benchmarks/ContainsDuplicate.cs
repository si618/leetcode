namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
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

    [GlobalCleanup(Target = nameof(ContainsDuplicate))]
    public void ContainsDuplicateCleanup()
    {
        IntArray1 = Array.Empty<int>();
    }
}