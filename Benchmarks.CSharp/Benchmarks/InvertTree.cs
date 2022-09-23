namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(InvertTree))]
    public void InvertTreeSetup()
    {
        var values = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(values)!;
    }

    [Benchmark]
    public TreeNode? InvertTree()
    {
        return Problem.InvertTree(TreeNode1);
    }
}
