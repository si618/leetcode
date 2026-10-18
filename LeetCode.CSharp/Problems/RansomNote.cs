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
        const string M1 = "a";
        const string R1 = "b";
        const string M2 = "aa";
        const string R2 = "ab";
        const string R3 = "bg";
        const string M3 = "aabefjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj";

        RansomNote(R1, M1).ShouldBeFalse();
        RansomNote(R2, M2).ShouldBeFalse();
        RansomNote(R3, M3).ShouldBeTrue();
    }
}
