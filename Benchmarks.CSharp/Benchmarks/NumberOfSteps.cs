namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void NumberOfSteps()
    {
        Challenge.NumberOfSteps(14);
        Challenge.NumberOfSteps(8);
        Challenge.NumberOfSteps(123);
    }
}