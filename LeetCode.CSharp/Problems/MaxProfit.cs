namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Best Time to Buy and Sell Stock", Difficulty.Easy, Category.NotInNeetCode)]
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

    [Fact]
    public void MaxProfitTest()
    {
        MaxProfit([7, 1, 5, 3, 6, 4]).ShouldBe(5);
        MaxProfit([7, 6, 4, 3, 1]).ShouldBe(0);
    }
}
