namespace LeetCode;

using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Payloads;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode("Valid Parentheses", Difficulty.Easy, Category.Stack)]
    public static bool AreParenthesesValid(string s)
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
            if (pairs.ContainsKey(c))
            {
                if (!stack.TryPop(out var top) || pairs[c] != top)
                {
                    return false;
                }
            }
            else
            {
                stack.Push(c);
            }
        }

        return !stack.Any();
    }

    [Test]
    public void AreParenthesesValidTest()
    {
        AreParenthesesValid("()").Should().BeTrue();
        AreParenthesesValid("()[]{}").Should().BeTrue();
        AreParenthesesValid("([{}])").Should().BeTrue();
        AreParenthesesValid("{[[((()))]]}").Should().BeTrue();
        AreParenthesesValid("(())[[[]]]{{{{}}}}").Should().BeTrue();
        AreParenthesesValid("").Should().BeFalse();
        AreParenthesesValid("(").Should().BeFalse();
        AreParenthesesValid("(]").Should().BeFalse();
        AreParenthesesValid("][").Should().BeFalse();
    }
}
