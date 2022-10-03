namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [GlobalSetup(Target = nameof(Subsets))]
    public void SubsetsSetup()
    {
        var random = new Random(42);
        IntArray1 = new int[100_000];
        for (var i = 0; i < IntArray1.Length; i++)
        {
            IntArray1[i] = i % random.Next(1, 10);
        }
    }

    [Benchmark]
    public IList<IList<int>> Subsets()
    {
        return Problem.Subsets(new[] { 1, 2, 3 });
    }

    [GlobalCleanup(Target = nameof(Subsets))]
    public void SubsetsCleanup()
    {
        IntArray1 = Array.Empty<int>();
    }
}