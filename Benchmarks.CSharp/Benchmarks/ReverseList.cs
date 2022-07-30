namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void ReverseList()
    {
        var ex1 = new ListNode(new[] { 1, 2, 3, 4, 5 });
        var ex2 = new ListNode(1, new ListNode(2));

        Submission.ReverseList(ex1);
        Submission.ReverseList(ex2);
    }
}
