namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Problem
{
    [LeetCode("Richest Customer Wealth", Difficulty.Easy, Category.NotInNeetCode)]
    // ReSharper disable once ParameterTypeCanBeEnumerable.Global
    public static int MaximumWealth(int[][] accounts)
    {
        return accounts.Select(account => account.Sum()).Max();
    }

    [Test]
    public void MaximumWealthTest()
    {
        var ex1 = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 3, 2, 1 }
        };
        var ex2 = new[]
        {
            new[] { 1, 5 },
            new[] { 7, 3 },
            new[] { 3, 5 }
        };

        MaximumWealth(ex1).Should().Be(6);
        MaximumWealth(ex2).Should().Be(10);
    }
}
