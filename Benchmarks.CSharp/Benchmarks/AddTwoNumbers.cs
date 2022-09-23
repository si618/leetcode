﻿namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(AddTwoNumbers))]
    public void AddTwoNumbersSetup()
    {
        IntArray1 = new int[50_000];
        IntArray2 = new int[10_000];
        Array.Fill(IntArray1, 9);
        Array.Fill(IntArray2, 9);
        ListNode1 = new ListNode(IntArray1);
        ListNode2 = new ListNode(IntArray2);
    }

    [Benchmark]
    public ListNode AddTwoNumbers()
    {
        return Problem.AddTwoNumbers(ListNode1, ListNode2);
    }
}