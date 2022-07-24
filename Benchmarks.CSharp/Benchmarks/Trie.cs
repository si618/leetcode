namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void Trie()
    {
        var trie = new Submission.Trie();

        trie.Insert("apple");
        trie.Search("apple");
        trie.Search("app");
        trie.StartsWith("app");

        trie.Insert("app");
        trie.Search("app");
    }
}
