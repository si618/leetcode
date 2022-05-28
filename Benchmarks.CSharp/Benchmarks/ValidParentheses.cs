namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void AreParenthesesValid()
    {
        Submission.AreParenthesesValid("()");
        Submission.AreParenthesesValid("()[]{}");
        Submission.AreParenthesesValid("(]");
    }
}