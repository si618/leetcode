namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(KWeakestRows))]
    public void KWeakestRowsSetup()
    {
        var temp = Enumerable.Range(1, 1_000).ToArray();
        IntArray3 = new int[10_000][];
        for (var i = 0; i < 10_000; i++)
        {
            IntArray3[i] = temp;
        }
    }

    [Benchmark]
    public int[] KWeakestRows()
    {
        return Problem.KWeakestRows(IntArray3, 9_999);
    }
}