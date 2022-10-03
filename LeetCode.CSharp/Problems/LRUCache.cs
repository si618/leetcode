namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
        "LRU Cache",
        Difficulty.Medium,
        Category.LinkedList,
        "https://www.youtube.com/watch?v=7ABFKPK2hD4")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class LRUCache
    {
        private record Node(int Key = 0, int Value = 0)
        {
            public Node? Previous { get; set; }

            public Node? Next { get; set; }
        }

        private readonly int _capacity;

        // Value is node rather than int to update double linked list (left and right nodes)
        private readonly Dictionary<int, Node> _cache = new();

        // Left node is pointer least recently used
        private readonly Node _left = new();

        // Right node is pointer to most recently used
        private readonly Node _right = new();

        public LRUCache(int capacity)
        {
            _capacity = capacity;

            // Double link pointers to each other
            _left.Next = _right;
            _right.Previous = _left;
        }

        /// <summary>
        /// Remove <paramref name="node"/> by updating its pointers to other nodes
        /// </summary>
        /// <param name="node">The node to be removed</param>
        private static void Remove(Node node)
        {
            var previous = node.Previous;
            var next = node.Next;

            if (previous is not null)
            {
                previous.Next = next;
            }
            if (next is not null)
            {
                next.Previous = previous;
            }
        }

        /// <summary>
        /// Insert <paramref name="node"/> by updating pointers and marking as most recently used
        /// </summary>
        /// <param name="node"></param>
        private void Insert(Node node)
        {
            var previous = _right.Previous;
            if (previous is not null)
            {
                // Set previous MRU pointer to new node
                previous.Next = node;
                node.Previous = previous;
            }

            // Mark node as most recently used
            _right.Previous = node;
            node.Next = _right;
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var node))
            {
                return -1;
            }

            // No need to update linked lists if key was already most recently used
            if (_right.Key == key)
            {
                return node.Value;
            }

            // Clear out "middle" node pointers
            Remove(node);

            // Update most recently used pointers
            Insert(node);

            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (_cache.TryGetValue(key, out var existing))
            {
                if (existing == _right)
                {
                    // Nothing to do as key and value were already most recently used
                    return;
                }

                // Remove existing node as it's now the most recently used but wasn't previously
                Remove(existing);
            }

            var node = new Node(key, value);

            if (!_cache.TryAdd(key, node))
            {
                // Replace node in cache as its value or pointers may have changed
                _cache[key] = node;
            }

            Insert(node);

            if (_cache.Count <= _capacity || _left.Next is null)
            {
                return;
            }

            // Capacity exceeded so remove LRU from linked list and evict from cache
            var lru = _left.Next;
            Remove(lru);
            _cache.Remove(lru.Key);
        }
    }

    [Fact]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
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
