// ReSharper disable once CheckNamespace
namespace LeetCode;

public class ListNode
{
    // ReSharper disable InconsistentNaming
    public readonly int val;
    public ListNode? next;
    // ReSharper enable InconsistentNaming

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}
