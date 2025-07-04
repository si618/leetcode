﻿namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Unique Paths",
        Difficulty.Medium,
        Category.TwoDDynamicProgramming,
        "https://www.youtube.com/watch?v=IlEsdxuD4lY")]
    public static int UniquePaths(int m, int n)
    {
        // Last row will only have one move (right) for each position
        var row = CreateRow();

        // Start from second last row as last row is already initialised
        for (var r = m - 2; r >= 0; r--)
        {
            var newRow = CreateRow();

            // Last column will only have one move (down) for each position which
            // is already initialised in new row so start from second last column
            // and move from right to left summing value of previous row position
            for (var c = n - 2; c >= 0; c--)
            {
                newRow[c] = newRow[c + 1] + row[c];
            }

            row = newRow;
        }

        // First item in current row is start which is the sum of all unique paths
        return row[0];

        int[] CreateRow()
        {
            var r = new int[n];
            for (var i = 0; i < n; i++)
            {
                r[i] = 1;
            }
            return r;
        }
    }

    [Theory]
    [InlineData(3, 7, 28)]
    [InlineData(3, 3, 6)]
    public void UniquePathsTest(int m, int n, int expected) =>
        UniquePaths(m, n).ShouldBe(expected);
}
