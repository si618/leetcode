namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode("Ransom Note", Difficulty.Easy, Category.NotInNeetCode)]
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
        const string m1 = "a";
        const string r1 = "b";
        const string m2 = "aa";
        const string r2 = "ab";
        const string r3 = "bg";
        // ReSharper disable once StringLiteralTypo
        const string m3 = "aabefjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj";

        RansomNote(r1, m1).Should().BeFalse();
        RansomNote(r2, m2).Should().BeFalse();
        RansomNote(r3, m3).Should().BeTrue();
    }
}
