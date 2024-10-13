namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Valid Parentheses",
        Difficulty.Easy,
        Category.Stack,
        "https://www.youtube.com/watch?v=WTzjTskDFMg")]
    public static bool ValidParentheses(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return false;
        }

        var pairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (pairs.TryGetValue(c, out var pair))
            {
                if (!stack.TryPop(out var top) || pair != top)
                {
                    return false;
                }
            }
            else
            {
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }

    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("([{}])", true)]
    [InlineData("{[[((()))]]}", true)]
    [InlineData("(())[[[]]]{{{{}}}}", true)]
    [InlineData("", false)]
    [InlineData("(", false)]
    [InlineData("(]", false)]
    [InlineData("][", false)]
    public void ValidParenthesesTest(string s, bool expected) => ValidParentheses(s).Should().Be(expected);
}
