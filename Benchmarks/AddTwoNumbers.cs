namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class Benchmark
{
    [Benchmark]
    public void AddTwoNumbers()
    {
        var ex1l1 = new ListNode(2,
            new ListNode(4,
            new ListNode(3, null)));
        var ex1l2 = new ListNode(5,
            new ListNode(6,
            new ListNode(4, null)));
        var ex2l1 = new ListNode(0, null);
        var ex2l2 = new ListNode(0, null);
        var ex3l1 = new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9, null)))))));
        var ex3l2 = new ListNode(9,
            new ListNode(9,
            new ListNode(9,
            new ListNode(9, null))));
        Submission.AddTwoNumbers(ex1l1, ex1l2);
        Submission.AddTwoNumbers(ex2l1, ex2l2);
        Submission.AddTwoNumbers(ex3l1, ex3l2);
    }
}