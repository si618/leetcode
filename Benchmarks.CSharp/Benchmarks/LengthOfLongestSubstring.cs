namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void LengthOfLongestSubstring()
    {
        Submission.LengthOfLongestSubstring("abcabcbb");
        Submission.LengthOfLongestSubstring("bbbbb");
        Submission.LengthOfLongestSubstring("pwwkew");
    }
}