namespace LeetCode.CSharp.Benchmarks;

public class MaximumWealthBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(MaximumWealth))]
    public void MaximumWealthSetup()
    {
        IntArray1 = [.. Enumerable.Range(1, 1_000)];
        IntArrayMulti1 = new int[10_000][];
        for (var i = 0; i < IntArrayMulti1.Length; i++)
        {
            IntArrayMulti1[i] = IntArray1;
        }
    }

    [Benchmark]
    public int MaximumWealth() => Problem.MaximumWealth(IntArrayMulti1);

    [GlobalCleanup(Target = nameof(MaximumWealth))]
    public void MaximumWealthCleanup()
    {
        IntArray1 = [];
        IntArrayMulti1 = [];
    }
}