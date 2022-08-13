namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsPalindrome()
    {
        var isPalindrome = new ListNode(new[] { 1, 2, 2, 1 });
        var isNotPalindrome = new ListNode(new[] { 1, 2 });
        Problem.IsPalindrome(isPalindrome);
        Problem.IsPalindrome(isNotPalindrome);
    }
}