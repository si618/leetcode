namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Problem
{
    [LeetCode("Best Time to Buy and Sell Stock", Difficulty.Easy, Category.TwoPointers)]
    public static int MaxProfit(int[] prices)
    {
        var left = 0;
        var right = 1;
        var maxProfit = 0;

        while (right < prices.Length)
        {
            var buyPrice = prices[left];
            var sellPrice = prices[right];

            if (buyPrice < sellPrice)
            {
                var profit = sellPrice - buyPrice;
                if (profit > maxProfit)
                {
                    maxProfit = profit;
                }
            }
            else
            {
                left = right;
            }

            right++;
        }

        return maxProfit;
    }

    [Test]
    public void MaxProfitTest()
    {
        MaxProfit(new[] { 7, 1, 5, 3, 6, 4 }).Should().Be(5);
        MaxProfit(new[] { 7, 6, 4, 3, 1 }).Should().Be(0);
    }
}
