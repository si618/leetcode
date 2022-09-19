namespace LeetCode;

public sealed partial class Problem
{
    [LeetCode(
        "Subtree of Another Tree",
        Difficulty.Easy,
        Category.Trees,
        "https://www.youtube.com/watch?v=E36O5SWp-LE")]
    public static bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        // A null root or null root edge means a null subRoot is a subtree
        if (subRoot is null)
        {
            return true;
        }

        // SubRoot is non-null therefore a null root means it's not a subtree
        if (root is null)
        {
            return false;
        }

        // Use code from previous challenge
        if (IsSameTree(root, subRoot))
        {
            return true;
        }

        // Recursively check if either left or right node is a subtree
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    [Test]
    public void IsSubtreeTest()
    {
        var root1 = new TreeNode(new int?[] { 3, 4, 5, 1, 2 });
        var subRoot1 = new TreeNode(new int?[] { 4, 1, 2 });
        var root2 = new TreeNode(new int?[] { 3, 4, 5, 1, 2, null, null, null, null, 0 });
        var subRoot2 = new TreeNode(new int?[] { 4, 1, 2 });

        IsSubtree(root1, subRoot1).Should().BeTrue();
        IsSubtree(root2, subRoot2).Should().BeFalse();
        IsSubtree(null, null).Should().BeTrue();
    }
}
