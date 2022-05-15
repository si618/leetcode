// ReSharper disable once CheckNamespace
namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void RansomNote()
    {
        Submission.RansomNote("b", "a");
        Submission.RansomNote("ab", "aa");
        Submission.RansomNote("aab", "aa");
    }
}