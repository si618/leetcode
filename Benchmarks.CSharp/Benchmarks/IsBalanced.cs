// ReSharper disable once CheckNamespace
namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsBalanced()
    {
        var root1 = new TreeNode(3,
            left: new TreeNode(9),
            right: new TreeNode(20,
                left: new TreeNode(15),
                right: new TreeNode(7)));
        var root2 = new TreeNode(1,
            left: new TreeNode(2,
                left: new TreeNode(3,
                    left: new TreeNode(4),
                    right: new TreeNode(4)),
                right: new TreeNode(3)),
            right: new TreeNode(2));
        Submission.IsBalanced(root1);
        Submission.IsBalanced(root2);
    }
}
