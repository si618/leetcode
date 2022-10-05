namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    [GlobalSetup(Target = nameof(MergeTwoLists))]
    public void MergeTwoListsSetup()
    {
        ListNode1 = new ListNode(Enumerable.Range(1, 100_000).ToArray());
        ListNode2 = new ListNode(Enumerable.Range(1, 50_000).ToArray());
    }

    [Benchmark]
    public ListNode? MergeTwoLists()
    {
        // TODO Work out why ListNode1 and ListNode2 bork on GlobalSetup
        var listNode1 = new ListNode(Enumerable.Range(1, 100_000).ToArray());
        var listNode2 = new ListNode(Enumerable.Range(1, 50_000).ToArray());
        return Problem.MergeTwoLists(listNode1, listNode2);
    }

    [GlobalCleanup(Target = nameof(MergeTwoLists))]
    public void MergeTwoListsCleanup()
    {
        ListNode1 = new ListNode();
        ListNode2 = new ListNode();
    }
}
