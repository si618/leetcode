namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void KWeakestRows()
    {
        var ex1 = new[]
        {
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 0 },
            new[] { 1, 0, 0, 0, 0 },
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 1 }
        };
        var ex2 = new[]
        {
            new[] { 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1 },
            new[] { 1, 0, 0, 0 },
            new[] { 1, 0, 0, 0 }
        };
        Problem.KWeakestRows(ex1, 3);
        Problem.KWeakestRows(ex2, 2);
    }
}