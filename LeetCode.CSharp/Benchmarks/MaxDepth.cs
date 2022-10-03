namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [GlobalSetup(Target = nameof(MaxDepth))]
    public void MaxDepthSetup()
    {
        IntArrayNullable = Enumerable.Range(1, 10_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(IntArrayNullable)!;
    }

    [Benchmark]
    public int MaxDepth()
    {
        return Problem.MaxDepth(TreeNode1);
    }

    [GlobalCleanup(Target = nameof(MaxDepth))]
    public void MaxDepthCleanup()
    {
        IntArrayNullable = Array.Empty<int?>();
        TreeNode1 = new TreeNode();
    }
}
