namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public void LRUCache()
    {
        // Inputs from LeetCode
        var lru = new Problem.LRUCache(2);
        lru.Put(1, 1);
        lru.Put(2, 2);
        lru.Get(1);
        lru.Put(3, 3);
        lru.Get(2);
        lru.Put(4, 4);
        lru.Get(1);
        lru.Get(3);
        lru.Get(4);
    }
}