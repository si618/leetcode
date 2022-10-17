namespace LeetCode.CSharp.Benchmarks;

public class MaximumWealthBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(MaximumWealth))]
    public void MaximumWealthSetup()
    {
        IntArray1 = Enumerable.Range(1, 1_000).ToArray();
        IntArrayMulti = new int[10_000][];
        for (var i = 0; i < IntArrayMulti.Length; i++)
        {
            IntArrayMulti[i] = IntArray1;
        }
    }

    [Benchmark]
    public int MaximumWealth()
    {
        return Problem.MaximumWealth(IntArrayMulti);
    }

    [GlobalCleanup(Target = nameof(MaximumWealth))]
    public void MaximumWealthCleanup()
    {
        IntArray1 = Array.Empty<int>();
        IntArrayMulti = Array.Empty<int[]>();
    }
}