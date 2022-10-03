namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [GlobalSetup(Target = nameof(AreParenthesesValid))]
    public void AreParenthesesValidSetup()
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
    public bool AreParenthesesValid()
    {
        return Problem.AreParenthesesValid(String1);
    }

    [GlobalCleanup(Target = nameof(AreParenthesesValid))]
    public void AreParenthesesValidCleanup()
    {
        Int1 = 0;
        String1 = string.Empty;
    }
}