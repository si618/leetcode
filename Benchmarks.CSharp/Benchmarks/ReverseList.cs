// ReSharper disable once CheckNamespace
namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void ReverseList()
    {
        var ex1 = new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(4,
            new ListNode(5)))));
        var ex2 = new ListNode(1, new ListNode(2));

        Submission.ReverseList(ex1);
        Submission.ReverseList(ex2);
    }
}
