// ReSharper disable once CheckNamespace
namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode("Balanced Binary Tree", Difficulty.Easy, Category.Trees)]
    public static bool IsBalanced(TreeNode root)
    {
        (bool IsBalanced, int Height) DepthFirstSearch(TreeNode? node)
        {
            if (node == null)
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
        var root1 = new TreeNode(3,
            left: new TreeNode(9),
            right: new TreeNode(20,
                left: new TreeNode(15),
                right: new TreeNode(7)));
        var root2 = new TreeNode(1,
            left: new TreeNode(2,
                left: new TreeNode(3,
                    left: new TreeNode(4),
                    right: new TreeNode(4)),
                right: new TreeNode(3)),
            right: new TreeNode(2));
        var root3 = new TreeNode(1, left: new TreeNode(2, left: new TreeNode(3)));
        var root4 = new TreeNode();
        var root5 = new TreeNode(1,
            left: new TreeNode(2,
                left: new TreeNode(4,
                    left: new TreeNode(7),
                    right: null),
                right: new TreeNode(5)),
            right: new TreeNode(3,
                left: null,
                right: new TreeNode(6,
                    left: null,
                    right: new TreeNode(8))));

        IsBalanced(root1).Should().BeTrue();
        IsBalanced(root2).Should().BeFalse();
        IsBalanced(root3).Should().BeFalse();
        IsBalanced(root4).Should().BeTrue();
        IsBalanced(root5).Should().BeFalse();
    }
}
