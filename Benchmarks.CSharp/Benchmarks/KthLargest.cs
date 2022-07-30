namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void KthLargest()
    {
        var ex1 = new Submission.KthLargest(3, new[] { 4, 5, 8, 2 });
        ex1.Add(3);
        ex1.Add(5);
        ex1.Add(10);
        ex1.Add(9);
        ex1.Add(4);
    }
}