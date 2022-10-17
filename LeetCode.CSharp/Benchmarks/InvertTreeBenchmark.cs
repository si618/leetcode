namespace LeetCode.CSharp.Benchmarks;

public class InvertTreeBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(InvertTree))]
    public void InvertTreeSetup()
    {
        IntArrayNullable = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(IntArrayNullable)!;
    }

    [Benchmark]
    public TreeNode? InvertTree()
    {
        return Problem.InvertTree(TreeNode1);
    }

    [GlobalCleanup(Target = nameof(InvertTree))]
    public void InvertTreeCleanup()
    {
        IntArrayNullable = Array.Empty<int?>();
        TreeNode1 = new TreeNode();
    }
}
