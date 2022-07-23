// ReSharper disable once CheckNamespace
namespace LeetCode;

using System.Runtime.Serialization;

public class TreeNode
{
    // ReSharper disable InconsistentNaming
    public readonly int val;
    public TreeNode? left;
    public TreeNode? right;
    // ReSharper enable InconsistentNaming

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public TreeNode(IReadOnlyList<int?> values)
    {
        var root = Deserialize(values);

        if (root is null)
        {
            return;
        }

        val = root.val;
        left = root.left;
        right = root.right;
    }

    private static TreeNode? Deserialize(IReadOnlyList<int?> values)
    {
        var count = values.Count;
        var nodes = new TreeNode?[count];
        var stack = new Stack<TreeNode?>();
        var n = 0;

        for (var i = count - 1; i >= 0; i--)
        {
            var node = values[i].HasValue ? new TreeNode(values[i]!.Value) : null;
            nodes[count - 1 - n++] = node;
            stack.Push(node);
        }

        var root = stack.Pop();

        foreach (var node in nodes)
        {
            if (node is null)
            {
                continue;
            }
            if (stack.TryPop(out var leftNode))
            {
                node.left = leftNode;
            }
            if (stack.TryPop(out var rightNode))
            {
                node.right = rightNode;
            }
        }

        return root;
    }
}
