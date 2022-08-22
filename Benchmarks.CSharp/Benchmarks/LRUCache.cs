namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    // ReSharper disable once InconsistentNaming - LeetCode requirement
    public void LRUCache()
    {
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