namespace Leetcode.Submissions;
using NUnit.Framework;
using System.Collections.Generic;

public class RomanToIntTest
{
    public static int RomanToInt(string s)
    {
        var romanValues = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1_000 }
        };

        var result = 0;
        var length = s.Length - 1;
        for (var i = length; i >= 0; i--)
        {
            var romanCharAsInt = romanValues[s[i]];
            if (i < length)
            {
                result = romanCharAsInt >= romanValues[s[i + 1]]
                    ? result + romanCharAsInt
                    : result - romanCharAsInt;
            }
            else
            {
                result += romanCharAsInt;
            }
        }
        return result;
    }

    [Test]
    public void Test()
    {
        // Arrange
        var iii = "III";
        var lviii = "LVIII";
        var mcmxciv = "MCMXCIV";
        var mmxxii = "MMXXII";
        // Act & Assert
        Assert.AreEqual(3, RomanToInt(iii));
        Assert.AreEqual(58, RomanToInt(lviii));
        Assert.AreEqual(1994, RomanToInt(mcmxciv));
        Assert.AreEqual(2022, RomanToInt(mmxxii));
    }
}
