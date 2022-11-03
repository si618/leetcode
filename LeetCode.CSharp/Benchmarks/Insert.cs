namespace LeetCode.CSharp.Benchmarks;

public class InsertBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(Insert))]
    public void InsertSetup()
    {
        Int1 = 0;
        Int2 = 1_000;
        IntArrayMulti1 = new int[1_000][];

        for (var i = 0; i < IntArrayMulti1.Length; i++)
        {
            Int1 = Random.Next(Int1 + 1, Int2);
            Int2 = Random.Next(Int1 + 1, Int1 + 1_000);
            IntArrayMulti1[i] = new[] { Int1, Int2 };
        }
    }

    [Benchmark]
    public void Insert() => Problem.Insert(IntArrayMulti1, IntArray2);

    [GlobalCleanup(Target = nameof(Insert))]
    public void InsertCleanup()
    {
        Int1 = 0;
        Int2 = 0;
        IntArrayMulti1 = Array.Empty<int[]>();
    }
}