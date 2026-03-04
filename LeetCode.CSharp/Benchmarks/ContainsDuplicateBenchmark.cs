namespace LeetCode.CSharp.Benchmarks;

public class ContainsDuplicateBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(ContainsDuplicate))]
    public void ContainsDuplicateSetup() => IntArray1 = [.. Enumerable.Range(0, 100_000)];

    [Benchmark]
    public bool ContainsDuplicate() => Problem.ContainsDuplicate(IntArray1);

    [GlobalCleanup(Target = nameof(ContainsDuplicate))]
    public void ContainsDuplicateCleanup() => IntArray1 = [];
}