namespace Leetcode.Benchmarks;
using BenchmarkDotNet.Attributes;
using global::Leetcode.Submissions;

public class Leetcode
{
    [Benchmark]
    public void IsPalindrome()
    {
        var isTrue = new ListNode(1,
            new ListNode(2,
                new ListNode(2,
                    new ListNode(1, null))));
        var isFalse = new ListNode(1, new ListNode(2, null));
        IsPalindromeTest.IsPalindrome(isTrue);
        IsPalindromeTest.IsPalindrome(isFalse);
    }

    [Benchmark]
    public void RomanToInt()
    {
        RomanToIntTest.RomanToInt("III");
        RomanToIntTest.RomanToInt("LVIII");
        RomanToIntTest.RomanToInt("MCMXCIV");
    }
}