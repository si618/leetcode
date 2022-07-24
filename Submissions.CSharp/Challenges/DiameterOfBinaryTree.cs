namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode("Diameter of Binary Tree", Difficulty.Easy, Category.Trees)]
    public static int DiameterOfBinaryTree(TreeNode root)
    {
        var maxDiameter = 0;

        // Calculates height and stores maximum diameter
        int DepthFirstSearch(TreeNode? node)
        {
            if (node is null)
            {
                return 0;
            }

            var left = DepthFirstSearch(node.left);
            var right = DepthFirstSearch(node.right);

            maxDiameter = Math.Max(left + right, maxDiameter);

            // Add 1 to include current node's height
            return Math.Max(left, right) + 1;
        }

        DepthFirstSearch(root);

        return maxDiameter;
    }

    [Test]
    public void DiameterOfBinaryTreeTest()
    {
        var root1 = new TreeNode(1,
            left: new TreeNode(2,
                left: new TreeNode(4), right: new TreeNode(5)),
            right: new TreeNode(3));
        var root2 = new TreeNode(1, left: new TreeNode(2));

        DiameterOfBinaryTree(new TreeNode()).Should().Be(0);
        DiameterOfBinaryTree(root1).Should().Be(3);
        DiameterOfBinaryTree(root2).Should().Be(1);
    }
}
