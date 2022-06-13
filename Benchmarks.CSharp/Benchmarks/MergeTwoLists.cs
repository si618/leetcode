// ReSharper disable once CheckNamespace
namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MergeTwoLists()
    {
        var ex11 = new ListNode(1,
            new ListNode(2,
            new ListNode(4)));
        var ex12 = new ListNode(1,
            new ListNode(3,
            new ListNode(4)));

        Submission.MergeTwoLists(ex11, ex12);
        Submission.MergeTwoLists(null, null);
        Submission.MergeTwoLists(null, new ListNode(0));
    }
}
