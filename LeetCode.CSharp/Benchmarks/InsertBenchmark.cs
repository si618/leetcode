namespace LeetCode.CSharp.Benchmarks;

public class InsertBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(Insert))]
    public void InsertSetup()
    {
        Int1 = 0;
        Int2 = 10_000;
        IntArrayMulti1 = new int[10_000][];

        for (var i = 0; i < 10_000; i++)
        {
            Int1 = Random.Next(0, 10_000);
            Int2 = Random.Next(Int1, Int1 + 10_000);
            IntArrayMulti1[i] = new[] { Int1, Int2 };
        }

        IntArray2 = new[]
        {
            IntArrayMulti1[9_999][0] + 1,
            IntArrayMulti1[9_999][0] + 10
        };
    }

    [Benchmark]
    public void Insert() => Problem.Insert(IntArrayMulti1, IntArray2);

    [GlobalCleanup(Target = nameof(Insert))]
    public void InsertCleanup()
    {
        Int1 = 0;
        Int2 = 0;
        IntArrayMulti1 = Array.Empty<int[]>();
        IntArray2 = Array.Empty<int>();
    }
}