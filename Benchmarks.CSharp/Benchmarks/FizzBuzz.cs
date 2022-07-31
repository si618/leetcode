namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void FizzBuzz()
    {
        Challenge.FizzBuzz(3);
        Challenge.FizzBuzz(5);
        Challenge.FizzBuzz(15);
    }
}
