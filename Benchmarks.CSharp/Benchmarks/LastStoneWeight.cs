namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void LastStoneWeight()
    {
        Problem.LastStoneWeight(new[] { 2, 7, 4, 1, 8, 1 });
        Problem.LastStoneWeight(new[] { 1 });
    }
}