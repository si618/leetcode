namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(IsBalanced))]
    public void IsBalancedSetup()
    {
        var values = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(values)!;
    }

    [Benchmark]
    public bool IsBalanced()
    {
        return Problem.IsBalanced(TreeNode1);
    }
}
