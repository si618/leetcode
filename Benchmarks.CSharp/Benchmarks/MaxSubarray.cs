namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MaxSubarray()
    {
        // Inputs from LeetCode
        var ex1 = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        var ex2 = new[] { 1 };
        var ex3 = new[] { 5, 4, -1, 7, 8 };

        // Larger inputs for benchmark
        var random = new Random(618);
        var ex4 = new int[100_000];
        for (var i = 0; i < ex4.Length; i++)
        {
            // Generate some negative and positive integers
            ex4[i] = random.Next(1, 20) - 10;
        }

        Problem.MaxSubarray(ex1);
        Problem.MaxSubarray(ex2);
        Problem.MaxSubarray(ex3);
        Problem.MaxSubarray(ex4);
    }
}
