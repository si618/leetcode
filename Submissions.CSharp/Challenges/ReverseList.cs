// ReSharper disable once CheckNamespace
namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode("Reverse Linked List", Difficulty.Easy, Category.LinkedList)]
    public static ListNode? ReverseList(ListNode? head)
    {
        ListNode? previous = null;
        var current = head;

        while (current is not null)
        {
            var next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        return previous;
    }

    [Test]
    public void ReverseListTest()
    {
        var ex1 = new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(4,
            new ListNode(5)))));
        var ep1 = new ListNode(5,
            new ListNode(4,
            new ListNode(3,
            new ListNode(2,
            new ListNode(1)))));
        var ex2 = new ListNode(1, new ListNode(2));
        var ep2 = new ListNode(2, new ListNode(1));
        ListNode? ex3 = null;

        ReverseList(ex1).Should().BeEquivalentTo(ep1);
        ReverseList(ex2).Should().BeEquivalentTo(ep2);
        ReverseList(ex3).Should().BeNull();
    }
}
