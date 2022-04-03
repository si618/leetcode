namespace Leetcode.Submissions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class MiddleNodeTest
{
    public static ListNode MiddleNode(ListNode head)
    {
        var list = new List<ListNode> { head };
        while (head.Next is not null)
        {
            head = head.Next;
            list.Add(head);
        };
        var skip = list.Count / 2;
        return list.Skip(skip).First();
    }

    [Test]
    public void Test()
    {
        // Arrange
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
        // Act & Assert
        Assert.AreEqual(single, MiddleNode(single));
        Assert.AreEqual(even.Next!.Next, MiddleNode(even));
        Assert.AreEqual(odd.Next!.Next, MiddleNode(odd));
    }

}
