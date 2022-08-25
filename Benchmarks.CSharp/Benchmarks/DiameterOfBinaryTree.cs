﻿namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void DiameterOfBinaryTree()
    {
        var root1 = new TreeNode(1,
            left: new TreeNode(2,
                left: new TreeNode(4), right: new TreeNode(5)),
            right: new TreeNode(3));
        var root2 = new TreeNode(1, left: new TreeNode(2));
        Problem.DiameterOfBinaryTree(root1);
        Problem.DiameterOfBinaryTree(root2);
    }
}
