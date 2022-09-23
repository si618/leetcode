namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(DiameterOfBinaryTree))]
    public void DiameterOfBinaryTreeSetup()
    {
        var values = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(values)!;
    }

    [Benchmark]
    public int DiameterOfBinaryTree()
    {
        return Problem.DiameterOfBinaryTree(TreeNode1);
    }
}
