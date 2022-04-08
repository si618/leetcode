namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    public static int LengthOfLongestSubstring(string s)
    {
        var map = new Dictionary<char, int>();
        var left = 0;
        var max = 0;

        // Uses "sliding window" solution
        for (var right = 0; right < s.Length; right++)
        {
            var current = s[right];

            if (!map.TryAdd(current, right))
            {
                // Slide window past character
                // https://youtu.be/wiGpQwVHdE0?t=208
                left = Math.Max(map[current] + 1, left);
                // Update characters position in window
                map[current] = right;
            }

            // Update if a longer length is found
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
