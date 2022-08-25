namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void LowestCommonAncestor()
    {
        var root1 = new TreeNode(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
        var p1 = root1.left!;
        var q1 = root1.right!;
        var q2 = p1.right!;
        var root3 = new TreeNode(new int?[] { 2, 1 });
        var q3 = root3.left!;
        Problem.LowestCommonAncestor(root1, p1, q1);
        Problem.LowestCommonAncestor(root1, p1, q2);
        Problem.LowestCommonAncestor(root3, root3, q3);
    }
}
