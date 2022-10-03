namespace LeetCode.CSharp;

public partial class Benchmarks
{
    private readonly Problem.Trie _trie = new();

    [GlobalSetup(Target = nameof(Trie))]
    public void TrieSetup()
    {
        String1 = BuildPseudoRandomString(1_000_000, 2);
        String2 = BuildPseudoRandomString(10);
    }

    [Benchmark]
    public bool Trie()
    {
        _trie.Insert(String1);
        return _trie.Search(String2);
    }

    [GlobalCleanup(Target = nameof(Trie))]
    public void TrieCleanup()
    {
        String1 = string.Empty;
        String2 = string.Empty;
    }
}
