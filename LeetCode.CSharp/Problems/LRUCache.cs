namespace LeetCode;

using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

public sealed partial class Problem
{
    [LeetCode("LRU Cache", Difficulty.Medium, Category.LinkedList)]
    // ReSharper disable once InconsistentNaming - LeetCode requirement
    public class LRUCache
    {
        private class Node
        {
            public readonly int Key;
            public readonly int Value;
            public Node? Previous;
            public Node? Next;

            public Node(int key = 0, int value = 0)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly int _capacity;
        // Value is node rather than int to allow update to double linked list
        private readonly Dictionary<int, Node> _cache = new();
        // Left pointer is least recently used
        private readonly Node _left = new();
        // Right pointer is most recently used
        private readonly Node _right = new();

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            // Initialise double linked list
            _left.Next = _right;
            _right.Previous = _left;
        }

        private static void Remove(Node middleNode)
        {
            var previous = middleNode.Previous;
            var next = middleNode.Next;

            if (previous is not null)
            {
                previous.Next = next;
            }
            if (next is not null)
            {
                next.Previous = previous;
            }
        }

        private void Insert(Node node)
        {
            var previous = _right.Previous;

            if (previous is not null)
            {
                previous.Next = node;
            }

            _right.Previous = node;

            // Mark as most recently used
            node.Next = _right;
            node.Previous = previous;
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var node))
            {
                return -1;
            }

            // Remove as node can't exist twice in cache
            Remove(node);

            // Update most recently used pointer
            Insert(node);

            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (_cache.TryGetValue(key, out var existing))
            {
                // Remove existing node as it's now most recently used
                Remove(existing);
            }

            var node = new Node(key, value);

            if (!_cache.TryAdd(key, node))
            {
                // Need to update existing item as its value or pointers may have changed
                _cache[key] = node;
            }

            Insert(node);

            if (_cache.Count <= _capacity || _left.Next is null)
            {
                return;
            }

            // Capacity exceeded so remove from list and evict from cache
            var lru = _left.Next;
            Remove(lru);
            _cache.Remove(lru.Key);
        }
    }

    [Test]
    // ReSharper disable once InconsistentNaming - LeetCode requirement
    public void LRUCacheTest()
    {
        var lru = new LRUCache(2);
        lru.Put(1, 1);
        lru.Put(2, 2);
        var firstGet = lru.Get(1);
        lru.Put(3, 3);
        var secondGet = lru.Get(2);
        lru.Put(4, 4);
        var thirdGet = lru.Get(1);
        var forthGet = lru.Get(3);
        var fifthGet = lru.Get(4);

        using (new AssertionScope())
        {
            firstGet.Should().Be(1);
            secondGet.Should().Be(-1);
            thirdGet.Should().Be(-1);
            forthGet.Should().Be(3);
            fifthGet.Should().Be(4);
        }
    }
}
