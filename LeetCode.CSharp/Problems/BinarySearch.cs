﻿namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Binary Search",
        Difficulty.Easy,
        Category.BinarySearch,
        "https://www.youtube.com/watch?v=s4DPM8ct1pI")]
    public static int BinarySearch(int[] nums, int target)
    {
        var leftPtr = 0;
        var rightPtr = nums.Length - 1;

        while (leftPtr <= rightPtr)
        {
            // Find mid-point without risk of overflowing
            var midPtr = leftPtr + (rightPtr - leftPtr) / 2;
            var midVal = nums[midPtr];

            if (midVal > target)
            {
                rightPtr = midPtr - 1;
            }
            else if (midVal < target)
            {
                leftPtr = midPtr + 1;
            }
            else
            {
                return midPtr;
            }
        }

        // Target not found
        return -1;
    }

    [Theory]
    [InlineData(new[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
    [InlineData(new[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
    [InlineData(new int[] { }, 0, -1)]
    public void BinarySearchTest(int[] nums, int target, int expected) =>
        BinarySearch(nums, target).ShouldBe(expected);
}
