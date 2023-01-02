namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Maximum Subarray",
        Difficulty.Medium,
        Category.Greedy,
        "https://www.youtube.com/watch?v=5WZl3MMT0Eg")]
    public static int MaxSubarray(int[] nums)
    {
        var maxSub = nums[0];
        var curSum = 0;

        foreach (var i in nums)
        {
            // Reset if previous calculation was negative
            if (curSum < 0)
            {
                curSum = 0;
            }
            curSum += i;
            maxSub = Math.Max(curSum, maxSub);
        }

        return maxSub;
    }

    [Fact]
    public void MaxSubarrayTest()
    {
        var ex1 = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        var ex2 = new[] { 1 };
        var ex3 = new[] { 5, 4, -1, 7, 8 };

        MaxSubarray(ex1).Should().Be(6);
        MaxSubarray(ex2).Should().Be(1);
        MaxSubarray(ex3).Should().Be(23);
    }
}
