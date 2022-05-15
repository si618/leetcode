// ReSharper disable once CheckNamespace
namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void AddTwoNumbers()
    {
        var ex11 = new ListNode(2,
            new ListNode(4,
            new ListNode(3)));
        var ex12 = new ListNode(5,
            new ListNode(6,
            new ListNode(4)));
        var ex21 = new ListNode();
        var ex22 = new ListNode();
        var ex31 = new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9)))))));
        var ex32 = new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9))));
        Submission.AddTwoNumbers(ex11, ex12);
        Submission.AddTwoNumbers(ex21, ex22);
        Submission.AddTwoNumbers(ex31, ex32);
    }
}