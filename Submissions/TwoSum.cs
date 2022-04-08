namespace LeetCode;
using NUnit.Framework;

public sealed partial class Submission
{
    public static int[] TwoSum(int[] nums, int target)
    {
        if (nums.Length < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(nums));
        }
        for (var i = 0; i < nums.Length; i++)
        {
            // Test all remaining indexes for target match
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
    public void TwoSumTest()
    {
        // Arrange
        var ex1 = new[] { 2, 7, 11, 15 };
        var ex2 = new[] { 3, 2, 4 };
        var ex3 = new[] { 3, 3 };
        // Act & Assert
        Assert.That(TwoSum(ex1, 9), Is.EqualTo(new[] { 0, 1 }));
        Assert.That(TwoSum(ex2, 6), Is.EqualTo(new[] { 1, 2 }));
        Assert.That(TwoSum(ex3, 6), Is.EqualTo(new[] { 0, 1 }));
    }
}
