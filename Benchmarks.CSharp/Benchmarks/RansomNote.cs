﻿namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void RansomNote()
    {
        Problem.RansomNote("b", "a");
        Problem.RansomNote("ab", "aa");
        Problem.RansomNote("aab", "aa");
    }
}