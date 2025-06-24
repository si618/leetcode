namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Insert Interval",
        Difficulty.Medium,
        Category.Intervals,
        "https://www.youtube.com/watch?v=A8NUOmlwOlM")]
    public static int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();

        for (var i = 0; i < intervals.Length; i++)
        {
            var intervalStart = intervals[i][0];
            var newIntervalEnd = newInterval[1];

            if (newIntervalEnd < intervalStart)
            {
                result.Add(newInterval);
                result.AddRange(intervals[i..]);

                // Best case of non-overlapping new interval ends before intervals start
                return result.ToArray();
            }

            var intervalEnd = intervals[i][1];
            var newIntervalStart = newInterval[0];

            if (newIntervalStart > intervalEnd)
            {
                // New interval is non-overlapping with current interval
                result.Add(intervals[i]);
            }
            else
            {
                // New interval is overlapping so merge with current interval
                newInterval = new[]
                {
                    Math.Min(intervalStart, newIntervalStart),
                    Math.Max(intervalEnd, newIntervalEnd)
                };
            }
        }

        // New interval must be the last interval in list
        result.Add(newInterval);

        return result.ToArray();
    }

    [Fact]
    public void InsertTest()
    {
        var ex1Intervals = new[]
        {
            new[] { 1, 3 },
            new[] { 6, 9 }
        };
        var ex1NewInterval = new[] { 2, 5 };
        var ex1Expected = new[]
        {
            new[] { 1, 5 },
            new[] { 6, 9 }
        };

        var ex2Intervals = new[]
        {
            new[] { 1, 2 },
            new[] { 3, 5 },
            new[] { 6, 7 },
            new[] { 8, 10 },
            new[] { 12, 16 }
        };
        var ex2NewInterval = new[] { 4, 8 };
        var ex2Expected = new[]
        {
            new[] { 1, 2 },
            new[] { 3, 10 },
            new[] { 12, 16 }
        };

        Insert(ex1Intervals, ex1NewInterval).ShouldBe(ex1Expected);
        Insert(ex2Intervals, ex2NewInterval).ShouldBe(ex2Expected);
    }
}
