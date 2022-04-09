namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode(Difficulty.Medium, Category.SlidingWindow)]
    public static int LengthOfLongestSubstring(string s)
    {
        var list = new List<char>();
        var left = 0;
        var max = 0;

        for (var right = 0; right < s.Length; right++)
        {
            // https://youtu.be/wiGpQwVHdE0
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

    [Test]
    public void LengthOfLongestSubstringTest()
    {
        LengthOfLongestSubstring("abcabcbb").Should().Be(3);
        LengthOfLongestSubstring("bbbbb").Should().Be(1);
        LengthOfLongestSubstring("pwwkew").Should().Be(3);
    }
}
