namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(LowestCommonAncestor))]
    public void LowestCommonAncestorSetup()
    {
        IntArrayNullable = Enumerable.Range(1, 10_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(IntArrayNullable)!;
        TreeNode2 = TreeNode1.left!;
        while (TreeNode2.left is not null)
        {
            TreeNode2 = TreeNode2.left;
        }
    }

    [Benchmark]
    public TreeNode LowestCommonAncestor()
    {
        return Problem.LowestCommonAncestor(TreeNode1, TreeNode1, TreeNode2);
    }

    [GlobalCleanup(Target = nameof(LowestCommonAncestor))]
    public void LowestCommonAncestorCleanup()
    {
        IntArrayNullable = Array.Empty<int?>();
        TreeNode1 = new TreeNode();
        TreeNode2 = new TreeNode();
    }
}
