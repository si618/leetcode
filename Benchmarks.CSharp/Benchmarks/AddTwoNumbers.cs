﻿namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void AddTwoNumbers()
    {
        var ex11 = new ListNode(new[] { 2, 4, 3 });
        var ex12 = new ListNode(new[] { 5, 6, 4 });
        var ex21 = new ListNode();
        var ex22 = new ListNode();
        var ex31 = new ListNode(new[] { 9, 9, 9, 9, 9, 9, 9 });
        var ex32 = new ListNode(new[] { 9, 9, 9, 9 });
        Problem.AddTwoNumbers(ex11, ex12);
        Problem.AddTwoNumbers(ex21, ex22);
        Problem.AddTwoNumbers(ex31, ex32);
    }
}