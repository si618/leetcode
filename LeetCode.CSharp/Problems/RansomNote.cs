namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Ransom Note", Difficulty.Easy, Category.NotInNeetCode)]
    public static bool RansomNote(string ransomNote, string magazine)
    {
        var frequency = new Dictionary<char, int>();

        foreach (var mc in magazine)
        {
            if (!frequency.TryGetValue(mc, out var value))
            {
                frequency.Add(mc, 1);
            }
            else
            {
                frequency[mc] = ++value;
            }
        }

        foreach (var rc in ransomNote)
        {
            if (!frequency.TryGetValue(rc, out var value) || value == 0)
            {
                return false;
            }

            frequency[rc] = --value;
        }

        return true;
    }

    [Fact]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void RansomNoteTest()
    {
        const string m1 = "a";
        const string r1 = "b";
        const string m2 = "aa";
        const string r2 = "ab";
        const string r3 = "bg";
        const string m3 = "aabefjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj";

        RansomNote(r1, m1).Should().BeFalse();
        RansomNote(r2, m2).Should().BeFalse();
        RansomNote(r3, m3).Should().BeTrue();
    }
}
