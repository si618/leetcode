namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
        "Can Attend Meetings",
        Difficulty.Easy,
        Category.Intervals,
        "https://www.youtube.com/watch?v=PaJxqZVPhbg")]
    // ReSharper disable once ParameterTypeCanBeEnumerable.Global
    public static bool CanAttendMeetings(List<Interval> intervals)
    {
        var sortedIntervals = intervals.OrderBy(i => i.start).ToArray();

        for (var i = 1; i < sortedIntervals.Length;)
        {
            var previousInterval = sortedIntervals[i - 1];
            var currentInterval = sortedIntervals[i++];

            if (currentInterval.start < previousInterval.end)
            {
                return false;
            }
        }

        return true;
    }

    [Fact]
    public void CanAttendMeetingsTest()
    {
        var ex1 = new List<Interval>
        {
            new(0, 30),
            new(5, 10),
            new(15, 20)
        };
        var ex2 = new List<Interval>
        {
            new(5, 8),
            new(9, 15)
        };

        CanAttendMeetings(ex1).Should().BeFalse();
        CanAttendMeetings(ex2).Should().BeTrue();
    }
}
