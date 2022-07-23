// ReSharper disable once CheckNamespace
namespace LeetCode;

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
}
