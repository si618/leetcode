namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(IsSubtree))]
    public void IsSubtreeSetup()
    {
        var values = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(values)!;
        TreeNode2 = TreeNode.Deserialize(values)!;
    }

    [Benchmark]
    public bool IsSubtree()
    {
        return Problem.IsSubtree(TreeNode1, TreeNode2);
    }
}
