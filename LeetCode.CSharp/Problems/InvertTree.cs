﻿namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Invert Binary Tree",
        Difficulty.Easy,
        Category.Trees,
        "https://www.youtube.com/watch?v=OnSn2XEQ4MY")]
    public static TreeNode? InvertTree(TreeNode? root)
    {
        if (root is null)
        {
            return null;
        }

        (root.left, root.right) = (root.right, root.left);

        if (root.left is not null)
        {
            InvertTree(root.left);
        }
        if (root.right is not null)
        {
            InvertTree(root.right);
        }

        return root;
    }

    [Fact]
    public void InvertTreeTest()
    {
        var root1 = new TreeNode(4,
            left: new TreeNode(2, left: new TreeNode(1), right: new TreeNode(3)),
            right: new TreeNode(7, left: new TreeNode(6), right: new TreeNode(9)));
        var exp1 = new TreeNode(4,
            left: new TreeNode(7, left: new TreeNode(9), right: new TreeNode(6)),
            right: new TreeNode(2, left: new TreeNode(3), right: new TreeNode(1)));
        var root2 = new TreeNode(2, left: new TreeNode(1), right: new TreeNode(3));
        var exp2 = new TreeNode(2, left: new TreeNode(3), right: new TreeNode(1));

        InvertTree(root1).ShouldBeEquivalentTo(exp1);
        InvertTree(root2).ShouldBeEquivalentTo(exp2);
        InvertTree(new TreeNode()).ShouldBeEquivalentTo(new TreeNode());
        InvertTree(null).ShouldBeNull();
    }
}
