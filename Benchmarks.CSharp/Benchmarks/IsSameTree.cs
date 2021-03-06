namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsSameTree()
    {
        var p1 = new TreeNode(new int?[] { 1, 2, 3 });
        var q1 = new TreeNode(new int?[] { 1, 2, 3 });
        var p2 = new TreeNode(new int?[] { 1, 2 });
        var q2 = new TreeNode(new int?[] { 1, null, 2 });
        var p3 = new TreeNode(new int?[] { 1, 2, 1 });
        var q3 = new TreeNode(new int?[] { 1, 1, 2 });
        Challenge.IsSameTree(p1, q1);
        Challenge.IsSameTree(p2, q2);
        Challenge.IsSameTree(p3, q3);
    }
}
