namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
        "Reverse Linked List",
        Difficulty.Easy,
        Category.LinkedList,
        "https://www.youtube.com/watch?v=G0_I-ZF0S38")]
    public static ListNode? ReverseList(ListNode? head)
    {
        ListNode? previous = null;
        var current = head;

        while (current is not null)
        {
            var next = current.next;
            current.next = previous;
            previous = current;
            current = next;
        }

        return previous;
    }

    [Fact]
    public void ReverseListTest()
    {
        var ex1 = new ListNode(new[] { 1, 2, 3, 4, 5 });
        var ep1 = new ListNode(new[] { 5, 4, 3, 2, 1 });
        var ex2 = new ListNode(1, new ListNode(2));
        var ep2 = new ListNode(2, new ListNode(1));
        ListNode? ex3 = null;

        ReverseList(ex1).Should().BeEquivalentTo(ep1);
        ReverseList(ex2).Should().BeEquivalentTo(ep2);
        ReverseList(ex3).Should().BeNull();
    }
}
