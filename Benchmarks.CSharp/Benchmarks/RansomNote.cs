namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void RansomNote()
    {
        Challenge.RansomNote("b", "a");
        Challenge.RansomNote("ab", "aa");
        Challenge.RansomNote("aab", "aa");
    }
}