namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode("Valid Anagram", Difficulty.Easy, Category.ArraysAndHashing)]
    public static bool IsAnagram(string s, string t)
    {
        return s.Length == t.Length &&
               s.OrderBy(c => c).SequenceEqual(t.OrderBy(c => c));
    }

    [Test]
    public void IsAnagramTest()
    {
        // ReSharper disable once StringLiteralTypo
        IsAnagram("anagram", "nagaram").Should().BeTrue();
        IsAnagram("rat", "cat").Should().BeFalse();
        IsAnagram("ratty", "rat").Should().BeFalse();
        IsAnagram("rat", "aat").Should().BeFalse();
    }
}
