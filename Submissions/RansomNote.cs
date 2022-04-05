namespace LeetCode;
using NUnit.Framework;

public partial class Submission
{
    public static bool CanConstruct(string ransomNote, string magazine)
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
    public void CanConstructTest()
    {
        // Arrange
        var m1 = "a";
        var r1 = "b";
        var m2 = "aa";
        var r2 = "ab";
        var r3 = "bg";
        var m3 = "aabefjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj";
        // Act & Assert
        Assert.IsFalse(CanConstruct(r1, m1));
        Assert.IsFalse(CanConstruct(r2, m2));
        Assert.IsTrue(CanConstruct(r3, m3));
    }
}
