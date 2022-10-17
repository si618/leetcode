namespace LeetCode.CSharp.Benchmarks;

public class DiameterOfBinaryTreeBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(DiameterOfBinaryTree))]
    public void DiameterOfBinaryTreeSetup()
    {
        IntArrayNullable = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(IntArrayNullable)!;
    }

    [Benchmark]
    public int DiameterOfBinaryTree() => Problem.DiameterOfBinaryTree(TreeNode1);

    [GlobalCleanup(Target = nameof(DiameterOfBinaryTree))]
    public void DiameterOfBinaryTreeCleanup()
    {
        IntArrayNullable = Array.Empty<int?>();
        TreeNode1 = new TreeNode();
    }
}
