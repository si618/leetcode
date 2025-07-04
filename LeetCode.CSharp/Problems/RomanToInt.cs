﻿namespace LeetCode.CSharp.Problems;

using System.Collections.Generic;

public sealed partial class Problem
{
    [LeetCode("Roman to Integer", Difficulty.Easy, Category.NotInNeetCode)]
    public static int RomanToInt(string s)
    {
        var romanValues = new Dictionary<char, int>
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

    [Fact]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void RomanToIntTest()
    {
        RomanToInt("III").ShouldBe(3);
        RomanToInt("LVIII").ShouldBe(58);
        RomanToInt("MCMXCIV").ShouldBe(1994);
        RomanToInt("MMXXII").ShouldBe(2022);
    }
}
