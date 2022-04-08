namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class Benchmark
{
    [Benchmark]
    public void RansomNote()
    {
        Submission.RansomNote("b", "a");
        Submission.RansomNote("ab", "aa");
        Submission.RansomNote("aab", "aa");
    }
}