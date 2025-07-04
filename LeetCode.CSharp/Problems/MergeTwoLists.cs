namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Merge Two Sorted Lists",
        Difficulty.Easy,
        Category.LinkedList,
        "https://www.youtube.com/watch?v=XIdigk956u0")]
    public static ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        var dummy = new ListNode();
        var tail = dummy;

        while (list1 is not null && list2 is not null)
        {
            if (list1.val < list2.val)
            {
                tail.next = list1;
                list1 = list1.next;
            }
            else
            {
                tail.next = list2;
                list2 = list2.next;
            }
            tail = tail.next;
        }

        if (list1 is not null)
        {
            tail.next = list1;
        }
        else if (list2 is not null)
        {
            tail.next = list2;
        }

        return dummy.next;
    }

    [Fact]
    public void MergeTwoListsTest()
    {
        var ex11 = new ListNode([1, 2, 4]);
        var ex12 = new ListNode([1, 3, 4]);
        var ep1 = new ListNode([1, 1, 2, 3, 4, 4]);
        var ex3 = new ListNode();

        MergeTwoLists(ex11, ex12).ShouldBeEquivalentTo(ep1);
        MergeTwoLists(null, null).ShouldBeNull();
        MergeTwoLists(null, ex3).ShouldBeEquivalentTo(ex3);
    }
}
