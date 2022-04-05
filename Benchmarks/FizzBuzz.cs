namespace LeetCode;
using BenchmarkDotNet.Attributes;

public partial class Benchmarks
{
    [Benchmark]
    public void FizzBuzz()
    {
        Submission.FizzBuzz(3);
        Submission.FizzBuzz(5);
        Submission.FizzBuzz(15);
    }
}