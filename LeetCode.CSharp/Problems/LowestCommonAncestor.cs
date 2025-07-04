﻿namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Lowest Common Ancestor of a Binary Search Tree",
        Difficulty.Easy,
        Category.Trees,
        "https://www.youtube.com/watch?v=gs2LMfuOR9k")]
    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var current = root;

        while (true)
        {
            ArgumentNullException.ThrowIfNull(current);

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

    [Fact]
    public void LowestCommonAncestorTest()
    {
        var root1 = new TreeNode([6, 2, 8, 0, 4, 7, 9, null, null, 3, 5]);
        var p1 = root1.left!;
        var q1 = root1.right!;
        var q2 = p1.right!;
        var root3 = new TreeNode([2, 1]);
        var q3 = root3.left!;

        LowestCommonAncestor(root1, p1, q1).ShouldBe(root1);
        LowestCommonAncestor(root1, p1, q2).ShouldBe(p1);
        LowestCommonAncestor(root3, root3, q3).ShouldBe(root3);
    }
}
