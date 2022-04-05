namespace LeetCode;
using BenchmarkDotNet.Attributes;

public partial class Benchmarks
{
    [Benchmark]
    public void RansomNote()
    {
        Submission.CanConstruct("b", "a");
        Submission.CanConstruct("ab", "aa");
        Submission.CanConstruct("aab", "aa");
    }
}