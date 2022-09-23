namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(IsSameTree))]
    public void IsSameTreeSetup()
    {
        var values = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(values)!;
        TreeNode2 = TreeNode.Deserialize(values)!;
    }

    [Benchmark]
    public bool IsSameTree()
    {
        return Problem.IsSameTree(TreeNode1, TreeNode2);
    }
}
