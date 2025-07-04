﻿namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Same Tree",
        Difficulty.Easy,
        Category.Trees,
        "https://www.youtube.com/watch?v=vRbbcKXCxOw")]
    public static bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        // Null tree nodes are equal
        if (p is null && q is null)
        {
            return true;
        }

        // One must now be non-null
        if (p is null || q is null)
        {
            return false;
        }

        // Both must now be non-null
        if (p.val != q.val)
        {
            return false;
        }

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }

    [Fact]
    public void IsSameTreeTest()
    {
        var p1 = new TreeNode(new int?[] { 1, 2, 3 });
        var q1 = new TreeNode(new int?[] { 1, 2, 3 });
        var p2 = new TreeNode(new int?[] { 1, 2 });
        var q2 = new TreeNode(new int?[] { 1, null, 2 });
        var p3 = new TreeNode(new int?[] { 1, 2, 1 });
        var q3 = new TreeNode(new int?[] { 1, 1, 2 });

        IsSameTree(p1, q1).ShouldBeTrue();
        IsSameTree(p2, q2).ShouldBeFalse();
        IsSameTree(p3, q3).ShouldBeFalse();
        IsSameTree(null, null).ShouldBeTrue();
    }
}
