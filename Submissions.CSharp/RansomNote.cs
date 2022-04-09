namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode(Difficulty.Easy, Category.None)]
    public static bool RansomNote(string ransomNote, string magazine)
    {
        var frequency = new Dictionary<char, int>();

        foreach (var mc in magazine)
        {
            if (!frequency.ContainsKey(mc))
            {
                frequency.Add(mc, 1);
            }
            else
            {
                frequency[mc]++;
            }
        }

        foreach (var rc in ransomNote)
        {
            if (!frequency.ContainsKey(rc) || frequency[rc] == 0)
            {
                return false;
            }

            frequency[rc]--;
        }

        return true;
    }

    [Test]
    public void RansomNoteTest()
    {
        var m1 = "a";
        var r1 = "b";
        var m2 = "aa";
        var r2 = "ab";
        var r3 = "bg";
        var m3 = "aabefjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj";

        RansomNote(r1, m1).Should().BeFalse();
        RansomNote(r2, m2).Should().BeFalse();
        RansomNote(r3, m3).Should().BeTrue();
    }
}
