namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void ReverseList()
    {
        var ex1 = new ListNode(new[] { 1, 2, 3, 4, 5 });
        var ex2 = new ListNode(1, new ListNode(2));

        Problem.ReverseList(ex1);
        Problem.ReverseList(ex2);
    }
}
