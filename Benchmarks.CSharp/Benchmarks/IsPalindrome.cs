namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(IsPalindrome))]
    public void IsPalindromeSetup()
    {
        _intArray1 = Enumerable.Range(1, 10_000).ToArray();
        _intArray2 = _intArray1.Reverse().ToArray();
        _listNode1 = new ListNode(_intArray1.Concat(_intArray2).ToArray());
    }

    [Benchmark]
    public bool IsPalindrome()
    {
        return Problem.IsPalindrome(_listNode1);
    }
}