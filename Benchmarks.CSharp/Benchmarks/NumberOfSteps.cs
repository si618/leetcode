namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void NumberOfSteps()
    {
        Problem.NumberOfSteps(14);
        Problem.NumberOfSteps(8);
        Problem.NumberOfSteps(123);
    }
}