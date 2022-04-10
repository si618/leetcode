namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class Benchmark
{
    [Benchmark]
    public void MiddleNode()
    {
        var even = new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(4, null))));
        var odd = new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(4,
            new ListNode(5, null)))));
        Submission.MiddleNode(even);
        Submission.MiddleNode(odd);
    }
}