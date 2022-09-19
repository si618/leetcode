namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(IsSameTree))]
    public void IsSameTreeSetup()
    {
        var values = Enumerable.Range(1, 1_000_000).Cast<int?>().ToArray();
        _treeNode1 = TreeNode.Deserialize(values)!;
        _treeNode2 = TreeNode.Deserialize(values)!;
    }

    [Benchmark]
    public bool IsSameTree()
    {
        return Problem.IsSameTree(_treeNode1, _treeNode2);
    }
}
