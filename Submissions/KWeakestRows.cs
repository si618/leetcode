namespace Leetcode.Submissions;
using NUnit.Framework;

public class KWeakestRowsTest
{
    public static int[] KWeakestRows(int[][] mat, int k)
    {
        return mat
            .Select((row, index) => (strength: row.Count(x => x == 1), index))
            .OrderBy(x => x.strength)
            .Take(k)
            .Select(x => x.index)
            .ToArray();
    }

    [Test]
    public void Test()
    {
        // Arrange
        var ex1 = new int[][]
        {
            new int[] { 1, 1, 0, 0, 0 },
            new int[] { 1, 1, 1, 1, 0 },
            new int[] { 1, 0, 0, 0, 0 },
            new int[] { 1, 1, 0, 0, 0 },
            new int[] { 1, 1, 1, 1, 1 }
        };
        var ex2 = new int[][]
        {
            new int[] { 1, 0, 0, 0 },
            new int[] { 1, 1, 1, 1 },
            new int[] { 1, 0, 0, 0 },
            new int[] { 1, 0, 0, 0 }
        };
        // Act & Assert
        Assert.AreEqual(new int[] { 2, 0, 3 }, KWeakestRows(ex1, 3));
        Assert.AreEqual(new int[] { 0, 2 }, KWeakestRows(ex2, 2));
    }
}
