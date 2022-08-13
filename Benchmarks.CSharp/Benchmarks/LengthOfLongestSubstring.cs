namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void LengthOfLongestSubstring()
    {
        // ReSharper disable StringLiteralTypo
        Problem.LengthOfLongestSubstring("abcabcbb");
        Problem.LengthOfLongestSubstring("bbbbb");
        Problem.LengthOfLongestSubstring("pwwkew");
    }
}