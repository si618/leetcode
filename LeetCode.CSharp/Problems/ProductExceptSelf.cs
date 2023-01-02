namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Product of Array Except Self",
        Difficulty.Medium,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=bNvIQI2wAjk")]
    public static int[] ProductExceptSelf(int[] nums)
    {
        if (nums.Length == 0) return nums;

        var prefix = 1;
        var postfix = 1;
        var result = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = prefix;
            prefix *= nums[i];
        }

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= postfix;
            postfix *= nums[i];
        }

        return result;
    }

    [Fact]
    public void ProductExceptSelfTest()
    {
        var ex1 = new[] { 1, 2, 3, 4 };
        var ex1Expected = new[] { 24, 12, 8, 6 };
        var ex2 = new[] { -1, 1, 0, -3, 3 };
        var ex2Expected = new[] { 0, 0, 9, 0, 0 };
        var ex3 = Array.Empty<int>();

        ProductExceptSelf(ex1).Should().Equal(ex1Expected);
        ProductExceptSelf(ex2).Should().Equal(ex2Expected);
        ProductExceptSelf(ex3).Should().Equal(ex3);
    }
}
