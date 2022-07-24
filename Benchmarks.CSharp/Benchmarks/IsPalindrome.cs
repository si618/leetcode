namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsPalindrome()
    {
        var isPalindrome = new ListNode(1,
            new ListNode(2,
            new ListNode(2,
            new ListNode(1))));
        var isNotPalindrome = new ListNode(1,
            new ListNode(2));
        Submission.IsPalindrome(isPalindrome);
        Submission.IsPalindrome(isNotPalindrome);
    }
}