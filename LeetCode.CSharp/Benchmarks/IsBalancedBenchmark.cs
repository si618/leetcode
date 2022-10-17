namespace LeetCode.CSharp.Benchmarks;

public class IsBalancedBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(IsBalanced))]
    public void IsBalancedSetup()
    {
        IntArrayNullable = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        TreeNode1 = TreeNode.Deserialize(IntArrayNullable)!;
    }

    [Benchmark]
    public bool IsBalanced()
    {
        return Problem.IsBalanced(TreeNode1);
    }

    [GlobalCleanup(Target = nameof(IsBalanced))]
    public void IsBalancedCleanup()
    {
        IntArrayNullable = Array.Empty<int?>();
        TreeNode1 = new TreeNode();
    }
}
