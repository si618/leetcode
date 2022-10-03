namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [GlobalSetup(Target = nameof(IsPalindrome))]
    public void IsPalindromeSetup()
    {
        IntArray1 = Enumerable.Range(1, 10_000).ToArray();
        IntArray2 = IntArray1.Reverse().ToArray();
        ListNode1 = new ListNode(IntArray1.Concat(IntArray2).ToArray());
    }

    [Benchmark]
    public bool IsPalindrome()
    {
        return Problem.IsPalindrome(ListNode1);
    }

    [GlobalCleanup(Target = nameof(IsPalindrome))]
    public void IsPalindromeCleanup()
    {
        IntArray1 = Array.Empty<int>();
        IntArray2 = Array.Empty<int>();
        ListNode1 = new ListNode();
    }
}