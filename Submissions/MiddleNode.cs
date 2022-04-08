namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public sealed partial class Submission
{
    public static ListNode MiddleNode(ListNode head)
    {
        var list = new List<ListNode> { head };
        while (head.next is not null)
        {
            head = head.next;
            list.Add(head);
        };
        var skip = list.Count / 2;
        return list.Skip(skip).First();
    }

    [Test]
    public void MiddleNodeTest()
    {
        var single = new ListNode(1, null);
        var even = new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(4, null))));
        var odd = new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(4,
            new ListNode(5, null)))));

        MiddleNode(single).Should().BeSameAs(single);
        MiddleNode(even).Should().BeSameAs(even.next!.next);
        MiddleNode(odd).Should().BeSameAs(odd.next!.next);
    }

}
