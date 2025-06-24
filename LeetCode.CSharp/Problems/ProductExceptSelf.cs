namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Product of Array Except Self",
        Difficulty.Medium,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=bNvIQI2wAjk")]
    public static int[] ProductExceptSelf(int[] nums)
    {
        var length = nums.Length;
        if (length == 0) return nums;

        var prefix = 1;
        var productArray = new int[length];

        for (var i = 0; i < length; i++)
        {
            productArray[i] = prefix;
            prefix *= nums[i];
        }

        var postfix = 1;

        for (var i = length - 1; i >= 0; i--)
        {
            productArray[i] *= postfix;
            postfix *= nums[i];
        }

        return productArray;
    }

    [Fact]
    public void ProductExceptSelfTest()
    {
        var ex1 = new[] { 1, 2, 3, 4 };
        var ex1Expected = new[] { 24, 12, 8, 6 };
        var ex2 = new[] { -1, 1, 0, -3, 3 };
        var ex2Expected = new[] { 0, 0, 9, 0, 0 };
        var ex3 = Array.Empty<int>();

        ProductExceptSelf(ex1).ShouldBe(ex1Expected);
        ProductExceptSelf(ex2).ShouldBe(ex2Expected);
        ProductExceptSelf(ex3).ShouldBe(ex3);
    }
}
