namespace LeetCode.CSharp.Benchmarks;

public class NumberOfStepsBenchmark : Benchmark
{
    [Benchmark]
    public int NumberOfSteps()
    {
        return Problem.NumberOfSteps(1_000_000_000);
    }
}