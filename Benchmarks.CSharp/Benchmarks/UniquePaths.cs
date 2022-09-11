namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void UniquePaths()
    {
        // Inputs from LeetCode
        Problem.UniquePaths(7, 3);
        Problem.UniquePaths(3, 2);

        // Larger inputs for benchmark
        Problem.UniquePaths(10_000, 100);
    }
}