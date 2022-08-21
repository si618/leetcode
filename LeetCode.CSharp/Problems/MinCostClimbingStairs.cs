namespace LeetCode;

using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

public sealed partial class Problem
{
    [LeetCode(
        "Min Cost Climbing Stairs",
        Difficulty.Easy,
        Category.OneDDynamicProgramming)]
    public static int MinCostClimbingStairs(int[] cost)
    {
        if (cost.Length is < 3 or > 999)
        {
            throw new ArgumentOutOfRangeException(nameof(cost));
        }

        // Add zero to end of array with no cost to cater for last step
        var minCost = new int[cost.Length + 1];
        Array.Copy(cost, minCost, cost.Length);
        minCost[^1] = 0;

        // Start from the top of the stairs and work backwards to solve each sub-problem
        for (var i = minCost.Length - 3; i >= 0; i--)
        {
            // Memoize the minimum cost to avoid recalculation
            minCost[i] += Math.Min(minCost[i + 1], minCost[i + 2]);
        }

        return Math.Min(minCost[0], minCost[1]);
    }

    [Test]
    public void MinCostClimbingStairsTest()
    {
            Action lessThan = () => MinCostClimbingStairs(new int [2]);
            Action moreThan = () => MinCostClimbingStairs(new int [1_000]);

            lessThan.Should().Throw<ArgumentOutOfRangeException>();
            moreThan.Should().Throw<ArgumentOutOfRangeException>();
            MinCostClimbingStairs(new []{ 10, 15, 20 }).Should().Be(15);
            MinCostClimbingStairs(new []{ 1, 100, 1, 1, 1, 100, 1, 1, 100, 1}).Should().Be(6);
    }
}
