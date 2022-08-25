namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void AreParenthesesValid()
    {
        Problem.AreParenthesesValid("()");
        Problem.AreParenthesesValid("()[]{}");
        Problem.AreParenthesesValid("(]");
    }
}