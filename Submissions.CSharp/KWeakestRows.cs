namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode(Difficulty.Easy, Category.None)]

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
    public void KWeakestRowsTest()
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
        KWeakestRows(ex1, 3).Should().Equal(new[] { 2, 0, 3 });
        KWeakestRows(ex2, 2).Should().Equal(new[] { 0, 2 });
    }
}
