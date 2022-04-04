namespace Leetcode.Submissions;
using NUnit.Framework;

public class KWeakestRowsTest
{
    public static int[] KWeakestRows(int[][] mat, int k)
    {
        return mat
            .Select((row, index) =>
                (Strength: row.Count(x => x == 1), Index: index))
            .OrderBy(x => x.Strength)
            .Take(k)
            .Select(x => x.Index)
            .ToArray();
    }

    [Test]
    public void Test()
    {
        // Arrange
        var ex1 = new int[][]
        {
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 0 },
            new[] { 1, 0, 0, 0, 0 },
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 1 }
        };
        var ex2 = new int[][]
        {
            new[] { 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1 },
            new[] { 1, 0, 0, 0 },
            new[] { 1, 0, 0, 0 }
        };
        // Act & Assert
        Assert.AreEqual(new[] { 2, 0, 3 }, KWeakestRows(ex1, 3));
        Assert.AreEqual(new[] { 0, 2 }, KWeakestRows(ex2, 2));
    }
}
