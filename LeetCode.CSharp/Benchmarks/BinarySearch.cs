﻿namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    [GlobalSetup(Target = nameof(BinarySearch))]
    public void BinarySearchSetup()
    {
        IntArray1 = Enumerable.Range(0, 1_000_000).ToArray();
    }

    [Benchmark]
    public int BinarySearch()
    {
        return Problem.BinarySearch(IntArray1, 1_000);
    }

    [GlobalCleanup(Target = nameof(BinarySearch))]
    public void BinarySearchCleanup()
    {
        IntArray1 = Array.Empty<int>();
    }
}