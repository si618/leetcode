namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class Benchmark
{
    [Benchmark]
    public void NumberOfSteps()
    {
        Submission.NumberOfSteps(14);
        Submission.NumberOfSteps(8);
        Submission.NumberOfSteps(123);
    }
}