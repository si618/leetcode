namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(LowestCommonAncestor))]
    public void LowestCommonAncestorSetup()
    {
        var values = Enumerable.Range(1, 10_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(values)!;
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
}
