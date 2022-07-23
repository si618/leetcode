// ReSharper disable once CheckNamespace
namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsBalanced()
    {
        var root1 = new TreeNode(new int?[] { 3, 9, 20, null, null, 15, 7 });
        var root2 = new TreeNode(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 });
        Submission.IsBalanced(root1);
        Submission.IsBalanced(root2);
    }
}
