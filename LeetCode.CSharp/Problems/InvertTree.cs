namespace LeetCode;

public sealed partial class Problem
{
    [LeetCode("Invert Binary Tree", Difficulty.Easy, Category.Trees, "OnSn2XEQ4MY")]
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

    [Test]
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

        InvertTree(root1).Should().BeEquivalentTo(exp1);
        InvertTree(root2).Should().BeEquivalentTo(exp2);
        InvertTree(new TreeNode()).Should().BeEquivalentTo(new TreeNode());
        InvertTree(null).Should().BeNull();
    }
}
