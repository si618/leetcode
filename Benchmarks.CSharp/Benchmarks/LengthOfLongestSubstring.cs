namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void LengthOfLongestSubstring()
    {
        // ReSharper disable StringLiteralTypo
        Submission.LengthOfLongestSubstring("abcabcbb");
        Submission.LengthOfLongestSubstring("bbbbb");
        Submission.LengthOfLongestSubstring("pwwkew");
    }
}