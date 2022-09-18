namespace LeetCode;

using Benchmarks.CSharp;

[Config(typeof(RuntimeConfig))]
public partial class CSharpBenchmarks
{
    private int[] _intArray1 = Array.Empty<int>();
    private int[] _intArray2 = Array.Empty<int>();

    private ListNode _listNode1 = new();
    private ListNode _listNode2 = new();

    private TreeNode _treeNode1 = new();

    private string _string1 = string.Empty;
    private string _string2 = string.Empty;
}
