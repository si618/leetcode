namespace LeetCode.CSharp.Benchmarks;

public partial class Benchmark
{
    [GlobalSetup(Target = nameof(IsSameTree))]
    public void IsSameTreeSetup()
    {
        IntArrayNullable = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(IntArrayNullable)!;
        TreeNode2 = TreeNode.Deserialize(IntArrayNullable)!;
    }

    [Benchmark]
    public bool IsSameTree()
    {
        return Problem.IsSameTree(TreeNode1, TreeNode2);
    }

    [GlobalCleanup(Target = nameof(IsSameTree))]
    public void IsSameTreeCleanup()
    {
        IntArrayNullable = Array.Empty<int?>();
        TreeNode1 = new TreeNode();
        TreeNode2 = new TreeNode();
    }
}
