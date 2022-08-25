namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void FizzBuzz()
    {
        Problem.FizzBuzz(3);
        Problem.FizzBuzz(5);
        Problem.FizzBuzz(15);
    }
}
