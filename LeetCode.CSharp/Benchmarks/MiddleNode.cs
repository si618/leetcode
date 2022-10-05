﻿namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    [GlobalSetup(Target = nameof(MiddleNode))]
    public void MiddleNodeSetup()
    {
        ListNode1 = new ListNode(Enumerable.Range(1, 1_000_000).ToArray());
    }

    [Benchmark]
    public ListNode MiddleNode()
    {
        return Problem.MiddleNode(ListNode1);
    }

    [GlobalCleanup(Target = nameof(MiddleNode))]
    public void MiddleNodeCleanup()
    {
        ListNode1 = new ListNode();
    }
}