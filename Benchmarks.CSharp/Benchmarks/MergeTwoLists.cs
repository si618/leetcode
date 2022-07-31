namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MergeTwoLists()
    {
        var ex11 = new ListNode(new[] { 1, 2, 4 });
        var ex12 = new ListNode(new[] { 1, 3, 4 });

        Challenge.MergeTwoLists(ex11, ex12);
        Challenge.MergeTwoLists(null, null);
        Challenge.MergeTwoLists(null, new ListNode(0));
    }
}
