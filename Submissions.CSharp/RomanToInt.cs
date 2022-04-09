namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

public sealed partial class Submission
{
    [LeetCode(Difficulty.Easy, Category.None)]

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
    public void RomanToIntTest()
    {
        RomanToInt("III").Should().Be(3);
        RomanToInt("LVIII").Should().Be(58);
        RomanToInt("MCMXCIV").Should().Be(1994);
        RomanToInt("MMXXII").Should().Be(2022);
    }
}
