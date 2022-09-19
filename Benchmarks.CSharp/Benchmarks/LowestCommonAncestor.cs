namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(LowestCommonAncestor))]
    public void LowestCommonAncestorSetup()
    {
        var values = Enumerable.Range(1, 10_000_000).Cast<int?>().ToArray();
        _treeNode1 = TreeNode.Deserialize(values)!;
        _treeNode2 = _treeNode1.left!;
        while (_treeNode2.left is not null)
        {
            _treeNode2 = _treeNode2.left;
        }
    }

    [Benchmark]
    public TreeNode LowestCommonAncestor()
    {
        return Problem.LowestCommonAncestor(_treeNode1, _treeNode1, _treeNode2);
    }
}
