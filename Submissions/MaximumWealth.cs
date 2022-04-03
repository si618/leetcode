namespace Leetcode.Submissions;
using NUnit.Framework;

public class MaximumWealthTest
{
    public static int MaximumWealth(int[][] accounts)
    {
        return accounts.Select(account => account.Sum()).Max();
    }

    [Test]
    public void Test()
    {
        // Arrange
        var ex1 = new int[][]
        {
            new int[] { 1, 2, 3 },
            new int[] { 3, 2, 1 }
        };
        var ex2 = new int[][]
        {
            new int[] { 1, 5 },
            new int[] { 7, 3 },
            new int[] { 3, 5 }
        };
        // Act & Assert
        Assert.AreEqual(6, MaximumWealth(ex1));
        Assert.AreEqual(10, MaximumWealth(ex2));
    }
}
