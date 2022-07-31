namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Challenge
{
    [LeetCode("Balanced Binary Tree", Difficulty.Easy, Category.Trees)]
    public static bool IsBalanced(TreeNode root)
    {
        (bool IsBalanced, int Height) DepthFirstSearch(TreeNode? node)
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

        return DepthFirstSearch(root).IsBalanced;
    }

    [Test]
    public void IsBalancedTest()
    {
        var root1 = new TreeNode(new int?[] { 3, 9, 20, null, null, 15, 7 });
        var root2 = new TreeNode(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 });
        var root3 = new TreeNode(new int?[] { 1, 2, null, 3 });
        var root4 = new TreeNode(new int?[] { 1, 2, 3, 4, 5, null, 6, 7, null, null, null, null, 8 });
        var root5 = new TreeNode();

        IsBalanced(root1).Should().BeTrue();
        IsBalanced(root2).Should().BeFalse();
        IsBalanced(root3).Should().BeFalse();
        IsBalanced(root4).Should().BeFalse();
        IsBalanced(root5).Should().BeTrue();
    }
}
