namespace LeetCode;
using BenchmarkDotNet.Attributes;

public partial class Benchmarks
{
    [Benchmark]
    public void MaximumWealth()
    {
        var ex1 = new int[][]
        {
            new[] { 1, 2, 3 },
            new[] { 3, 2, 1 }
        };
        var ex2 = new int[][]
        {
            new[] { 1, 5 },
            new[] { 7, 3 },
            new[] { 3, 5 }
        };
        Submission.MaximumWealth(ex1);
        Submission.MaximumWealth(ex2);
    }
}