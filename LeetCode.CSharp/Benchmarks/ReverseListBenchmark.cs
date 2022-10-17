namespace LeetCode.CSharp.Benchmarks;

public class ReverseListBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(ReverseList))]
    public void ReverseListSetup()
    {
        ListNode1 = new ListNode(Enumerable.Range(1, 1_000_000).ToArray());
    }

    [Benchmark]
    public ListNode? ReverseList()
    {
        return Problem.ReverseList(ListNode1);
    }

    [GlobalCleanup(Target = nameof(ReverseList))]
    public void ReverseListCleanup()
    {
        ListNode1 = new ListNode();
    }
}
