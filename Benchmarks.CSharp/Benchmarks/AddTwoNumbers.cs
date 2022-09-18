namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(AddTwoNumbers))]
    public void AddTwoNumbersSetup()
    {
        _intArray1 = new int[50_000];
        _intArray2 = new int[10_000];
        Array.Fill(_intArray1, 9);
        Array.Fill(_intArray2, 9);
        _listNode1 = new ListNode(_intArray1);
        _listNode2 = new ListNode(_intArray2);
    }

    [Benchmark]
    public ListNode AddTwoNumbers()
    {
        return Problem.AddTwoNumbers(_listNode1, _listNode2);
    }
}