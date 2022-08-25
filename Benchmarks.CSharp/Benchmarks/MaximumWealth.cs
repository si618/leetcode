namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MaximumWealth()
    {
        var ex1 = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 3, 2, 1 }
        };
        var ex2 = new[]
        {
            new[] { 1, 5 },
            new[] { 7, 3 },
            new[] { 3, 5 }
        };
        Problem.MaximumWealth(ex1);
        Problem.MaximumWealth(ex2);
    }
}