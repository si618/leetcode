namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Challenge
{
    [LeetCode("Maximum Depth of Binary Tree", Difficulty.Easy, Category.Trees)]
    public static int MaxDepth(TreeNode? root)
    {
        if (root is null)
        {
            return 0;
        }

        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }

    [Test]
    public void MaxDepthTest()
    {
        var root1 = new TreeNode(3,
            left: new TreeNode(9, left: new TreeNode(1), right: null),
            right: new TreeNode(20, left: new TreeNode(15), right: new TreeNode(7)));
        var root2 = new TreeNode(1, left: null, right: new TreeNode(2));

        MaxDepth(null).Should().Be(0);
        MaxDepth(root1).Should().Be(3);
        MaxDepth(root2).Should().Be(2);
    }
}
