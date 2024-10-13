namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Richest Customer Wealth", Difficulty.Easy, Category.NotInNeetCode)]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    public static int MaximumWealth(int[][] accounts) =>
        accounts.Select(account => account.Sum()).Max();

    [Fact]
    public void MaximumWealthTest()
    {
        var ex1 = new int[][]
        {
            [1, 2, 3],
            [3, 2, 1]
        };
        var ex2 = new int[][]
        {
            [1, 5],
            [7, 3],
            [3, 5]
        };

        MaximumWealth(ex1).Should().Be(6);
        MaximumWealth(ex2).Should().Be(10);
    }
}
