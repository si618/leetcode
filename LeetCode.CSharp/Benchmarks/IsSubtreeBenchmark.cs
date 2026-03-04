namespace LeetCode.CSharp.Benchmarks;

public class IsSubtreeBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(IsSubtree))]
    public void IsSubtreeSetup()
    {
        IntArrayNullable = [.. Enumerable.Range(1, 1_000_000).Cast<int?>()];
        TreeNode1 = TreeNode.Deserialize(IntArrayNullable)!;
        TreeNode2 = TreeNode.Deserialize(IntArrayNullable)!;
    }

    [Benchmark]
    public bool IsSubtree() => Problem.IsSubtree(TreeNode1, TreeNode2);

    [GlobalCleanup(Target = nameof(IsSubtree))]
    public void IsSubtreeCleanup()
    {
        IntArrayNullable = [];
        TreeNode1 = new TreeNode();
        TreeNode2 = new TreeNode();
    }
}
