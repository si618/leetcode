﻿namespace LeetCode;
using BenchmarkDotNet.Attributes;

public partial class Benchmarks
{
    [Benchmark]
    public void NumberOfSteps()
    {
        Submission.NumberOfSteps(14);
        Submission.NumberOfSteps(8);
        Submission.NumberOfSteps(123);
    }
}