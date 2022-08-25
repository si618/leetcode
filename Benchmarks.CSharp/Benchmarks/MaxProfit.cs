namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MaxProfit()
    {
        Problem.MaxProfit(new[] { 7, 1, 5, 3, 6, 4 });
        Problem.MaxProfit(new[] { 7, 6, 4, 3, 1 });
    }
}