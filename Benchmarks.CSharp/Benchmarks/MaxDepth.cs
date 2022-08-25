namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void MaxDepth()
    {
        var root1 = new TreeNode(3,
            left: new TreeNode(9, left: new TreeNode(1), right: null),
            right: new TreeNode(20, left: new TreeNode(15), right: new TreeNode(7)));
        var root2 = new TreeNode(1, left: null, right: new TreeNode(2));

        Problem.MaxDepth(root1);
        Problem.MaxDepth(root2);
    }
}
