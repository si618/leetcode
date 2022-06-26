// ReSharper disable once CheckNamespace
namespace LeetCode;

public class TreeNode
{
    public readonly int Val;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}
