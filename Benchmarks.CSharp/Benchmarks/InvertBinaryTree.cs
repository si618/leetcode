namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void InvertTree()
    {
        var root1 = new TreeNode(4,
            left: new TreeNode(2, left: new TreeNode(1), right: new TreeNode(3)),
            right: new TreeNode(7, left: new TreeNode(6), right: new TreeNode(9)));
        var root2 = new TreeNode(2, left: new TreeNode(1), right: new TreeNode(3));

        Submission.InvertTree(root1);
        Submission.InvertTree(root2);
        Submission.InvertTree(new TreeNode());
    }
}
