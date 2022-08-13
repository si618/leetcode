namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MergeTwoLists()
    {
        var ex11 = new ListNode(new[] { 1, 2, 4 });
        var ex12 = new ListNode(new[] { 1, 3, 4 });

        Problem.MergeTwoLists(ex11, ex12);
        Problem.MergeTwoLists(null, null);
        Problem.MergeTwoLists(null, new ListNode(0));
    }
}
