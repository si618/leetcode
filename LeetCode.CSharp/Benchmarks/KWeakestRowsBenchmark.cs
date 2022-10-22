namespace LeetCode.CSharp.Benchmarks;

public class KWeakestRowsBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(KWeakestRows))]
    public void KWeakestRowsSetup()
    {
        IntArray1 = Enumerable.Range(1, 1_000).ToArray();
        IntArrayMulti = new int[1_000][];
        for (var i = 0; i < IntArrayMulti.Length; i++)
        {
            IntArrayMulti[i] = IntArray1;
        }
    }

    [Benchmark]
    public int[] KWeakestRows() => Problem.KWeakestRows(IntArrayMulti, 999);

    [GlobalCleanup(Target = nameof(KWeakestRows))]
    public void KWeakestRowsCleanup()
    {
        IntArray1 = Array.Empty<int>();
        IntArrayMulti = Array.Empty<int[]>();
    }
}