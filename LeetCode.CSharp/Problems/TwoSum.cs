namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Two Sum",
        Difficulty.Easy,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=KLlXCFG5TnA")]
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

    [Fact]
    public void TwoSumTest()
    {
        var ex1 = new[] { 2, 7, 11, 15 };
        var ex2 = new[] { 3, 2, 4 };
        var ex3 = new[] { 3, 3 };
        var ex4 = new[] { 3 };

        TwoSum(ex1, 9).Should().Equal(0, 1);
        TwoSum(ex2, 6).Should().Equal(1, 2);
        TwoSum(ex3, 6).Should().Equal(0, 1);
        var action = () => TwoSum(ex4, 0);
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}
