namespace LeetCode;
using NUnit.Framework;

public partial class Submission
{
    public static int MaximumWealth(int[][] accounts)
    {
        return accounts.Select(account => account.Sum()).Max();
    }

    [Test]
    public void MaximumWealthTest()
    {
        // Arrange
        var ex1 = new int[][]
        {
            new[] { 1, 2, 3 },
            new[] { 3, 2, 1 }
        };
        var ex2 = new int[][]
        {
            new[] { 1, 5 },
            new[] { 7, 3 },
            new[] { 3, 5 }
        };
        // Act & Assert
        Assert.AreEqual(6, MaximumWealth(ex1));
        Assert.AreEqual(10, MaximumWealth(ex2));
    }
}
