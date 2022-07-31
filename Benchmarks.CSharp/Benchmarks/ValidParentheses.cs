namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void AreParenthesesValid()
    {
        Challenge.AreParenthesesValid("()");
        Challenge.AreParenthesesValid("()[]{}");
        Challenge.AreParenthesesValid("(]");
    }
}