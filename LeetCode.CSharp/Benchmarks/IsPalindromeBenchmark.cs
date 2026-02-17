namespace LeetCode.CSharp.Benchmarks;

public class IsPalindromeBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(IsPalindrome))]
    public void IsPalindromeSetup()
    {
        IntArray1 = [.. Enumerable.Range(1, 10_000)];
        IntArray2 = [.. IntArray1.Reverse()];
        ListNode1 = new ListNode(IntArray1.Concat(IntArray2).ToArray());
    }

    [Benchmark]
    public bool IsPalindrome() => Problem.IsPalindrome(ListNode1);

    [GlobalCleanup(Target = nameof(IsPalindrome))]
    public void IsPalindromeCleanup()
    {
        IntArray1 = [];
        IntArray2 = [];
        ListNode1 = new ListNode();
    }
}