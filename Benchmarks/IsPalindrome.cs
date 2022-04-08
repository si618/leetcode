namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class Benchmark
{
    [Benchmark]
    public void IsPalindrome()
    {
        var isPalindrome = new ListNode(1,
            new ListNode(2,
            new ListNode(2,
            new ListNode(1, null))));
        var isNotPalindrome = new ListNode(1,
            new ListNode(2, null));
        Submission.IsPalindrome(isPalindrome);
        Submission.IsPalindrome(isNotPalindrome);
    }
}