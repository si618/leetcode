namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Single Number",
        Difficulty.Easy,
        Category.BitManipulation,
        "https://www.youtube.com/watch?v=qMPX1AOa83k")]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    public static int SingleNumber(int[] digits) => digits.Aggregate((x, y) => x ^ y);

    [Fact]
    public void SingleNumberTest()
    {
        var ex1 = new[] { 2, 2, 1 };
        var ex2 = new[] { 4, 1, 2, 1, 2 };
        var ex3 = new[] { 1 };

        SingleNumber(ex1).Should().Be(1);
        SingleNumber(ex2).Should().Be(4);
        SingleNumber(ex3).Should().Be(1);
    }
}
