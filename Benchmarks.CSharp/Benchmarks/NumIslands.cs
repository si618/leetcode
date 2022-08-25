namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void NumIslands()
    {
        var ex1 = new[]
        {
            new [] { '1', '1', '1', '1', '0' },
            new [] { '1', '1', '0', '1', '0' },
            new [] { '1', '1', '0', '0', '0' },
            new [] { '0', '0', '0', '0', '0' }
        };
        var ex2 = new[]
        {
            new [] { '1', '1', '0', '0', '0' },
            new [] { '1', '1', '0', '0', '0' },
            new [] { '0', '0', '1', '0', '0' },
            new [] { '0', '0', '0', '1', '1' }
        };
        Problem.NumIslands(ex1);
        Problem.NumIslands(ex2);
    }
}
