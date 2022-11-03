namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
        "Insert Interval",
        Difficulty.Medium,
        Category.Intervals,
        "https://www.youtube.com/watch?v=A8NUOmlwOlM")]
    public static int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = Array.Empty<int[]>();

        foreach (var interval in intervals)
        {

        }

        return result;
    }

    [Fact]
    public void InsertTest()
    {
        // var ex1I = new[] { new[] { 1, 3 }, new[] { 6, 9 } };
        // var ex1N = new[] { 2, 5 };
        // var ex2I = new[] { new[] { 1, 2 }, new[] { 3, 5 }, new[] { 6, 7 }, new[] { 8, 10 }, new[] { 12, 16 } };
        // var ex2N = new[] { 4, 8 };
        //
        // Insert(ex1I, ex1N).Should().Equal(new[] { 1, 5 });
        // Insert(ex2I, ex2N).Should().Equal(new[] { 6, 9 });
    }
}
