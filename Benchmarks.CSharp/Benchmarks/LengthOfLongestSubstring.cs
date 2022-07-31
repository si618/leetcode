namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void LengthOfLongestSubstring()
    {
        // ReSharper disable StringLiteralTypo
        Challenge.LengthOfLongestSubstring("abcabcbb");
        Challenge.LengthOfLongestSubstring("bbbbb");
        Challenge.LengthOfLongestSubstring("pwwkew");
    }
}