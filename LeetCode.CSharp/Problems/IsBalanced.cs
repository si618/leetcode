﻿namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Balanced Binary Tree",
        Difficulty.Easy,
        Category.Trees,
        "https://www.youtube.com/watch?v=QfJsau0ItOY")]
    public static bool IsBalanced(TreeNode root)
    {
        return DepthFirstSearch(root).IsBalanced;

        static (bool IsBalanced, int Height) DepthFirstSearch(TreeNode? node)
        {
            if (node is null)
            {
                return (true, 0);
            }

            var left = DepthFirstSearch(node.left);
            var right = DepthFirstSearch(node.right);

            var isBalanced = left.IsBalanced && right.IsBalanced
                                             && Math.Abs(left.Height - right.Height) <= 1;

            // Add 1 to include current node's height
            var height = Math.Max(left.Height, right.Height) + 1;

            return (isBalanced, height);
        }
    }

    [Fact]
    public void IsBalancedTest()
    {
        var root1 = new TreeNode([3, 9, 20, null, null, 15, 7]);
        var root2 = new TreeNode([1, 2, 2, 3, 3, null, null, 4, 4]);
        var root3 = new TreeNode([1, 2, null, 3]);
        var root4 = new TreeNode([1, 2, 3, 4, 5, null, 6, 7, null, null, null, null, 8]);
        var root5 = new TreeNode();

        IsBalanced(root1).ShouldBeTrue();
        IsBalanced(root2).ShouldBeFalse();
        IsBalanced(root3).ShouldBeFalse();
        IsBalanced(root4).ShouldBeFalse();
        IsBalanced(root5).ShouldBeTrue();
    }
}
