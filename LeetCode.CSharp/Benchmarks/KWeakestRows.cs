namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [GlobalSetup(Target = nameof(KWeakestRows))]
    public void KWeakestRowsSetup()
    {
        IntArray1 = Enumerable.Range(1, 1_000).ToArray();
        IntArrayMulti = new int[10_000][];
        for (var i = 0; i < IntArrayMulti.Length; i++)
        {
            IntArrayMulti[i] = IntArray1;
        }
    }

    [Benchmark]
    public int[] KWeakestRows()
    {
        return Problem.KWeakestRows(IntArrayMulti, 9_999);
    }

    [GlobalCleanup(Target = nameof(KWeakestRows))]
    public void KWeakestRowsCleanup()
    {
        IntArray1 = Array.Empty<int>();
        IntArrayMulti = Array.Empty<int[]>();
    }
}