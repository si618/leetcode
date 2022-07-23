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

    public ListNode(IReadOnlyList<int> list)
    {
        var lastNode = Deserialize(list);

        if (lastNode is null)
        {
            return;
        }

        val = lastNode.val;
        next = lastNode.next;
    }
    private static ListNode? Deserialize(IReadOnlyList<int> list)
    {
        ListNode? lastNode = null;

        for (var i = list.Count - 1; i >= 0; i--)
        {
            var node = new ListNode(list[i])
            {
                next = lastNode
            };
            lastNode = node;
        }

        return lastNode;
    }
}
