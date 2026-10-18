namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Valid Anagram",
        Difficulty.Easy,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=9UtInBqnCgA")]
    public static bool IsAnagram(string s, string t) =>
        s.Length == t.Length && s.Order().SequenceEqual(t.Order());

    [Fact]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void IsAnagramTest()
    {
        IsAnagram("anagram", "nagaram").ShouldBeTrue();
        IsAnagram("rat", "cat").ShouldBeFalse();
        IsAnagram("ratty", "rat").ShouldBeFalse();
        IsAnagram("rat", "aat").ShouldBeFalse();
    }
}
