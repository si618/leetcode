namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MiddleNode()
    {
        var even = new ListNode(new[] { 1, 2, 3, 4 });
        var odd = new ListNode(new[] { 1, 2, 3, 4, 5 });
        Problem.MiddleNode(even);
        Problem.MiddleNode(odd);
    }
}