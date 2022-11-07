namespace LeetCode.CSharp.Benchmarks;

public class CanAttendMeetingsBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(CanAttendMeetings))]
    public void CanAttendMeetingsSetup()
    {
        Int1 = 0;
        Int2 = 100_000;
        Intervals1.Clear();

        for (var i = 0; i < Int2; i++)
        {
            Int1 = Random.Next(Int1, 10);
            Int2 = Random.Next(Random.Next(Int1, 10), 20);
            Intervals1.Add(new Interval(Int1, Int2));
        }
    }

    [Benchmark]
    public void CanAttendMeetings() => Problem.CanAttendMeetings(Intervals1);

    [GlobalCleanup(Target = nameof(CanAttendMeetings))]
    public void CanAttendMeetingsCleanup()
    {
        Int1 = 0;
        Int2 = 0;
        Intervals1.Clear();
    }
}