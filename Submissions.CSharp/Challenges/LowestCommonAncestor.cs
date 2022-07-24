// ReSharper disable once CheckNamespace
namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode(
        "Lowest Common Ancestor of a Binary Search Tree",
        Difficulty.Easy,
        Category.Trees)]
    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var current = root;

        while (true)
        {
            if (current is null)
            {
                throw new ArgumentException("Nodes cannot be null in Binary Search Tree");
            }

            if (p.val < current.val && q.val < current.val)
            {
                // Both p and q are lower so search left subtree
                current = current.left;
            }
            else if (p.val > current.val && q.val > current.val)
            {
                // Both p and q are higher so search right subtree
                current = current.right;
            }
            else
            {
                // Node either sits between p and q or equals p or q so we're at the LCA
                return current;
            }
        }
    }

    [Test]
    public void LowestCommonAncestorTest()
    {
        var root1 = new TreeNode(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
        var p1 = root1.left!;
        var q1 = root1.right!;
        var q2 = p1.right!;
        var root3 = new TreeNode(new int?[] { 2, 1 });
        var q3 = root3.left!;

        LowestCommonAncestor(root1, p1, q1).Should().Be(root1);
        LowestCommonAncestor(root1, p1, q2).Should().Be(p1);
        LowestCommonAncestor(root3, root3, q3).Should().Be(root3);
    }
}
