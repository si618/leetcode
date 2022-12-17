namespace LeetCode.CSharp.Benchmarks;

public class MiddleNodeBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(MiddleNode))]
    public void MiddleNodeSetup() =>
        ListNode1 = new ListNode(Enumerable.Range(1, 1_000_000).ToArray());

    [Benchmark]
    public ListNode MiddleNode() => Problem.MiddleNode(ListNode1);

    [GlobalCleanup(Target = nameof(MiddleNode))]
    public void MiddleNodeCleanup() => ListNode1 = new ListNode();
}