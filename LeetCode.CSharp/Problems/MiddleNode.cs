namespace LeetCode.CSharp.Problems;

using System.Collections.Generic;
using System.Linq;

public sealed partial class Problem
{
    [LeetCode("Middle of the Linked List", Difficulty.Easy, Category.NotInNeetCode)]
    public static ListNode MiddleNode(ListNode head)
    {
        var list = new List<ListNode> { head };
        while (head.next is not null)
        {
            head = head.next;
            list.Add(head);
        }
        var skip = list.Count / 2;
        return list.Skip(skip).First();
    }

    [Fact]
    public void MiddleNodeTest()
    {
        var single = new ListNode(1);
        var even = new ListNode([1, 2, 3, 4]);
        var odd = new ListNode([1, 2, 3, 4, 5]);

        MiddleNode(single).ShouldBeSameAs(single);
        MiddleNode(even).ShouldBeSameAs(even.next!.next);
        MiddleNode(odd).ShouldBeSameAs(odd.next!.next);
    }
}
