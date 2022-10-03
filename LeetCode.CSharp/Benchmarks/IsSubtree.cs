namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [GlobalSetup(Target = nameof(IsSubtree))]
    public void IsSubtreeSetup()
    {
        IntArrayNullable = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(IntArrayNullable)!;
        TreeNode2 = TreeNode.Deserialize(IntArrayNullable)!;
    }

    [Benchmark]
    public bool IsSubtree()
    {
        return Problem.IsSubtree(TreeNode1, TreeNode2);
    }

    [GlobalCleanup(Target = nameof(IsSubtree))]
    public void IsSubtreeCleanup()
    {
        IntArrayNullable = Array.Empty<int?>();
        TreeNode1 = new TreeNode();
        TreeNode2 = new TreeNode();
    }
}
