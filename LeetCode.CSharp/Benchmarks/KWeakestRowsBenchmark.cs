namespace LeetCode.CSharp.Benchmarks;

public class KWeakestRowsBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(KWeakestRows))]
    public void KWeakestRowsSetup()
    {
        IntArray1 = [.. Enumerable.Range(1, 1_000)];
        IntArrayMulti1 = new int[1_000][];
        for (var i = 0; i < IntArrayMulti1.Length; i++)
        {
            IntArrayMulti1[i] = IntArray1;
        }
    }

    [Benchmark]
    public int[] KWeakestRows() => Problem.KWeakestRows(IntArrayMulti1, 999);

    [GlobalCleanup(Target = nameof(KWeakestRows))]
    public void KWeakestRowsCleanup()
    {
        IntArray1 = [];
        IntArrayMulti1 = [];
    }
}