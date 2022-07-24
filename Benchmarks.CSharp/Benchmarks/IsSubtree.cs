namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsSubtree()
    {
        var root1 = new TreeNode(new int?[] { 3, 4, 5, 1, 2 });
        var subRoot1 = new TreeNode(new int?[] { 4, 1, 2 });
        var root2 = new TreeNode(new int?[] { 3, 4, 5, 1, 2, null, null, null, null, 0 });
        var subRoot2 = new TreeNode(new int?[] { 4, 1, 2 });
        Submission.IsSubtree(root1, subRoot1);
        Submission.IsSubtree(root2, subRoot2);
    }
}
