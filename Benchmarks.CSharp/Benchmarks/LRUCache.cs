namespace LeetCode;

public partial class CSharpBenchmarks
{
    private Problem.LRUCache _lruCache = null!;

    [GlobalSetup(Target = nameof(LRUCache))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public void LRUCacheSetup()
    {
        _lruCache = new Problem.LRUCache(1_000_000);
        for (var i = 0; i < 1_000_000; i++)
        {
            _lruCache.Put(i, i);
        }
    }

    [Benchmark]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public int LRUCache()
    {
        return _lruCache.Get(500_000);
    }
}