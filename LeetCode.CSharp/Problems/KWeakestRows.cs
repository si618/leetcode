namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("The K Weakest Rows in a Matrix", Difficulty.Easy, Category.NotInNeetCode)]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    public static int[] KWeakestRows(int[][] mat, int k) =>
        mat.Select((row, index) => (Strength: row.Count(x => x == 1), Index: index))
            .OrderBy(x => x.Strength)
            .Take(k)
            .Select(x => x.Index)
            .ToArray();

    [Fact]
    public void KWeakestRowsTest()
    {
        var ex1 = new int[][]
        {
            [1, 1, 0, 0, 0],
            [1, 1, 1, 1, 0],
            [1, 0, 0, 0, 0],
            [1, 1, 0, 0, 0],
            [1, 1, 1, 1, 1]
        };
        var ex2 = new int[][]
        {
            [1, 0, 0, 0],
            [1, 1, 1, 1],
            [1, 0, 0, 0],
            [1, 0, 0, 0]
        };

        KWeakestRows(ex1, 3).Should().Equal(2, 0, 3);
        KWeakestRows(ex2, 2).Should().Equal(0, 2);
    }
}
