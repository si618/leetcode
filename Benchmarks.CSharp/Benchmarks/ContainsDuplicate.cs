namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void ContainsDuplicate()
    {
        var ex1 = new[] { 1, 2, 3, 1 };
        var ex2 = new[] { 1, 2, 3, 4 };
        var ex3 = new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
        Submission.ContainsDuplicate(ex1);
        Submission.ContainsDuplicate(ex2);
        Submission.ContainsDuplicate(ex3);
    }
}