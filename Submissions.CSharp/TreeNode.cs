// ReSharper disable once CheckNamespace
namespace LeetCode;

public class TreeNode
{
    // ReSharper disable once InconsistentNaming
    public readonly int val;
    // ReSharper disable once InconsistentNaming
    public TreeNode? left;
    // ReSharper disable once InconsistentNaming
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
