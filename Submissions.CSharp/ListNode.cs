// ReSharper disable once CheckNamespace
namespace LeetCode;

public class ListNode
{
    // ReSharper disable once InconsistentNaming
    public readonly int val;
    // ReSharper disable once InconsistentNaming
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}
