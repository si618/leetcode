namespace LeetCode.CSharp.Benchmarks;

public class MaxDepthBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(MaxDepth))]
    public void MaxDepthSetup()
    {
        IntArrayNullable = [.. Enumerable.Range(1, 10_000_000).Cast<int?>()];
        TreeNode1 = TreeNode.Deserialize(IntArrayNullable)!;
    }

    [Benchmark]
    public int MaxDepth() => Problem.MaxDepth(TreeNode1);

    [GlobalCleanup(Target = nameof(MaxDepth))]
    public void MaxDepthCleanup()
    {
        IntArrayNullable = [];
        TreeNode1 = new TreeNode();
    }
}
