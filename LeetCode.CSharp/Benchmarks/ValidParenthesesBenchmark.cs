namespace LeetCode.CSharp.Benchmarks;

public class ValidParenthesesBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(ValidParentheses))]
    public void ValidParenthesesSetup()
    {
        Int1 = 10_000;
        String1 = new StringBuilder()
            .Append(new string('(', Int1))
            .Append(new string('[', Int1))
            .Append(new string('{', Int1))
            .Append(new string('}', Int1))
            .Append(new string(']', Int1))
            .Append(new string(')', Int1))
            .ToString();
    }

    [Benchmark]
    public bool ValidParentheses() => Problem.ValidParentheses(String1);

    [GlobalCleanup(Target = nameof(ValidParentheses))]
    public void ValidParenthesesCleanup()
    {
        Int1 = 0;
        String1 = string.Empty;
    }
}