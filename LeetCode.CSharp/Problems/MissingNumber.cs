namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
    "Missing Number",
    Difficulty.Easy,
    Category.BitManipulation,
    "https://www.youtube.com/watch?v=WnPLSRLSANE")]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    public static int MissingNumber(int[] nums) =>
        nums.Length + Enumerable.Range(0, nums.Length).Sum(i => i - nums[i]);

    [Fact]
    public void MissingNumberTest()
    {
        var ex1 = new[] { 3, 0, 1 };
        var ex2 = new[] { 0, 1 };
        var ex3 = new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };

        MissingNumber(ex1).Should().Be(2);
        MissingNumber(ex2).Should().Be(2);
        MissingNumber(ex3).Should().Be(8);
    }
}
