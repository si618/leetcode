﻿namespace Leetcode.Submissions;
using NUnit.Framework;

public class TwoSumTest
{
    public static int[] TwoSum(int[] nums, int target)
    {
        if (nums.Length < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(nums));
        }
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] { i, j };
                }
            }
        }
        throw new ArgumentOutOfRangeException(nameof(target));
    }

    [Test]
    public void Test()
    {
        // Arrange
        var ex1 = new[] { 2, 7, 11, 15 };
        var ex2 = new[] { 3, 2, 4 };
        var ex3 = new[] { 3, 3 };
        // Act & Assert
        Assert.AreEqual(new[] { 0, 1 }, TwoSum(ex1, 9));
        Assert.AreEqual(new[] { 1, 2 }, TwoSum(ex2, 6));
        Assert.AreEqual(new[] { 0, 1 }, TwoSum(ex3, 6));
    }
}
