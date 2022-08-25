namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsBalanced()
    {
        var root1 = new TreeNode(new int?[] { 3, 9, 20, null, null, 15, 7 });
        var root2 = new TreeNode(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 });
        Problem.IsBalanced(root1);
        Problem.IsBalanced(root2);
    }
}
