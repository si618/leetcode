﻿namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void LengthOfLongestSubstring()
    {
        Problem.LengthOfLongestSubstring("abcabcbb");
        Problem.LengthOfLongestSubstring("bbbbb");
        Problem.LengthOfLongestSubstring("pwwkew");
    }
}