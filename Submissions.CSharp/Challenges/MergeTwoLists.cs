// ReSharper disable once CheckNamespace
namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode("Merge Two Sorted Lists", Difficulty.Easy, Category.LinkedList)]
    public static ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        var dummy = new ListNode();
        var tail = dummy;

        while (list1 is not null && list2 is not null)
        {
            if (list1.Val < list2.Val)
            {
                tail.Next = list1;
                list1 = list1.Next;
            }
            else
            {
                tail.Next = list2;
                list2 = list2.Next;
            }
            tail = tail.Next;
        }

        if (list1 is not null)
        {
            tail.Next = list1;
        }
        else if (list2 is not null)
        {
            tail.Next = list2;
        }

        return dummy.Next;
    }

    [Test]
    public void MergeTwoListsTest()
    {
        var ex11 = new ListNode(1,
            new ListNode(2,
            new ListNode(4)));
        var ex12 = new ListNode(1,
            new ListNode(3,
            new ListNode(4)));
        var ep1 = new ListNode(1,
            new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(4,
            new ListNode(4))))));
        var ex3 = new ListNode(0);

        MergeTwoLists(ex11, ex12).Should().BeEquivalentTo(ep1);
        MergeTwoLists(null, null).Should().BeNull();
        MergeTwoLists(null, ex3).Should().BeEquivalentTo(ex3);
    }
}
