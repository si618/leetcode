﻿namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Min Cost Climbing Stairs",
        Difficulty.Easy,
        Category.OneDDynamicProgramming,
        "https://www.youtube.com/watch?v=ktmzAZWkEZ0")]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    public static int MinCostClimbingStairs(int[] cost)
    {
        // Add zero to end of array with no cost to cater for last step
        var minCost = cost.Append(0).ToArray();

        // Start from the top of the stairs and work backwards to solve each sub-problem
        for (var i = minCost.Length - 3; i >= 0; i--)
        {
            // Memoize the minimum cost to avoid recalculation
            minCost[i] += Math.Min(minCost[i + 1], minCost[i + 2]);
        }

        return Math.Min(minCost[0], minCost[1]);
    }

    [Theory]
    [InlineData(new[] { 10, 15, 20 }, 15)]
    [InlineData(new[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
    public void MinCostClimbingStairsTest(int[] cost, int expected) =>
        MinCostClimbingStairs(cost).ShouldBe(expected);
}
