namespace LeetCode;

using Benchmarks.CSharp;

[Config(typeof(RuntimeConfig))]
public partial class CSharpBenchmarks
{
    private int[] IntArray1 { get; set; } = Array.Empty<int>();
    private int[] IntArray2 { get; set; } =  Array.Empty<int>();
    private int[][] IntArray3 { get; set; } =  Array.Empty<int[]>();

    private ListNode ListNode1 { get; set; } =  new();
    private ListNode ListNode2 { get; set; } =  new();

    private string String1 { get; set; } =  string.Empty;
    private string String2 { get; set; } =  string.Empty;

    private TreeNode TreeNode1 { get; set; } =  new();
    private TreeNode TreeNode2 { get; set; } =  new();
}
