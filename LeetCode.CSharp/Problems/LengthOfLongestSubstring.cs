﻿namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Longest Substring Without Repeating Characters",
        Difficulty.Medium,
        Category.SlidingWindow,
        "https://www.youtube.com/watch?v=wiGpQwVHdE0")]
    public static int LengthOfLongestSubstring(string s)
    {
        var list = new List<char>();
        var left = 0;
        var max = 0;

        for (var right = 0; right < s.Length; right++)
        {
            while (list.Contains(s[right]))
            {
                list.Remove(s[left]);
                left++;
            }

            list.Add(s[right]);
            max = Math.Max(max, right - left + 1);
        }

        return max;
    }

    [Fact]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void LengthOfLongestSubstringTest()
    {
        LengthOfLongestSubstring("abcabcbb").ShouldBe(3);
        LengthOfLongestSubstring("bbbbb").ShouldBe(1);
        LengthOfLongestSubstring("pwwkew").ShouldBe(3);
    }
}
